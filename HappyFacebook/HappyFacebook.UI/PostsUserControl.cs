using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using HappyFaceBook.BL;
using System.Collections.Concurrent;

namespace BasicFacebookFeatures
{
    public partial class PostsUserControl : UserControl
    {
        private GiphyClient m_GiphyClient;
        private SentimentClient m_SentimentClient;

        public PostsUserControl()
        {
            InitializeComponent();
            m_GiphyClient = new GiphyClient();
            m_SentimentClient = new SentimentClient();
        }

        private async void buttonAddPhoto_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogPostPhoto.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                await Task.Run(() => pictureBox_PostSentPhoto.LoadAsync(openFileDialogPostPhoto.FileName));
                button_ClearPostPhoto.Visible = true;
            }
        }

        private void buttonAddPhoto_VisibleChanged(object sender, EventArgs e)
        {
            // Load my picture and detials
            string url = HappyFacebookManager.Instance.GetLoggedInUserPictureUrl();
            picture_myPictureBox.LoadAsync(url);
            label_MyName.Text = HappyFacebookManager.Instance.GetLoggedInUserName();
            label_FriendsCount.Text = HappyFacebookManager.Instance.GetFriends().Count.ToString();
            
            // Load my posts
            LoadMyPosts();
        }

        private async void LoadMyPosts()
        {
            List<FacebookEntity> posts = await HappyFacebookManager.Instance.GetUserPosts();
            dataGridView_MyPosts.DataSource = posts;
            dataGridView_MyPosts.Columns[0].Width = 120;
            dataGridView_MyPosts.Columns[1].Width = 70;
            dataGridView_MyPosts.Columns[2].Width = 70;
            dataGridView_MyPosts.Columns[3].Width = 120;
            dataGridView_MyPosts.Columns[4].Width = 400;

            await SetActiveFriends(posts);
        }

        private async Task SetActiveFriends(List<FacebookEntity> posts)
        {
            label_ActiveFriends.Text = "Calculating friends activity on your wall...";
            ConcurrentDictionary<string, int> likesDictionary = new ConcurrentDictionary<string, int>();
            await Task.Run(() =>
            {
                Parallel.ForEach(posts, (post) =>
                {
                    Parallel.ForEach(post.Item.LikedBy, (like) =>
                    {
                        UpdateImpactCount(like, likesDictionary);
                    });

                    Parallel.ForEach(post.Item.Comments, (comment) =>
                    {
                        UpdateImpactCount(comment.From, likesDictionary);

                        Parallel.ForEach(comment.LikedBy, (commentLike) =>
                        {
                            UpdateImpactCount(commentLike, likesDictionary);
                        });

                        Parallel.ForEach(comment.Comments, (innerComment) =>
                        {
                            UpdateImpactCount(innerComment.From, likesDictionary);

                            foreach (var innerCommentLike in innerComment.LikedBy)
                            {
                                UpdateImpactCount(innerCommentLike, likesDictionary);
                            }
                        });
                    });
                });
            });

            List<KeyValuePair<string, int>> friendsActivityList = likesDictionary.Select(kv => new KeyValuePair<string, int>(kv.Key.GetUserName(), kv.Value)).ToList();

            friendsActivityList.Sort((pair1, pair2) => -pair1.Value.CompareTo(pair2.Value));

            dataGridView_MostActive.DataSource = friendsActivityList;

            label_ActiveFriends.Text = "Most active Friends on your wall:";
        }

        private static void UpdateImpactCount(User user, ConcurrentDictionary<string, int> likesDictionary)
        {
            var userId = user.GetUserId();

            if (!likesDictionary.ContainsKey(userId))
            {
                lock (likesDictionary)
                {
                    if (!likesDictionary.ContainsKey(userId))
                    {
                        likesDictionary[userId] = 0;
                    }
                }
            }

            likesDictionary[userId] += 1;
        }

        private async void buttonPostMessage_Click(object sender, EventArgs e)
        {
            label_PostSuccess.Text = "Posting...";
            try
            {
                if (checkBox_BePositive.Checked)
                {
                    eSentiment sentiment = m_SentimentClient.GetSentiment(richTextBox_PostMessage.Text);
                    if (sentiment == eSentiment.Negative)
                    {
                        MessageBox.Show("Be more positive and try again!");
                        return;
                    }
                }

                if (richTextBox_PostMessage.Text.StartsWith(@"\giphy"))
                {
                    string searchFor = richTextBox_PostMessage.Text.Substring(@"\giphy".Length);
                    string url = m_GiphyClient.Translate(searchFor);
                    pictureBox_PostSentPhoto.Load(url);

                    DialogResult res = MessageBox.Show("Do you want to post it?", "Interesting...", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        await HappyFacebookManager.Instance.PostPictureURL(url, searchFor);
                        label_PostSuccess.Text = "Gif Posted successfully!";
                    }
                }
                else if (openFileDialogPostPhoto.FileName != String.Empty)
                {
                    await HappyFacebookManager.Instance.PostPicture(openFileDialogPostPhoto.FileName, richTextBox_PostMessage.Text);
                    label_PostSuccess.Text = "Picture Posted successfully!";
                }
                else
                {
                    await HappyFacebookManager.Instance.PostStatus(richTextBox_PostMessage.Text);
                    label_PostSuccess.Text = "Message Posted successfully!";
                }

                openFileDialogPostPhoto.FileName = String.Empty;
                richTextBox_PostMessage.Text = "Write something...";
                pictureBox_PostSentPhoto.Image = null;
                LoadMyPosts();
            }
            catch (Exception ex)
            {
                label_PostSuccess.Text = $"Status Post Failed! {ex.Message}";
            }
        }

        private void dataGridView_MyPosts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var row = dataGridView_MyPosts.CurrentRow.DataBoundItem;
                FacebookEntity selectedPost = row as FacebookEntity;
                richTextBox_SelectedPostDetails.Text = selectedPost.Name;

                if (selectedPost.PictureUrl != null)
                {
                    pictureBox_SelectedPostPicture.LoadAsync(selectedPost.PictureUrl);
                }
                else
                {
                    pictureBox_SelectedPostPicture.Image = null;
                }

                label_LikesCount.Text = selectedPost.Likes.ToString();
                label_CommentsCount.Text = selectedPost.Comments.ToString();
                label_PostDelete.Text = string.Empty;
            }
            catch (Exception ex)
            {
                richTextBox_SelectedPostDetails.Text = $"Error loading message: {ex.Message}";
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
                    FacebookEntity selectedPost = dataGridView_MyPosts.CurrentRow?.DataBoundItem as FacebookEntity;
                    await HappyFacebookManager.Instance.DeleteItem(selectedPost?.Item);
                    LoadMyPosts();
                    label_PostDelete.Text = $"Post deleted successfully";
                }
            }
            catch (Exception ex)
            {
                label_PostDelete.Text = $"Post delete failed: {ex.Message}";
            }
        }

        private void label_LikesCount_MouseHover(object sender, EventArgs e)
        {
            FacebookEntity selectedPost = dataGridView_MyPosts.CurrentRow?.DataBoundItem as FacebookEntity;
          
            toolTip_Likes.Show(string.Join(Environment.NewLine, selectedPost?.Item.LikedBy.Select(l=> l.Name)), label_LikesCount);
        }

        private void label_CommentsCount_MouseHover(object sender, EventArgs e)
        {
            //FacebookEntity selectedPost = dataGridView_MyPosts.CurrentRow?.DataBoundItem as FacebookEntity;

            //toolTip_Likes.Show(string.Join(Environment.NewLine, selectedPost?.Item.Comments[0].Comments[0].Comments.LikedBy.Select(l => l.Name)), label_LikesCount);
        }
    }
}
