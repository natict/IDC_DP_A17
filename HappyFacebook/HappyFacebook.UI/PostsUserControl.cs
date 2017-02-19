using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using HappyFaceBook.BL;
using HappyFaceBook.UI.PostHandlers;
using System.Data;
using HappyFacebook.UI.BestFriendAlgorithm;
using HappyFacebook.UI.PostsFilter;

namespace HappyFacebook.UI
{
    internal partial class PostsUserControl : UserControl
    {
        /// <summary>
        /// Posts handler (chain of responsibility)
        /// </summary>
        private PostHandlerBase m_PostsHandlersChain;

        /// <summary>
        /// Strategy which performs a specific posts filtering
        /// </summary>
        private PostsFilterBase m_PostFilterBase;

        /// <summary>
        /// Analyses your fiends activity on your wall (Template method)
        /// </summary>
        private FriendsActivityAnalyzer m_FriendsActivityAnalyzer;

        private List<IFacebookEntity> m_Posts;

        private string m_EventsText;

        public PostsUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize posts user control asynchronously
        /// </summary>
        /// <param name="i_GiffyClient">Retrieves a random gif which suites your phrase</param>
        /// <param name="i_SentimentClient">Analyzes the sentiment context of your post, and can help you keep positive</param>
        /// <returns></returns>
        public async Task Initialize(IGiphyClient i_GiffyClient, ISentimentClient i_SentimentClient)
        {
            m_PostsHandlersChain = intializePostsPublishChain(i_GiffyClient, i_SentimentClient);

            // Load my picture and detials
            string url = await FacebookApiClient.Instance.GetLoggedInUserPictureUrlAsync();
            picture_myPictureBox.LoadAsync(url);
            label_MyName.Text = await FacebookApiClient.Instance.GetLoggedInUserNameAsync();
            label_FriendsCount.Text = (await FacebookApiClient.Instance.GetFriendsAsync()).Count.ToString();
            label_EventsCount.Text = (await FacebookApiClient.Instance.GetEventsAsync()).Count.ToString();

            // Load my post
            await loadMyPosts();

            // Load my active friends
            await setActiveFriendsAsync();

            // load events
            await loadEventsTextAsync();
        }

        /// <summary>
        /// Initialize post handlers (chain of responsibility)
        /// </summary>
        /// <returns></returns>
        private PostHandlerBase intializePostsPublishChain(IGiphyClient i_GiffyClient, ISentimentClient i_SentimentClient)
        {
            SentimentPostHandler sentimentHandler = new SentimentPostHandler(i_SentimentClient);
            GiphyPostHandler giffyHandler = new GiphyPostHandler(i_GiffyClient, pictureBox_PostSentPhoto);
            PublishPostHandler publishPostHandler = new PublishPostHandler();
            sentimentHandler.SetSuccessor(giffyHandler);
            giffyHandler.SetSuccessor(publishPostHandler);

            return sentimentHandler;
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
        private async Task loadMyPosts()
        {
            m_Posts = await FacebookApiClient.Instance.GetUserPostsAsync();
            facebookEntityBindingSource.DataSource = m_Posts;
            PostsFilterBase.SetPosts(m_Posts, facebookEntityBindingSource);
            comboBoxPostsFilter.SelectedIndex = 0;

            dataGridView_MyPosts.Columns[0].Width = 120;
            dataGridView_MyPosts.Columns[1].Width = 70;
            dataGridView_MyPosts.Columns[2].Width = 70;
            dataGridView_MyPosts.Columns[3].Width = 120;
            dataGridView_MyPosts.Columns[4].Width = 400;
        }

        /// <summary>
        /// Calculated the number of activities (likes\comments) for each friend on my wall
        /// </summary>
        /// <param name="i_Posts">The list of my posts</param>
        private async Task setActiveFriendsAsync()
        {
            label_ActiveFriends.Text = "Calculating friends activity on your wall...";

            if (radioButtonByLikes.Checked)
            {
                m_FriendsActivityAnalyzer = new FriendsLikeAnalyzer();
            }
            else
            {
                m_FriendsActivityAnalyzer = new FriendsCommentsAnalyzer();
            }

            dataGridView_MostActive.DataSource = await m_FriendsActivityAnalyzer.Analayze(m_Posts);

            label_ActiveFriends.Text = "Most active Friends on your wall:";
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
                PostRequest request = new PostRequest();
                request.ShouldStayPositive = checkBox_BePositive.Checked;
                request.Message = richTextBox_PostMessage.Text;
                request.PictureUrl = openFileDialogPostPhoto.FileName;

                await m_PostsHandlersChain.ProcessRequest(request);
                label_PostSuccess.Text = request.RequestResult;


                openFileDialogPostPhoto.FileName = string.Empty;
                richTextBox_PostMessage.Text = $"Write something... {Environment.NewLine}{Environment.NewLine}Use \"{GiphyPostHandler.GiphyPrefix}\" prefix to match a gif to ypour post";
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

        private void comboBoxPostsFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ePostsFilterType type = (ePostsFilterType)comboBoxPostsFilter.SelectedIndex;
            m_PostFilterBase = PostsFilterBase.GetPostsFilter(type);
            m_PostFilterBase.FilterPosts();
        }

        private void PostsUserControl_Load(object sender, EventArgs e)
        {
            comboBoxPostsFilter.DataSource = Enum.GetValues(typeof(ePostsFilterType));
        }

        private void radioButtonByLikes_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Posts == null)
            {
                return;
            }

            setActiveFriendsAsync();
        }
    }
}