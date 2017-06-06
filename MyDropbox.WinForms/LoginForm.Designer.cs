namespace MyDropbox.WinForms
{
    partial class LoginForm
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
            this.btSignIn = new System.Windows.Forms.Button();
            this.tbUserLogin = new System.Windows.Forms.TextBox();
            this.tbUserEmail = new System.Windows.Forms.TextBox();
            this.btSignUp = new System.Windows.Forms.Button();
            this.lbLogin = new System.Windows.Forms.Label();
            this.lbUserMail = new System.Windows.Forms.Label();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.lbSurname = new System.Windows.Forms.Label();
            this.lkSignUp = new System.Windows.Forms.LinkLabel();
            this.lkSignIn = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btSignIn
            // 
            this.btSignIn.Location = new System.Drawing.Point(69, 123);
            this.btSignIn.Name = "btSignIn";
            this.btSignIn.Size = new System.Drawing.Size(139, 23);
            this.btSignIn.TabIndex = 0;
            this.btSignIn.Text = "Войти";
            this.btSignIn.UseVisualStyleBackColor = true;
            this.btSignIn.Click += new System.EventHandler(this.btSignIn_Click);
            // 
            // tbUserLogin
            // 
            this.tbUserLogin.Location = new System.Drawing.Point(69, 31);
            this.tbUserLogin.Name = "tbUserLogin";
            this.tbUserLogin.Size = new System.Drawing.Size(139, 20);
            this.tbUserLogin.TabIndex = 1;
            this.tbUserLogin.Visible = false;
            // 
            // tbUserEmail
            // 
            this.tbUserEmail.Location = new System.Drawing.Point(69, 83);
            this.tbUserEmail.Name = "tbUserEmail";
            this.tbUserEmail.Size = new System.Drawing.Size(139, 20);
            this.tbUserEmail.TabIndex = 2;
            // 
            // btSignUp
            // 
            this.btSignUp.Location = new System.Drawing.Point(69, 152);
            this.btSignUp.Name = "btSignUp";
            this.btSignUp.Size = new System.Drawing.Size(139, 23);
            this.btSignUp.TabIndex = 3;
            this.btSignUp.Text = "Зарегистрироваться";
            this.btSignUp.UseVisualStyleBackColor = true;
            this.btSignUp.Visible = false;
            this.btSignUp.Click += new System.EventHandler(this.btSignUp_Click);
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Location = new System.Drawing.Point(12, 34);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(29, 13);
            this.lbLogin.TabIndex = 4;
            this.lbLogin.Text = "Имя";
            this.lbLogin.Visible = false;
            // 
            // lbUserMail
            // 
            this.lbUserMail.AutoSize = true;
            this.lbUserMail.Location = new System.Drawing.Point(12, 86);
            this.lbUserMail.Name = "lbUserMail";
            this.lbUserMail.Size = new System.Drawing.Size(35, 13);
            this.lbUserMail.TabIndex = 5;
            this.lbUserMail.Text = "E-mail";
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(69, 57);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(139, 20);
            this.tbSurname.TabIndex = 6;
            this.tbSurname.Visible = false;
            // 
            // lbSurname
            // 
            this.lbSurname.AutoSize = true;
            this.lbSurname.Location = new System.Drawing.Point(12, 60);
            this.lbSurname.Name = "lbSurname";
            this.lbSurname.Size = new System.Drawing.Size(56, 13);
            this.lbSurname.TabIndex = 7;
            this.lbSurname.Text = "Фамилия";
            this.lbSurname.Visible = false;
            // 
            // lkSignUp
            // 
            this.lkSignUp.AutoSize = true;
            this.lkSignUp.Location = new System.Drawing.Point(98, 178);
            this.lkSignUp.Name = "lkSignUp";
            this.lkSignUp.Size = new System.Drawing.Size(72, 13);
            this.lkSignUp.TabIndex = 8;
            this.lkSignUp.TabStop = true;
            this.lkSignUp.Text = "Регистрация";
            this.lkSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkSignUp_LinkClicked);
            // 
            // lkSignIn
            // 
            this.lkSignIn.AutoSize = true;
            this.lkSignIn.Location = new System.Drawing.Point(116, 191);
            this.lkSignIn.Name = "lkSignIn";
            this.lkSignIn.Size = new System.Drawing.Size(31, 13);
            this.lkSignIn.TabIndex = 9;
            this.lkSignIn.TabStop = true;
            this.lkSignIn.Text = "Вход";
            this.lkSignIn.Visible = false;
            this.lkSignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkSignIn_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 211);
            this.Controls.Add(this.lkSignIn);
            this.Controls.Add(this.lkSignUp);
            this.Controls.Add(this.lbSurname);
            this.Controls.Add(this.tbSurname);
            this.Controls.Add(this.lbUserMail);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.btSignUp);
            this.Controls.Add(this.tbUserEmail);
            this.Controls.Add(this.tbUserLogin);
            this.Controls.Add(this.btSignIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSignIn;
        private System.Windows.Forms.TextBox tbUserLogin;
        private System.Windows.Forms.TextBox tbUserEmail;
        private System.Windows.Forms.Button btSignUp;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Label lbUserMail;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.Label lbSurname;
        private System.Windows.Forms.LinkLabel lkSignUp;
        private System.Windows.Forms.LinkLabel lkSignIn;
    }
}