namespace HappyFacebook.UI
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
            System.Windows.Forms.Label commentsLabel;
            System.Windows.Forms.Label likesLabel;
            this.buttonPostMessage = new System.Windows.Forms.Button();
            this.picture_myPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_BePositive = new System.Windows.Forms.CheckBox();
            this.button_ClearPostPhoto = new System.Windows.Forms.Button();
            this.label_PostSuccess = new System.Windows.Forms.Label();
            this.pictureBox_PostSentPhoto = new System.Windows.Forms.PictureBox();
            this.buttonAddPhoto = new System.Windows.Forms.Button();
            this.richTextBox_PostMessage = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.facebookEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pictureUrlPictureBox = new System.Windows.Forms.PictureBox();
            this.label_CommentsCount = new System.Windows.Forms.Label();
            this.label_LikesCount = new System.Windows.Forms.Label();
            this.openFileDialogPostPhoto = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_MyPosts = new System.Windows.Forms.DataGridView();
            this.createdTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.likesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer_Posts = new System.Windows.Forms.Timer(this.components);
            this.button_DeletePost = new System.Windows.Forms.Button();
            this.label_PostDelete = new System.Windows.Forms.Label();
            this.toolTip_Likes = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridView_MostActive = new System.Windows.Forms.DataGridView();
            this.label_ActiveFriends = new System.Windows.Forms.Label();
            this.label_MyName = new System.Windows.Forms.Label();
            this.label_FriendsCount = new System.Windows.Forms.Label();
            this.label_Friends = new System.Windows.Forms.Label();
            this.button_Logout = new System.Windows.Forms.Button();
            this.label_Events = new System.Windows.Forms.Label();
            this.label_EventsCount = new System.Windows.Forms.Label();
            this.comboBoxPostsFilter = new System.Windows.Forms.ComboBox();
            this.labelPostsFilter = new System.Windows.Forms.Label();
            commentsLabel = new System.Windows.Forms.Label();
            likesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture_myPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PostSentPhoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facebookEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUrlPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MyPosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MostActive)).BeginInit();
            this.SuspendLayout();
            // 
            // commentsLabel
            // 
            commentsLabel.AutoSize = true;
            commentsLabel.Location = new System.Drawing.Point(18, 96);
            commentsLabel.Name = "commentsLabel";
            commentsLabel.Size = new System.Drawing.Size(59, 13);
            commentsLabel.TabIndex = 0;
            commentsLabel.Text = "Comments:";
            // 
            // likesLabel
            // 
            likesLabel.AutoSize = true;
            likesLabel.Location = new System.Drawing.Point(203, 96);
            likesLabel.Name = "likesLabel";
            likesLabel.Size = new System.Drawing.Size(35, 13);
            likesLabel.TabIndex = 6;
            likesLabel.Text = "Likes:";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.pictureUrlPictureBox);
            this.groupBox1.Controls.Add(commentsLabel);
            this.groupBox1.Controls.Add(this.label_CommentsCount);
            this.groupBox1.Controls.Add(likesLabel);
            this.groupBox1.Controls.Add(this.label_LikesCount);
            this.groupBox1.Location = new System.Drawing.Point(784, 412);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 277);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookEntityBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(9, 19);
            this.nameTextBox.Multiline = true;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(299, 74);
            this.nameTextBox.TabIndex = 10;
            // 
            // facebookEntityBindingSource
            // 
            this.facebookEntityBindingSource.AllowNew = false;
            this.facebookEntityBindingSource.DataSource = typeof(HappyFaceBook.BL.IFacebookEntity);
            // 
            // pictureUrlPictureBox
            // 
            this.pictureUrlPictureBox.DataBindings.Add(new System.Windows.Forms.Binding("ImageLocation", this.facebookEntityBindingSource, "PictureUrl", true));
            this.pictureUrlPictureBox.InitialImage = null;
            this.pictureUrlPictureBox.Location = new System.Drawing.Point(9, 122);
            this.pictureUrlPictureBox.Name = "pictureUrlPictureBox";
            this.pictureUrlPictureBox.Size = new System.Drawing.Size(299, 143);
            this.pictureUrlPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureUrlPictureBox.TabIndex = 9;
            this.pictureUrlPictureBox.TabStop = false;
            // 
            // label_CommentsCount
            // 
            this.label_CommentsCount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookEntityBindingSource, "Comments", true));
            this.label_CommentsCount.Location = new System.Drawing.Point(83, 96);
            this.label_CommentsCount.Name = "label_CommentsCount";
            this.label_CommentsCount.Size = new System.Drawing.Size(68, 23);
            this.label_CommentsCount.TabIndex = 1;
            this.label_CommentsCount.Text = "0";
            // 
            // label_LikesCount
            // 
            this.label_LikesCount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facebookEntityBindingSource, "Likes", true));
            this.label_LikesCount.Location = new System.Drawing.Point(244, 96);
            this.label_LikesCount.Name = "label_LikesCount";
            this.label_LikesCount.Size = new System.Drawing.Size(64, 23);
            this.label_LikesCount.TabIndex = 7;
            this.label_LikesCount.Text = "0";
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
            this.label1.Location = new System.Drawing.Point(26, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "My last posts";
            // 
            // dataGridView_MyPosts
            // 
            this.dataGridView_MyPosts.AllowUserToAddRows = false;
            this.dataGridView_MyPosts.AllowUserToDeleteRows = false;
            this.dataGridView_MyPosts.AutoGenerateColumns = false;
            this.dataGridView_MyPosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_MyPosts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.createdTimeDataGridViewTextBoxColumn,
            this.likesDataGridViewTextBoxColumn,
            this.commentsDataGridViewTextBoxColumn,
            this.fromDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridView_MyPosts.DataSource = this.facebookEntityBindingSource;
            this.dataGridView_MyPosts.Location = new System.Drawing.Point(26, 412);
            this.dataGridView_MyPosts.Name = "dataGridView_MyPosts";
            this.dataGridView_MyPosts.ReadOnly = true;
            this.dataGridView_MyPosts.Size = new System.Drawing.Size(746, 313);
            this.dataGridView_MyPosts.TabIndex = 48;
            // 
            // createdTimeDataGridViewTextBoxColumn
            // 
            this.createdTimeDataGridViewTextBoxColumn.DataPropertyName = "CreatedTime";
            this.createdTimeDataGridViewTextBoxColumn.HeaderText = "CreatedTime";
            this.createdTimeDataGridViewTextBoxColumn.Name = "createdTimeDataGridViewTextBoxColumn";
            this.createdTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // likesDataGridViewTextBoxColumn
            // 
            this.likesDataGridViewTextBoxColumn.DataPropertyName = "Likes";
            this.likesDataGridViewTextBoxColumn.HeaderText = "Likes";
            this.likesDataGridViewTextBoxColumn.Name = "likesDataGridViewTextBoxColumn";
            this.likesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // commentsDataGridViewTextBoxColumn
            // 
            this.commentsDataGridViewTextBoxColumn.DataPropertyName = "Comments";
            this.commentsDataGridViewTextBoxColumn.HeaderText = "Comments";
            this.commentsDataGridViewTextBoxColumn.Name = "commentsDataGridViewTextBoxColumn";
            this.commentsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fromDataGridViewTextBoxColumn
            // 
            this.fromDataGridViewTextBoxColumn.DataPropertyName = "From";
            this.fromDataGridViewTextBoxColumn.HeaderText = "From";
            this.fromDataGridViewTextBoxColumn.Name = "fromDataGridViewTextBoxColumn";
            this.fromDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timer_Posts
            // 
            this.timer_Posts.Enabled = true;
            this.timer_Posts.Interval = 1000;
            this.timer_Posts.Tick += new System.EventHandler(this.timer_Posts_Tick);
            // 
            // button_DeletePost
            // 
            this.button_DeletePost.Location = new System.Drawing.Point(793, 695);
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
            // toolTip_Likes
            // 
            this.toolTip_Likes.AutoPopDelay = 10000;
            this.toolTip_Likes.InitialDelay = 500;
            this.toolTip_Likes.ReshowDelay = 100;
            // 
            // dataGridView_MostActive
            // 
            this.dataGridView_MostActive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_MostActive.Location = new System.Drawing.Point(784, 80);
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
            // comboBoxPostsFilter
            // 
            this.comboBoxPostsFilter.FormattingEnabled = true;
            this.comboBoxPostsFilter.Items.AddRange(new object[] {
            "All",
            "With Likes",
            "With Comments",
            "Most Recent"});
            this.comboBoxPostsFilter.Location = new System.Drawing.Point(207, 388);
            this.comboBoxPostsFilter.Name = "comboBoxPostsFilter";
            this.comboBoxPostsFilter.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPostsFilter.TabIndex = 64;
            this.comboBoxPostsFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxPostsFilter_SelectedIndexChanged);
            // 
            // labelPostsFilter
            // 
            this.labelPostsFilter.AutoSize = true;
            this.labelPostsFilter.Location = new System.Drawing.Point(133, 391);
            this.labelPostsFilter.Name = "labelPostsFilter";
            this.labelPostsFilter.Size = new System.Drawing.Size(68, 13);
            this.labelPostsFilter.TabIndex = 65;
            this.labelPostsFilter.Text = "My last posts";
            // 
            // PostsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelPostsFilter);
            this.Controls.Add(this.comboBoxPostsFilter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_EventsCount);
            this.Controls.Add(this.label_Events);
            this.Controls.Add(this.button_Logout);
            this.Controls.Add(this.label_FriendsCount);
            this.Controls.Add(this.label_Friends);
            this.Controls.Add(this.label_MyName);
            this.Controls.Add(this.label_ActiveFriends);
            this.Controls.Add(this.dataGridView_MostActive);
            this.Controls.Add(this.label_PostDelete);
            this.Controls.Add(this.button_DeletePost);
            this.Controls.Add(this.dataGridView_MyPosts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picture_myPictureBox);
            this.Name = "PostsUserControl";
            this.Size = new System.Drawing.Size(1112, 747);
            this.Load += new System.EventHandler(this.PostsUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture_myPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PostSentPhoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facebookEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUrlPictureBox)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView_MyPosts;
        private System.Windows.Forms.Timer timer_Posts;
        private System.Windows.Forms.Label label_PostSuccess;
        private System.Windows.Forms.Button button_ClearPostPhoto;
        private System.Windows.Forms.Button button_DeletePost;
        private System.Windows.Forms.Label label_PostDelete;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_CommentsCount;
        private System.Windows.Forms.BindingSource facebookEntityBindingSource;
        private System.Windows.Forms.Label label_LikesCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn likesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.PictureBox pictureUrlPictureBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox comboBoxPostsFilter;
        private System.Windows.Forms.Label labelPostsFilter;
    }
}
