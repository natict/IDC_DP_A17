using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using HappyFaceBook.BL;

namespace BasicFacebookFeatures
{
    internal partial class PostsUserControl : UserControl
    {
        /// <summary>
        /// Use this prefix to randomly search for Gifs 
        /// </summary>
        private const string GiphyPrefix = @"\giphy";

        /// <summary>
        /// Retreives a random gif which suites your phrase
        /// </summary>
        private IGiphyClient m_GiphyClient;

        /// <summary>
        /// Analyzes the sentiment context of your post, and can help you keep positive
        /// </summary>
        private ISentimentClient m_SentimentClient;

        private string m_EventsText;

        public PostsUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize posts user control asynchronously
        /// </summary>
        public async Task Initialize(IGiphyClient i_GiffyClient, ISentimentClient i_SentimentClient)
        {
            // Load my picture and detials
            m_GiphyClient = i_GiffyClient;
            m_SentimentClient = i_SentimentClient;
            string url = await FacebookApiClient.Instance.GetLoggedInUserPictureUrlAsync();
            picture_myPictureBox.LoadAsync(url);
            label_MyName.Text = await FacebookApiClient.Instance.GetLoggedInUserNameAsync();
            label_FriendsCount.Text = (await FacebookApiClient.Instance.GetFriendsAsync()).Count.ToString();
            label_EventsCount.Text = (await FacebookApiClient.Instance.GetEventsAsync()).Count.ToString();

            // Load my post
            List<IFacebookEntity> posts = await loadMyPosts();

            // Load my active friends
            await setActiveFriendsAsync(posts);

            // load events
            await loadEventsTextAsync();
        }
        
        private async Task loadEventsTextAsync()
        {
            List<IFacebookEntity> events = await FacebookApiClient.Instance.GetEventsAsync();
            if (events != null)
            {
                m_EventsText = string.Join(Environment.NewLine, events.Select(l => l.Name));
            }
        }

        /// <summary>
        /// Load posts to data grid
        /// </summary>
        /// <returns></returns>
        private async Task<List<IFacebookEntity>> loadMyPosts()
        {
            List<IFacebookEntity> posts = await FacebookApiClient.Instance.GetUserPostsAsync();
            facebookEntityBindingSource.DataSource = posts;
            dataGridView_MyPosts.Columns[0].Width = 120;
            dataGridView_MyPosts.Columns[1].Width = 70;
            dataGridView_MyPosts.Columns[2].Width = 70;
            dataGridView_MyPosts.Columns[3].Width = 120;
            dataGridView_MyPosts.Columns[4].Width = 400;

            return posts;
        }

        /// <summary>
        /// Calculted the number of activities (likes\comments) for each friend on my wall
        /// </summary>
        /// <param name="i_Posts">The list of my posts</param>
        private async Task setActiveFriendsAsync(List<IFacebookEntity> i_Posts)
        {
            label_ActiveFriends.Text = "Calculating friends activity on your wall...";
            ConcurrentDictionary<string, int> likesDictionary = new ConcurrentDictionary<string, int>();
            await Task.Run(() =>
            {
                // for all posts
                Parallel.ForEach(
                    i_Posts,
                    (post) =>
                    {
                        // All likes on post
                        Parallel.ForEach(post.Item.LikedBy, (like) => { updateImpactCount(like, likesDictionary); });

                        // All comments in post
                        Parallel.ForEach(
                            post.Item.Comments,
                            (comment) =>
                            {
                                updateImpactCount(comment.From, likesDictionary);

                                // All likes for comment
                                Parallel.ForEach(comment.LikedBy, (commentLike) => { updateImpactCount(commentLike, likesDictionary); });

                                // All comments for comment
                                Parallel.ForEach(
                                    comment.Comments,
                                    (innerComment) =>
                                    {
                                        updateImpactCount(innerComment.From, likesDictionary);

                                        // All likes for coment in comment
                                        foreach (var innerCommentLike in innerComment.LikedBy)
                                        {
                                            updateImpactCount(innerCommentLike, likesDictionary);
                                        }
                                    });
                            });
                    });
            });

            // Sort and set to data grid.
            List<KeyValuePair<string, int>> friendsActivityList = likesDictionary.Select(kv => new KeyValuePair<string, int>(kv.Key.GetUserName(), kv.Value)).ToList();
            friendsActivityList.Sort((pair1, pair2) => -pair1.Value.CompareTo(pair2.Value));
            dataGridView_MostActive.DataSource = friendsActivityList;

            label_ActiveFriends.Text = "Most active Friends on your wall:";
        }

        /// <summary>
        /// Thread safe update of friend activity count on my wall.
        /// </summary>
        /// <param name="i_User">The user which performed an activity on my wall</param>
        /// <param name="i_FriendsActivityDictionary">Dictionary which contains the activity count of my friend on my wall</param>
        private void updateImpactCount(User i_User, ConcurrentDictionary<string, int> i_FriendsActivityDictionary)
        {
            var userId = i_User.GetUserId();

            if (!i_FriendsActivityDictionary.ContainsKey(userId))
            {
                lock (i_FriendsActivityDictionary)
                {
                    if (!i_FriendsActivityDictionary.ContainsKey(userId))
                    {
                        i_FriendsActivityDictionary[userId] = 0;
                    }
                }
            }

            i_FriendsActivityDictionary[userId] += 1;
        }

