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
    public partial class HappyFacebookForm : Form
    {
        private readonly HappyFacebookManager m_HappyFacebookManager;

        public HappyFacebookForm()
        {
            InitializeComponent();
            loginUserControl.LoginCompletedSucceffully += LoginUserControlOnLoginCompletedSucceffully;
        }

        private void LoginUserControlOnLoginCompletedSucceffully(object sender, EventArgs eventArgs)
        {
            loginUserControl.Visible = false;
            postsUserControl.Visible = true;
        }

        private void button_Logout_Click(object sender, EventArgs e)
        {
            HappyFacebookManager.Instance.Logout();
        }
    }
}
