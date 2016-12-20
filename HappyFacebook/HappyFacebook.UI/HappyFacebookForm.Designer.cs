namespace BasicFacebookFeatures
{
    internal partial class HappyFacebookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginUserControl = new BasicFacebookFeatures.LoginUserControl();
            this.postsUserControl = new BasicFacebookFeatures.PostsUserControl();
            this.SuspendLayout();
            // 
            // loginUserControl
            // 
            this.loginUserControl.Location = new System.Drawing.Point(-8, -10);
            this.loginUserControl.Name = "loginUserControl";
            this.loginUserControl.Size = new System.Drawing.Size(1233, 770);
            this.loginUserControl.TabIndex = 1;
            // 
            // postsUserControl
            // 
            this.postsUserControl.Location = new System.Drawing.Point(-8, -10);
            this.postsUserControl.Name = "postsUserControl";
            this.postsUserControl.Size = new System.Drawing.Size(1224, 770);
            this.postsUserControl.TabIndex = 0;
            this.postsUserControl.Visible = false;
            // 
            // HappyFacebookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 761);
            this.Controls.Add(this.loginUserControl);
            this.Controls.Add(this.postsUserControl);
            this.Name = "HappyFacebookForm";
            this.Text = "HappyFacebook";
            this.ResumeLayout(false);

        }

        #endregion

        private PostsUserControl postsUserControl;
        private LoginUserControl loginUserControl;
    }
}