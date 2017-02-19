using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HappyFaceBook.BL;

namespace HappyFacebook.UI
{
    internal partial class HappyFacebookForm : Form
    {
        public HappyFacebookForm()
        {
            InitializeComponent();
            loginUserControl.LoginCompletedSucceffully += LoginUserControlOnLoginCompletedSucceffully;
        }

        private async void LoginUserControlOnLoginCompletedSucceffully(object sender, EventArgs eventArgs)
        {
            loginUserControl.Visible = false;
            postsUserControl.Visible = true;
            await postsUserControl.Initialize(new GiphyClient(), new SentimentClient());
        }
    }
}
