namespace BasicFacebookFeatures
{
    partial class LoginUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button_Login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox_Welcome = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Welcome)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(665, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wellcome to Happy Facebook";
            // 
            // button_Login
            // 
            this.button_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Login.Location = new System.Drawing.Point(462, 260);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(278, 147);
            this.button_Login.TabIndex = 1;
            this.button_Login.Text = "Login";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(323, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(529, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "The app that will keep you happy!";
            // 
            // pictureBox_Welcome
            // 
            this.pictureBox_Welcome.Location = new System.Drawing.Point(384, 447);
            this.pictureBox_Welcome.Name = "pictureBox_Welcome";
            this.pictureBox_Welcome.Size = new System.Drawing.Size(439, 184);
            this.pictureBox_Welcome.TabIndex = 3;
            this.pictureBox_Welcome.TabStop = false;
            // 
            // LoginUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox_Welcome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.label1);
            this.Name = "LoginUserControl";
            this.Size = new System.Drawing.Size(1233, 747);
            this.Load += new System.EventHandler(this.LoginUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Welcome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox_Welcome;
    }
}
