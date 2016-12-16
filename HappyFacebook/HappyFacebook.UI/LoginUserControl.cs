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
                MessageBox.Show("Unable to connect. Try again");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error:\n {ex.Message}");
            }
        }

    }
}
