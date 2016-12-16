using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HappyFaceBook.BL;

namespace BasicFacebookFeatures
{
    public partial class PostsUserControl : UserControl
    {
        public PostsUserControl()
        {
            InitializeComponent();
        }

        private void buttonAddPhoto_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogPostPhoto.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                pictureBoxPostPhoto.LoadAsync(openFileDialogPostPhoto.FileName);
            }
        }

        private void buttonAddPhoto_VisibleChanged(object sender, EventArgs e)
        {
            string url = HappyFacebookManager.Instance.GetLoggedInUserPictureUrl();
            picture_myPictureBox.LoadAsync(url);
        }

        private void buttonPostMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialogPostPhoto.FileName != String.Empty)
                {
                    HappyFacebookManager.Instance.PostPicture(openFileDialogPostPhoto.FileName, richTextBox_PostMessage.Text);
                    MessageBox.Show("Picture Posted successfully!");
                }
                else
                {
                    HappyFacebookManager.Instance.PostStatus(richTextBox_PostMessage.Text);
                    MessageBox.Show("Status Posted successfully!");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Status Post Failed!\n {ex.Message}");
            }
        }
    }
}
