namespace BasicFacebookFeatures
{
    partial class HappyFacebookForm
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
            this.button_Logout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginUserControl
            // 
            this.loginUserControl.Location = new System.Drawing.Point(12, -74);
            this.loginUserControl.Name = "loginUserControl";
            this.loginUserControl.Size = new System.Drawing.Size(1291, 862);
            this.loginUserControl.TabIndex = 1;
            // 
            // postsUserControl
            // 
            this.postsUserControl.Location = new System.Drawing.Point(12, 12);
            this.postsUserControl.Name = "postsUserControl";
            this.postsUserControl.Size = new System.Drawing.Size(1251, 769);
            this.postsUserControl.TabIndex = 0;
            this.postsUserControl.Visible = false;
            // 
            // button_Logout
            // 
            this.button_Logout.Location = new System.Drawing.Point(1323, 258);
            this.button_Logout.Name = "button_Logout";
            this.button_Logout.Size = new System.Drawing.Size(75, 23);
            this.button_Logout.TabIndex = 2;
            this.button_Logout.Text = "Logout";
            this.button_Logout.UseVisualStyleBackColor = true;
            this.button_Logout.Click += new System.EventHandler(this.button_Logout_Click);
            // 
            // HappyFacebookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 793);
            this.Controls.Add(this.button_Logout);
            this.Controls.Add(this.loginUserControl);
            this.Controls.Add(this.postsUserControl);
            this.Name = "HappyFacebookForm";
            this.Text = "HappyFacebook";
            this.ResumeLayout(false);

        }

        #endregion

        private PostsUserControl postsUserControl;
        private LoginUserControl loginUserControl;
        private System.Windows.Forms.Button button_Logout;
    }
}

