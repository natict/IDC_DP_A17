using System;
using System.Windows.Forms;
using HappyFaceBook.BL;
using HappyFaceBook.BL.Exceptions;

namespace BasicFacebookFeatures
{
    internal partial class LoginUserControl : UserControl
    {
        private IFacebookApiClient m_FacebookApiClient;

        public event EventHandler LoginCompletedSucceffully;

        public LoginUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize login user control asynchronously
        /// </summary>
        public void Initialize(IFacebookApiClient i_FacebookApiClient)
        {
            // Set facebook client API
            m_FacebookApiClient = i_FacebookApiClient;
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            try
            {
                m_FacebookApiClient.LoginAndInit();
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
