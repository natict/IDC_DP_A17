namespace BasicFacebookFeatures
{
    internal partial class PostsUserControl
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
            this.components = new System.ComponentModel.Container();
            this.buttonPostMessage = new System.Windows.Forms.Button();
            this.picture_myPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_BePositive = new System.Windows.Forms.CheckBox();
            this.button_ClearPostPhoto = new System.Windows.Forms.Button();
            this.label_PostSuccess = new System.Windows.Forms.Label();
            this.pictureBox_PostSentPhoto = new System.Windows.Forms.PictureBox();
            this.buttonAddPhoto = new System.Windows.Forms.Button();
            this.richTextBox_PostMessage = new System.Windows.Forms.RichTextBox();
            this.openFileDialogPostPhoto = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_SelectedPostPicture = new System.Windows.Forms.PictureBox();
            this.richTextBox_SelectedPostDetails = new System.Windows.Forms.RichTextBox();
            this.dataGridView_MyPosts = new System.Windows.Forms.DataGridView();
            this.timer_Posts = new System.Windows.Forms.Timer(this.components);
            this.button_DeletePost = new System.Windows.Forms.Button();
            this.label_PostDelete = new System.Windows.Forms.Label();
            this.label_Likes = new System.Windows.Forms.Label();
            this.label_LikesCount = new System.Windows.Forms.Label();
            this.label_Comments = new System.Windows.Forms.Label();
            this.label_CommentsCount = new System.Windows.Forms.Label();
            this.toolTip_Likes = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridView_MostActive = new System.Windows.Forms.DataGridView();
            this.label_ActiveFriends = new System.Windows.Forms.Label();
            this.label_MyName = new System.Windows.Forms.Label();
            this.label_FriendsCount = new System.Windows.Forms.Label();
            this.label_Friends = new System.Windows.Forms.Label();
            this.button_Logout = new System.Windows.Forms.Button();
            this.label_Events = new System.Windows.Forms.Label();
            this.label_EventsCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture_myPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PostSentPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SelectedPostPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MyPosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MostActive)).BeginInit();
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
            this.picture_myPictureBox.Location = new System.Drawing.Point(26, 98);
            this.picture_myPictureBox.Name = "picture_myPictureBox";
            this.picture_myPictureBox.Size = new System.Drawing.Size(200, 156);
            this.picture_myPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_myPictureBox.TabIndex = 42;
            this.picture_myPictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox_BePositive);
            this.panel1.Controls.Add(this.button_ClearPostPhoto);
            this.panel1.Controls.Add(this.label_PostSuccess);
            this.panel1.Controls.Add(this.pictureBox_PostSentPhoto);
            this.panel1.Controls.Add(this.buttonAddPhoto);
            this.panel1.Controls.Add(this.richTextBox_PostMessage);
            this.panel1.Controls.Add(this.buttonPostMessage);
            this.panel1.Location = new System.Drawing.Point(261, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 257);
            this.panel1.TabIndex = 43;
            // 
            // checkBox_BePositive
            // 
            this.checkBox_BePositive.AutoSize = true;
            this.checkBox_BePositive.Checked = true;
            this.checkBox_BePositive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_BePositive.Location = new System.Drawing.Point(427, 78);
            this.checkBox_BePositive.Name = "checkBox_BePositive";
            this.checkBox_BePositive.Size = new System.Drawing.Size(85, 17);
            this.checkBox_BePositive.TabIndex = 51;
            this.checkBox_BePositive.Text = "Be Positive?";
            this.checkBox_BePositive.UseVisualStyleBackColor = true;
            // 
            // button_ClearPostPhoto
            // 
            this.button_ClearPostPhoto.Location = new System.Drawing.Point(3, 158);
            this.button_ClearPostPhoto.Name = "button_ClearPostPhoto";
            this.button_ClearPostPhoto.Size = new System.Drawing.Size(81, 47);
            this.button_ClearPostPhoto.TabIndex = 50;
            this.button_ClearPostPhoto.Text = "Clear Photo";
            this.button_ClearPostPhoto.UseVisualStyleBackColor = true;
            this.button_ClearPostPhoto.Visible = false;
            this.button_ClearPostPhoto.Click += new System.EventHandler(this.button_ClearPostPhoto_Click);
            // 
            // label_PostSuccess
            // 
            this.label_PostSuccess.AutoSize = true;
            this.label_PostSuccess.Location = new System.Drawing.Point(3, 78);
            this.label_PostSuccess.Name = "label_PostSuccess";
            this.label_PostSuccess.Size = new System.Drawing.Size(0, 13);
            this.label_PostSuccess.TabIndex = 49;
            // 
            // pictureBox_PostSentPhoto
            // 
            this.pictureBox_PostSentPhoto.Location = new System.Drawing.Point(90, 94);
            this.pictureBox_PostSentPhoto.Name = "pictureBox_PostSentPhoto";
            this.pictureBox_PostSentPhoto.Size = new System.Drawing.Size(310, 160);
            this.pictureBox_PostSentPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_PostSentPhoto.TabIndex = 44;
            this.pictureBox_PostSentPhoto.TabStop = false;
            // 
            // buttonAddPhoto
            // 
            this.buttonAddPhoto.Location = new System.Drawing.Point(3, 94);
            this.buttonAddPhoto.Name = "buttonAddPhoto";
            this.buttonAddPhoto.Size = new System.Drawing.Size(81, 47);
            this.buttonAddPhoto.TabIndex = 2;
            this.buttonAddPhoto.Text = "Add Photo";
            this.buttonAddPhoto.UseVisualStyleBackColor = true;
            this.buttonAddPhoto.Click += new System.EventHandler(this.buttonAddPhoto_Click);
            // 
            // richTextBox_PostMessage
            // 
            this.richTextBox_PostMessage.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_PostMessage.Name = "richTextBox_PostMessage";
            this.richTextBox_PostMessage.Size = new System.Drawing.Size(419, 67);
            this.richTextBox_PostMessage.TabIndex = 1;
            this.richTextBox_PostMessage.Text = "Write something... \n\nUse \"\\giphy\" prefix to match a gif to ypour post";
            this.richTextBox_PostMessage.Click += new System.EventHandler(this.richTextBox_PostMessage_Click);
            // 
            // openFileDialogPostPhoto
            // 
            this.openFileDialogPostPhoto.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png";
            this.openFileDialogPostPhoto.Title = "Select a photo to be posted";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "My last posts";
            // 
            // pictureBox_SelectedPostPicture
            // 
            this.pictureBox_SelectedPostPicture.Location = new System.Drawing.Point(882, 547);
            this.pictureBox_SelectedPostPicture.Name = "pictureBox_SelectedPostPicture";
            this.pictureBox_SelectedPostPicture.Size = new System.Drawing.Size(305, 130);
            this.pictureBox_SelectedPostPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_SelectedPostPicture.TabIndex = 45;
            this.pictureBox_SelectedPostPicture.TabStop = false;
            // 
            // richTextBox_SelectedPostDetails
            // 
            this.richTextBox_SelectedPostDetails.Location = new System.Drawing.Point(882, 412);
            this.richTextBox_SelectedPostDetails.Name = "richTextBox_SelectedPostDetails";
            this.richTextBox_SelectedPostDetails.Size = new System.Drawing.Size(305, 85);
            this.richTextBox_SelectedPostDetails.TabIndex = 46;
            this.richTextBox_SelectedPostDetails.Text = "Write something...";
            // 
            // dataGridView_MyPosts
            // 
            this.dataGridView_MyPosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_MyPosts.Location = new System.Drawing.Point(26, 412);
            this.dataGridView_MyPosts.Name = "dataGridView_MyPosts";
            this.dataGridView_MyPosts.ReadOnly = true;
            this.dataGridView_MyPosts.Size = new System.Drawing.Size(821, 313);
            this.dataGridView_MyPosts.TabIndex = 48;
            this.dataGridView_MyPosts.SelectionChanged += new System.EventHandler(this.dataGridView_MyPosts_SelectionChanged);
            // 
            // timer_Posts
            // 
            this.timer_Posts.Enabled = true;
            this.timer_Posts.Interval = 1000;
            this.timer_Posts.Tick += new System.EventHandler(this.timer_Posts_Tick);
            // 
            // button_DeletePost
            // 
            this.button_DeletePost.Location = new System.Drawing.Point(882, 695);
            this.button_DeletePost.Name = "button_DeletePost";
            this.button_DeletePost.Size = new System.Drawing.Size(92, 30);
            this.button_DeletePost.TabIndex = 49;
            this.button_DeletePost.Text = "Delete";
            this.button_DeletePost.UseVisualStyleBackColor = true;
            this.button_DeletePost.Click += new System.EventHandler(this.button_DeletePost_Click);
            // 
            // label_PostDelete
            // 
            this.label_PostDelete.AutoSize = true;
            this.label_PostDelete.Location = new System.Drawing.Point(882, 732);
            this.label_PostDelete.Name = "label_PostDelete";
            this.label_PostDelete.Size = new System.Drawing.Size(0, 13);
            this.label_PostDelete.TabIndex = 50;
            // 
            // label_Likes
            // 
            this.label_Likes.AutoSize = true;
            this.label_Likes.Location = new System.Drawing.Point(882, 514);
            this.label_Likes.Name = "label_Likes";
            this.label_Likes.Size = new System.Drawing.Size(35, 13);
            this.label_Likes.TabIndex = 51;
            this.label_Likes.Text = "Likes:";
            // 
            // label_LikesCount
            // 
            this.label_LikesCount.AutoSize = true;
            this.label_LikesCount.Location = new System.Drawing.Point(923, 514);
            this.label_LikesCount.Name = "label_LikesCount";
            this.label_LikesCount.Size = new System.Drawing.Size(13, 13);
            this.label_LikesCount.TabIndex = 52;
            this.label_LikesCount.Text = "0";
            this.label_LikesCount.MouseHover += new System.EventHandler(this.label_LikesCount_MouseHover);
            // 
            // label_Comments
            // 
            this.label_Comments.AutoSize = true;
            this.label_Comments.Location = new System.Drawing.Point(1049, 514);
            this.label_Comments.Name = "label_Comments";
            this.label_Comments.Size = new System.Drawing.Size(59, 13);
            this.label_Comments.TabIndex = 53;
            this.label_Comments.Text = "Comments:";
            // 
            // label_CommentsCount
            // 
            this.label_CommentsCount.AutoSize = true;
            this.label_CommentsCount.Location = new System.Drawing.Point(1114, 514);
            this.label_CommentsCount.Name = "label_CommentsCount";
            this.label_CommentsCount.Size = new System.Drawing.Size(13, 13);
            this.label_CommentsCount.TabIndex = 54;
            this.label_CommentsCount.Text = "0";
            this.label_CommentsCount.MouseHover += new System.EventHandler(this.label_CommentsCount_MouseHover);
            // 
            // toolTip_Likes
            // 
            this.toolTip_Likes.AutoPopDelay = 10000;
            this.toolTip_Likes.InitialDelay = 500;
            this.toolTip_Likes.ReshowDelay = 100;
            // 
            // dataGridView_MostActive
            // 
            this.dataGridView_MostActive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_MostActive.Location = new System.Drawing.Point(873, 80);
            this.dataGridView_MostActive.Name = "dataGridView_MostActive";
            this.dataGridView_MostActive.ReadOnly = true;
            this.dataGridView_MostActive.Size = new System.Drawing.Size(314, 313);
            this.dataGridView_MostActive.TabIndex = 55;
            // 
            // label_ActiveFriends
            // 
            this.label_ActiveFriends.AutoSize = true;
            this.label_ActiveFriends.Location = new System.Drawing.Point(870, 64);
            this.label_ActiveFriends.Name = "label_ActiveFriends";
            this.label_ActiveFriends.Size = new System.Drawing.Size(211, 13);
            this.label_ActiveFriends.TabIndex = 56;
            this.label_ActiveFriends.Text = "Most Active friends (Most comments & Likes)";
            // 
            // label_MyName
            // 
            this.label_MyName.AutoSize = true;
            this.label_MyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MyName.Location = new System.Drawing.Point(25, 64);
            this.label_MyName.Name = "label_MyName";
            this.label_MyName.Size = new System.Drawing.Size(0, 24);
            this.label_MyName.TabIndex = 57;
            // 
            // label_FriendsCount
            // 
            this.label_FriendsCount.AutoSize = true;
            this.label_FriendsCount.Location = new System.Drawing.Point(76, 273);
            this.label_FriendsCount.Name = "label_FriendsCount";
            this.label_FriendsCount.Size = new System.Drawing.Size(13, 13);
            this.label_FriendsCount.TabIndex = 59;
            this.label_FriendsCount.Text = "0";
            // 
            // label_Friends
            // 
            this.label_Friends.AutoSize = true;
            this.label_Friends.Location = new System.Drawing.Point(35, 273);
            this.label_Friends.Name = "label_Friends";
            this.label_Friends.Size = new System.Drawing.Size(44, 13);
            this.label_Friends.TabIndex = 58;
            this.label_Friends.Text = "Friends:";
            // 
            // button_Logout
            // 
            this.button_Logout.Location = new System.Drawing.Point(26, 14);
            this.button_Logout.Name = "button_Logout";
            this.button_Logout.Size = new System.Drawing.Size(92, 30);
            this.button_Logout.TabIndex = 60;
            this.button_Logout.Text = "Logout";
            this.button_Logout.UseVisualStyleBackColor = true;
            this.button_Logout.Click += new System.EventHandler(this.button_Logout_Click);
            // 
            // label_Events
            // 
            this.label_Events.AutoSize = true;
            this.label_Events.Location = new System.Drawing.Point(35, 301);
            this.label_Events.Name = "label_Events";
            this.label_Events.Size = new System.Drawing.Size(43, 13);
            this.label_Events.TabIndex = 61;
            this.label_Events.Text = "Events:";
            // 
            // label_EventsCount
            // 
            this.label_EventsCount.AutoSize = true;
            this.label_EventsCount.Location = new System.Drawing.Point(76, 301);
            this.label_EventsCount.Name = "label_EventsCount";
            this.label_EventsCount.Size = new System.Drawing.Size(13, 13);
            this.label_EventsCount.TabIndex = 62;
            this.label_EventsCount.Text = "0";
            this.label_EventsCount.MouseHover += new System.EventHandler(this.label_EventsCount_MouseHover);
            // 
            // PostsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_EventsCount);
            this.Controls.Add(this.label_Events);
            this.Controls.Add(this.button_Logout);
            this.Controls.Add(this.label_FriendsCount);
            this.Controls.Add(this.label_Friends);
            this.Controls.Add(this.label_MyName);
            this.Controls.Add(this.label_ActiveFriends);
            this.Controls.Add(this.dataGridView_MostActive);
            this.Controls.Add(this.label_CommentsCount);
            this.Controls.Add(this.label_Comments);
            this.Controls.Add(this.label_LikesCount);
            this.Controls.Add(this.label_Likes);
            this.Controls.Add(this.label_PostDelete);
            this.Controls.Add(this.button_DeletePost);
            this.Controls.Add(this.dataGridView_MyPosts);
            this.Controls.Add(this.richTextBox_SelectedPostDetails);
            this.Controls.Add(this.pictureBox_SelectedPostPicture);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picture_myPictureBox);
            this.Name = "PostsUserControl";
            this.Size = new System.Drawing.Size(1233, 747);
            ((System.ComponentModel.ISupportInitialize)(this.picture_myPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PostSentPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SelectedPostPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MyPosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MostActive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPostMessage;
        private System.Windows.Forms.PictureBox picture_myPictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_PostSentPhoto;
        private System.Windows.Forms.Button buttonAddPhoto;
        private System.Windows.Forms.RichTextBox richTextBox_PostMessage;
        private System.Windows.Forms.OpenFileDialog openFileDialogPostPhoto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_SelectedPostPicture;
        private System.Windows.Forms.RichTextBox richTextBox_SelectedPostDetails;
        private System.Windows.Forms.DataGridView dataGridView_MyPosts;
        private System.Windows.Forms.Timer timer_Posts;
        private System.Windows.Forms.Label label_PostSuccess;
        private System.Windows.Forms.Button button_ClearPostPhoto;
        private System.Windows.Forms.Button button_DeletePost;
        private System.Windows.Forms.Label label_PostDelete;
        private System.Windows.Forms.Label label_Likes;
        private System.Windows.Forms.Label label_LikesCount;
        private System.Windows.Forms.Label label_Comments;
        private System.Windows.Forms.Label label_CommentsCount;
        private System.Windows.Forms.ToolTip toolTip_Likes;
        private System.Windows.Forms.DataGridView dataGridView_MostActive;
        private System.Windows.Forms.Label label_ActiveFriends;
        private System.Windows.Forms.CheckBox checkBox_BePositive;
        private System.Windows.Forms.Label label_MyName;
        private System.Windows.Forms.Label label_FriendsCount;
        private System.Windows.Forms.Label label_Friends;
        private System.Windows.Forms.Button button_Logout;
        private System.Windows.Forms.Label label_Events;
        private System.Windows.Forms.Label label_EventsCount;
    }
}
