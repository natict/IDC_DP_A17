using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using HappyFaceBook.BL;
using HappyFaceBook.BL.Exceptions;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private readonly HappyFacebookManager m_HappyFacebookManager;

        public FormMain()
        {
            InitializeComponent();
            m_HappyFacebookManager = new HappyFacebookManager();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                m_HappyFacebookManager.LoginAndInit();
                picture_smallPictureBox.LoadAsync(m_HappyFacebookManager.GetLoggedInUserPictureUrl());
                textBoxStatus.Text = m_HappyFacebookManager.GetUserPostMessages().FirstOrDefault();
            }
            catch (FacebookLoginException ex)
            {
                MessageBox.Show("Unable to connect. Try again");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error:\n {ex.Message}");
            }
        }

        private void buttonSetStatus_Click(object sender, EventArgs e)
        {
            //string id = m_HappyFacebookManager
            try
            {
                m_HappyFacebookManager.PostStatus(textBoxStatus.Text);
                MessageBox.Show("Status Posted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Status Post Failed!\n {ex.Message}");
            }

        }

        private void linkPosts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listBoxPosts.Items.Clear();
            foreach (string post in m_HappyFacebookManager.GetUserPosts())
            {
                listBoxPosts.Items.Add(post);
            }

            if (listBoxPosts.Items.Count == 0)
            {
                MessageBox.Show("No Posts to retrieve :(");
            }
        }

        private void linkFriends_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listBoxFriends.Items.Clear();
            listBoxFriends.DisplayMember = "Name";
            foreach (FacebookEntity friend in m_HappyFacebookManager.GetFriends())
            {
                listBoxFriends.Items.Add(friend);
            }

            if (listBoxFriends.Items.Count == 0)
            {
                MessageBox.Show("No Friends to retrieve :(");
            }
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                FacebookEntity selectedFriend = listBoxFriends.SelectedItem as FacebookEntity;
                if (selectedFriend.PictureUrl != null)
                {
                    pictureBoxFriend.LoadAsync(selectedFriend.PictureUrl);
                }
                else
                {
                    picture_smallPictureBox.Image = picture_smallPictureBox.ErrorImage;
                }
            }
        }

        private void labelEvents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listBoxEvents.Items.Clear();
            listBoxEvents.DisplayMember = "Name";
            foreach (FacebookEntity fbEvent in m_HappyFacebookManager.GetEvents())
            {
                listBoxEvents.Items.Add(fbEvent);
            }

            if (listBoxEvents.Items.Count == 0)
            {
                MessageBox.Show("No Events to retrieve :(");
            }
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItems.Count == 1)
            {
                Event selectedEvent = listBoxEvents.SelectedItem as Event;
                pictureBoxEvent.LoadAsync(selectedEvent.PictureNormalURL);
            }
        }

        private void linkCheckins_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listBoxCheckins.Items.Clear();
            listBoxCheckins.DisplayMember = "Name";
            foreach (FacebookEntity fbCheckin in m_HappyFacebookManager.GetCheckins())
            {
                listBoxCheckins.Items.Add(fbCheckin);
            }

            if (listBoxCheckins.Items.Count == 0)
            {
                MessageBox.Show("No Checkins to retrieve :(");
            }
        }

        private void linkPages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listBoxPages.Items.Clear();
            listBoxPages.DisplayMember = "Name";

            foreach (FacebookEntity fbPage in m_HappyFacebookManager.GetLikedPagesPages())
            {
                listBoxPages.Items.Add(fbPage);
            }

            if (listBoxPages.Items.Count == 0)
            {
                MessageBox.Show("No liked pages to retrieve :(");
            }
        }

        private void listBoxPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPages.SelectedItems.Count == 1)
            {
                FacebookEntity selectedPage = listBoxPages.SelectedItem as FacebookEntity;
                if (selectedPage != null)
                {
                    pictureBoxPage.LoadAsync(selectedPage.PictureUrl);
                }
            }
        }

        private void linkUserActions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string actionType = comboBoxActionType.SelectedItem.ToString();
            FacebookObjectCollection<Page> actions = FacebookService.GetCollection<Page>(actionType);
            dynamic actionsData = FacebookService.GetDynamicData(actionType);
            dataGridViewActions.DataSource = actions;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GiphyClient giphyClient = new GiphyClient();
            string url = giphyClient.Translate(textBox1.Text);
            pictureBox1.LoadAsync(url);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SentimentClient sentimentClient = new SentimentClient();
            eSentiment sentiment = sentimentClient.GetSentiment(textBox2.Text);
            MessageBox.Show(sentiment.ToString());
        }
    }
}
