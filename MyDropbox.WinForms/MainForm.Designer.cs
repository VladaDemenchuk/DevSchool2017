namespace MyDropbox.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btAddFile = new System.Windows.Forms.Button();
            this.btDeleteFile = new System.Windows.Forms.Button();
            this.btDownloadFile = new System.Windows.Forms.Button();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.lbUserNameLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbComments = new System.Windows.Forms.GroupBox();
            this.rbCommentText = new System.Windows.Forms.RichTextBox();
            this.btAddComment = new System.Windows.Forms.Button();
            this.btDeleteComment = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.btShare = new System.Windows.Forms.Button();
            this.lkLogout = new System.Windows.Forms.LinkLabel();
            this.lbComments = new System.Windows.Forms.ListBox();
            this.tcfiles = new System.Windows.Forms.TabControl();
            this.tbMyFile = new System.Windows.Forms.TabPage();
            this.tbShares = new System.Windows.Forms.TabPage();
            this.lbSharesFiles = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.gbComments.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tcfiles.SuspendLayout();
            this.tbMyFile.SuspendLayout();
            this.tbShares.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAddFile
            // 
            this.btAddFile.Location = new System.Drawing.Point(18, 19);
            this.btAddFile.Name = "btAddFile";
            this.btAddFile.Size = new System.Drawing.Size(75, 23);
            this.btAddFile.TabIndex = 0;
            this.btAddFile.Text = "Добавить";
            this.btAddFile.UseVisualStyleBackColor = true;
            this.btAddFile.Click += new System.EventHandler(this.btAddFile_Click);
            // 
            // btDeleteFile
            // 
            this.btDeleteFile.Location = new System.Drawing.Point(18, 77);
            this.btDeleteFile.Name = "btDeleteFile";
            this.btDeleteFile.Size = new System.Drawing.Size(75, 23);
            this.btDeleteFile.TabIndex = 1;
            this.btDeleteFile.Text = "Удалить";
            this.btDeleteFile.UseVisualStyleBackColor = true;
            this.btDeleteFile.Click += new System.EventHandler(this.btDeleteFile_Click);
            // 
            // btDownloadFile
            // 
            this.btDownloadFile.Location = new System.Drawing.Point(18, 48);
            this.btDownloadFile.Name = "btDownloadFile";
            this.btDownloadFile.Size = new System.Drawing.Size(75, 23);
            this.btDownloadFile.TabIndex = 2;
            this.btDownloadFile.Text = "Скачать";
            this.btDownloadFile.UseVisualStyleBackColor = true;
            this.btDownloadFile.Click += new System.EventHandler(this.btDownloadFile_Click);
            // 
            // lbFiles
            // 
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.Location = new System.Drawing.Point(3, 3);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(163, 186);
            this.lbFiles.TabIndex = 3;
            this.lbFiles.SelectedIndexChanged += new System.EventHandler(this.lbFiles_SelectedIndexChanged);
            // 
            // lbUserNameLabel
            // 
            this.lbUserNameLabel.AutoSize = true;
            this.lbUserNameLabel.Location = new System.Drawing.Point(12, 9);
            this.lbUserNameLabel.Name = "lbUserNameLabel";
            this.lbUserNameLabel.Size = new System.Drawing.Size(132, 13);
            this.lbUserNameLabel.TabIndex = 4;
            this.lbUserNameLabel.Text = "Текущий пользователь: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btAddFile);
            this.groupBox1.Controls.Add(this.btDownloadFile);
            this.groupBox1.Controls.Add(this.btDeleteFile);
            this.groupBox1.Location = new System.Drawing.Point(187, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 111);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файл";
            // 
            // gbComments
            // 
            this.gbComments.Controls.Add(this.rbCommentText);
            this.gbComments.Controls.Add(this.btAddComment);
            this.gbComments.Controls.Add(this.btDeleteComment);
            this.gbComments.Location = new System.Drawing.Point(475, 39);
            this.gbComments.Name = "gbComments";
            this.gbComments.Size = new System.Drawing.Size(135, 166);
            this.gbComments.TabIndex = 6;
            this.gbComments.TabStop = false;
            this.gbComments.Text = "Комментарий";
            // 
            // rbCommentText
            // 
            this.rbCommentText.Location = new System.Drawing.Point(6, 19);
            this.rbCommentText.Name = "rbCommentText";
            this.rbCommentText.Size = new System.Drawing.Size(123, 81);
            this.rbCommentText.TabIndex = 2;
            this.rbCommentText.Text = "";
            // 
            // btAddComment
            // 
            this.btAddComment.Location = new System.Drawing.Point(29, 108);
            this.btAddComment.Name = "btAddComment";
            this.btAddComment.Size = new System.Drawing.Size(75, 23);
            this.btAddComment.TabIndex = 0;
            this.btAddComment.Text = "Добавить";
            this.btAddComment.UseVisualStyleBackColor = true;
            this.btAddComment.Click += new System.EventHandler(this.btAddComment_Click);
            // 
            // btDeleteComment
            // 
            this.btDeleteComment.Location = new System.Drawing.Point(29, 137);
            this.btDeleteComment.Name = "btDeleteComment";
            this.btDeleteComment.Size = new System.Drawing.Size(75, 23);
            this.btDeleteComment.TabIndex = 1;
            this.btDeleteComment.Text = "Удалить";
            this.btDeleteComment.UseVisualStyleBackColor = true;
            this.btDeleteComment.Click += new System.EventHandler(this.btDeleteComment_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tbEmail);
            this.groupBox3.Controls.Add(this.btShare);
            this.groupBox3.Location = new System.Drawing.Point(183, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(151, 101);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Доступ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "E-mail";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(47, 29);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(94, 20);
            this.tbEmail.TabIndex = 2;
            // 
            // btShare
            // 
            this.btShare.Location = new System.Drawing.Point(22, 70);
            this.btShare.Name = "btShare";
            this.btShare.Size = new System.Drawing.Size(119, 23);
            this.btShare.TabIndex = 1;
            this.btShare.Text = "Открыть доступ";
            this.btShare.UseVisualStyleBackColor = true;
            this.btShare.Click += new System.EventHandler(this.btShare_Click);
            // 
            // lkLogout
            // 
            this.lkLogout.AutoSize = true;
            this.lkLogout.Location = new System.Drawing.Point(571, 9);
            this.lkLogout.Name = "lkLogout";
            this.lkLogout.Size = new System.Drawing.Size(39, 13);
            this.lkLogout.TabIndex = 10;
            this.lkLogout.TabStop = true;
            this.lkLogout.Text = "Выйти";
            this.lkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkLogout_LinkClicked);
            // 
            // lbComments
            // 
            this.lbComments.FormattingEnabled = true;
            this.lbComments.Location = new System.Drawing.Point(340, 39);
            this.lbComments.Name = "lbComments";
            this.lbComments.Size = new System.Drawing.Size(129, 212);
            this.lbComments.TabIndex = 11;
            // 
            // tcfiles
            // 
            this.tcfiles.Controls.Add(this.tbMyFile);
            this.tcfiles.Controls.Add(this.tbShares);
            this.tcfiles.Location = new System.Drawing.Point(1, 39);
            this.tcfiles.Name = "tcfiles";
            this.tcfiles.SelectedIndex = 0;
            this.tcfiles.Size = new System.Drawing.Size(180, 218);
            this.tcfiles.TabIndex = 12;
            this.tcfiles.SelectedIndexChanged += new System.EventHandler(this.tcfiles_SelectedIndexChanged);
            // 
            // tbMyFile
            // 
            this.tbMyFile.Controls.Add(this.lbFiles);
            this.tbMyFile.Location = new System.Drawing.Point(4, 22);
            this.tbMyFile.Name = "tbMyFile";
            this.tbMyFile.Padding = new System.Windows.Forms.Padding(3);
            this.tbMyFile.Size = new System.Drawing.Size(172, 192);
            this.tbMyFile.TabIndex = 0;
            this.tbMyFile.Text = "Мои файлы";
            this.tbMyFile.UseVisualStyleBackColor = true;
            // 
            // tbShares
            // 
            this.tbShares.Controls.Add(this.lbSharesFiles);
            this.tbShares.Location = new System.Drawing.Point(4, 22);
            this.tbShares.Name = "tbShares";
            this.tbShares.Padding = new System.Windows.Forms.Padding(3);
            this.tbShares.Size = new System.Drawing.Size(172, 192);
            this.tbShares.TabIndex = 1;
            this.tbShares.Text = "Доступные файлы";
            this.tbShares.UseVisualStyleBackColor = true;
            // 
            // lbSharesFiles
            // 
            this.lbSharesFiles.FormattingEnabled = true;
            this.lbSharesFiles.Location = new System.Drawing.Point(3, 3);
            this.lbSharesFiles.Name = "lbSharesFiles";
            this.lbSharesFiles.Size = new System.Drawing.Size(163, 186);
            this.lbSharesFiles.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 261);
            this.Controls.Add(this.tcfiles);
            this.Controls.Add(this.lbComments);
            this.Controls.Add(this.lkLogout);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbComments);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbUserNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(634, 300);
            this.MinimumSize = new System.Drawing.Size(634, 300);
            this.Name = "MainForm";
            this.Text = "DropBox";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbComments.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tcfiles.ResumeLayout(false);
            this.tbMyFile.ResumeLayout(false);
            this.tbShares.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAddFile;
        private System.Windows.Forms.Button btDeleteFile;
        private System.Windows.Forms.Button btDownloadFile;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Label lbUserNameLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbComments;
        private System.Windows.Forms.Button btAddComment;
        private System.Windows.Forms.Button btDeleteComment;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Button btShare;
        private System.Windows.Forms.LinkLabel lkLogout;
        private System.Windows.Forms.ListBox lbComments;
        private System.Windows.Forms.RichTextBox rbCommentText;
        public System.Windows.Forms.TabControl tcfiles;
        private System.Windows.Forms.TabPage tbMyFile;
        private System.Windows.Forms.TabPage tbShares;
        private System.Windows.Forms.ListBox lbSharesFiles;
        private System.Windows.Forms.Label label1;
    }
}