        private async void buttonAddPhoto_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogPostPhoto.ShowDialog();
            if (result == DialogResult.OK) 
            {
                await Task.Run(() => pictureBox_PostSentPhoto.LoadAsync(openFileDialogPostPhoto.FileName));
                button_ClearPostPhoto.Visible = true;
            }
        }

        private async void buttonPostMessage_Click(object sender, EventArgs e)
        {
            label_PostSuccess.Text = "Posting...";

            try
            {
                // Check post sentiment
                if (checkBox_BePositive.Checked)
                {
                    eSentiment sentiment = m_SentimentClient.GetSentiment(richTextBox_PostMessage.Text);
                    if (sentiment == eSentiment.Negative)
                    {
                        MessageBox.Show("Be more positive and try again!");
                        return;
                    }
                }

                // Search for Gif
                if (richTextBox_PostMessage.Text.ToLower().StartsWith(GiphyPrefix))
                {
                    string searchFor = richTextBox_PostMessage.Text.Substring(GiphyPrefix.Length);
                    string url = m_GiphyClient.Translate(searchFor);
                    pictureBox_PostSentPhoto.Load(url);

                    DialogResult res = MessageBox.Show("Do you want to post it?", "Interesting...", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        await FacebookApiClient.Instance.PostPictureURLAsync(url, searchFor);
                        label_PostSuccess.Text = "Gif Posted successfully!";
                    }
                }
                else if (openFileDialogPostPhoto.FileName != string.Empty)
                {
                    await FacebookApiClient.Instance.PostPictureAsync(openFileDialogPostPhoto.FileName, richTextBox_PostMessage.Text);
                    label_PostSuccess.Text = "Picture Posted successfully!";
                }
                else
                {
                    await FacebookApiClient.Instance.PostStatusAsync(richTextBox_PostMessage.Text);
                    label_PostSuccess.Text = "Message Posted successfully!";
                }

                openFileDialogPostPhoto.FileName = string.Empty;
                richTextBox_PostMessage.Text = $"Write something... {Environment.NewLine}{Environment.NewLine}Use \"{GiphyPrefix}\" prefix to match a gif to ypour post";
                pictureBox_PostSentPhoto.Image = null;
                await loadMyPosts();
            }
            catch (Exception ex)
            {
                label_PostSuccess.Text = $"Status Post Failed! {ex.Message}";
            }
        }

        private void timer_Posts_Tick(object sender, EventArgs e)
        {
            dataGridView_MyPosts.Refresh();
        }

        private void richTextBox_PostMessage_Click(object sender, EventArgs e)
        {
            richTextBox_PostMessage.SelectAll();    
        }

        private void button_ClearPostPhoto_Click(object sender, EventArgs e)
        {
            openFileDialogPostPhoto.FileName = string.Empty;
            pictureBox_PostSentPhoto.Image = null;
            button_ClearPostPhoto.Visible = false;
        }

        private async void button_DeletePost_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    label_PostDelete.Text = "Deleting...";
                    IFacebookEntity selectedPost = getCurrentRow();
                    await FacebookApiClient.Instance.DeleteItemAsync(selectedPost?.Item);
                    await loadMyPosts();
                    label_PostDelete.Text = $"Post deleted successfully";
                }
            }
            catch (Exception ex)
            {
                label_PostDelete.Text = $"Post delete failed: {ex.Message}";
            }
        }

        private IFacebookEntity getCurrentRow()
        {
            return dataGridView_MyPosts.CurrentRow?.DataBoundItem as IFacebookEntity;
        }

        private void button_Logout_Click(object sender, EventArgs e)
        {
            FacebookApiClient.Instance.Logout();
        }

        private void label_EventsCount_MouseHover(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(m_EventsText))
            {
                toolTip_Likes.Show(m_EventsText, label_EventsCount);
            }
            else
            {
                toolTip_Likes.Hide(label_EventsCount);
            }
        }

        private void label_LikesCount_MouseHover(object sender, EventArgs e)
        {
            displayPostTooltip(selectedPost => string.Join(Environment.NewLine, selectedPost?.Item.LikedBy.Select(l => l.Name)), label_LikesCount);
        }

        private void label_CommentsCount_MouseHover(object sender, EventArgs e)
        {
            displayPostTooltip(selectedPost => string.Join(Environment.NewLine, selectedPost?.Item.Comments.Select(c => $"{c.From.Name}  {c.Message}")), label_CommentsCount);
        }

        private void displayPostTooltip(Func<IFacebookEntity, string> getText, IWin32Window element)
        {
            IFacebookEntity selectedPost = getCurrentRow();

            if (selectedPost != null)
            {
                string text = getText(selectedPost);
                if (!string.IsNullOrWhiteSpace(text))
                {
                    toolTip_Likes.Show(text, element);
                }
                else
                {
                    toolTip_Likes.Hide(element);
                }
            }
        }
    }
}