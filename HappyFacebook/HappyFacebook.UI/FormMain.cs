﻿using System;
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
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                HappyFacebookManager.Instance.LoginAndInit();
                picture_smallPictureBox.LoadAsync(HappyFacebookManager.Instance.GetLoggedInUserPictureUrl());
                textBoxStatus.Text = HappyFacebookManager.Instance.GetUserPostMessages().FirstOrDefault();
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
                HappyFacebookManager.Instance.PostStatus(textBoxStatus.Text);
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
            listBoxFriends.DisplayMember = "Name";
            foreach (FacebookEntity post in HappyFacebookManager.Instance.GetUserPosts().Result)
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
            foreach (FacebookEntity friend in HappyFacebookManager.Instance.GetFriends())
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
            foreach (FacebookEntity fbEvent in HappyFacebookManager.Instance.GetEvents())
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
                FacebookEntity selectedEvent = listBoxEvents.SelectedItem as FacebookEntity;
                pictureBoxEvent.LoadAsync(selectedEvent.PictureUrl);
            }
        }

        private void linkCheckins_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listBoxCheckins.Items.Clear();
            listBoxCheckins.DisplayMember = "Name";
            foreach (FacebookEntity fbCheckin in HappyFacebookManager.Instance.GetCheckins())
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

            foreach (FacebookEntity fbPage in HappyFacebookManager.Instance.GetLikedPagesPages())
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
            pictureBox1.Load(url);

            DialogResult res = MessageBox.Show("Do you want to post it?", "Interesting...", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                //m_HappyFacebookManager.PostPicture(url, "Enjoy the pic!");
                HappyFacebookManager.Instance.PostPictureURL(url, "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SentimentClient sentimentClient = new SentimentClient();
            eSentiment sentiment = sentimentClient.GetSentiment(textBox2.Text);
            MessageBox.Show(sentiment.ToString());
        }
    }
}
