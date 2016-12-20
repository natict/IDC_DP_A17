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
    internal partial class HappyFacebookForm : Form
    {
        public HappyFacebookForm()
        {
            InitializeComponent();
            loginUserControl.LoginCompletedSucceffully += LoginUserControlOnLoginCompletedSucceffully;
            loginUserControl.Initialize(FacebookApiClient.Instance);
        }

        private async void LoginUserControlOnLoginCompletedSucceffully(object sender, EventArgs eventArgs)
        {
            loginUserControl.Visible = false;
            postsUserControl.Visible = true;
            await postsUserControl.Initialize(new GiphyClient(), new SentimentClient(), FacebookApiClient.Instance);
        }
    }
}
