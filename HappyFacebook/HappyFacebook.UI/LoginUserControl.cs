using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HappyFaceBook.BL;
using HappyFaceBook.BL.Exceptions;

namespace BasicFacebookFeatures
{
    public partial class LoginUserControl : UserControl
    {
        public event EventHandler LoginCompletedSucceffully;

        public LoginUserControl()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            try
            {
                HappyFacebookManager.Instance.LoginAndInit();
                LoginCompletedSucceffully?.Invoke(this, EventArgs.Empty);
            }
            catch (FacebookLoginException ex)
            {
                MessageBox.Show($"Unable to connect. Try again:{Environment.NewLine}{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error:{Environment.NewLine}{ex.Message}");
            }
        }

        private void LoginUserControl_Load(object sender, EventArgs e)
        {
            pictureBox_Welcome.LoadAsync("wfa.gif");
        }
    }
}
