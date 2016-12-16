namespace BasicFacebookFeatures
{
    partial class PostsUserControl
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
            this.buttonPostMessage = new System.Windows.Forms.Button();
            this.picture_myPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox_PostMessage = new System.Windows.Forms.RichTextBox();
            this.buttonAddPhoto = new System.Windows.Forms.Button();
            this.pictureBoxPostPhoto = new System.Windows.Forms.PictureBox();
            this.openFileDialogPostPhoto = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picture_myPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPostMessage
            // 
            this.buttonPostMessage.Location = new System.Drawing.Point(428, 3);
            this.buttonPostMessage.Name = "buttonPostMessage";
            this.buttonPostMessage.Size = new System.Drawing.Size(79, 67);
            this.buttonPostMessage.TabIndex = 0;
            this.buttonPostMessage.Text = "Post";
            this.buttonPostMessage.UseVisualStyleBackColor = true;
            this.buttonPostMessage.Click += new System.EventHandler(this.buttonPostMessage_Click);
            // 
            // picture_myPictureBox
            // 
            this.picture_myPictureBox.Location = new System.Drawing.Point(26, 62);
            this.picture_myPictureBox.Name = "picture_myPictureBox";
            this.picture_myPictureBox.Size = new System.Drawing.Size(200, 156);
            this.picture_myPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_myPictureBox.TabIndex = 42;
            this.picture_myPictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxPostPhoto);
            this.panel1.Controls.Add(this.buttonAddPhoto);
            this.panel1.Controls.Add(this.richTextBox_PostMessage);
            this.panel1.Controls.Add(this.buttonPostMessage);
            this.panel1.Location = new System.Drawing.Point(261, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 257);
            this.panel1.TabIndex = 43;
            // 
            // richTextBox_PostMessage
            // 
            this.richTextBox_PostMessage.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_PostMessage.Name = "richTextBox_PostMessage";
            this.richTextBox_PostMessage.Size = new System.Drawing.Size(419, 67);
            this.richTextBox_PostMessage.TabIndex = 1;
            this.richTextBox_PostMessage.Text = "Write something...";
            // 
            // buttonAddPhoto
            // 
            this.buttonAddPhoto.Location = new System.Drawing.Point(3, 76);
            this.buttonAddPhoto.Name = "buttonAddPhoto";
            this.buttonAddPhoto.Size = new System.Drawing.Size(81, 47);
            this.buttonAddPhoto.TabIndex = 2;
            this.buttonAddPhoto.Text = "Add Photo";
            this.buttonAddPhoto.UseVisualStyleBackColor = true;
            this.buttonAddPhoto.VisibleChanged += new System.EventHandler(this.buttonAddPhoto_VisibleChanged);
            this.buttonAddPhoto.Click += new System.EventHandler(this.buttonAddPhoto_Click);
            // 
            // pictureBoxPostPhoto
            // 
            this.pictureBoxPostPhoto.Location = new System.Drawing.Point(90, 76);
            this.pictureBoxPostPhoto.Name = "pictureBoxPostPhoto";
            this.pictureBoxPostPhoto.Size = new System.Drawing.Size(310, 164);
            this.pictureBoxPostPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPostPhoto.TabIndex = 44;
            this.pictureBoxPostPhoto.TabStop = false;
            // 
            // openFileDialogPostPhoto
            // 
            this.openFileDialogPostPhoto.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png";
            this.openFileDialogPostPhoto.Title = "Select a photo to be posted";
            // 
            // PostsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picture_myPictureBox);
            this.Name = "PostsUserControl";
            this.Size = new System.Drawing.Size(921, 747);
            ((System.ComponentModel.ISupportInitialize)(this.picture_myPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPostMessage;
        private System.Windows.Forms.PictureBox picture_myPictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxPostPhoto;
        private System.Windows.Forms.Button buttonAddPhoto;
        private System.Windows.Forms.RichTextBox richTextBox_PostMessage;
        private System.Windows.Forms.OpenFileDialog openFileDialogPostPhoto;
    }
}
