using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDropbox.WinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            _client = new ServiceClient("http://localhost:56829/api/");
        }

        private readonly ServiceClient _client;

        private void btSignIn_Click(object sender, EventArgs e)
        {
            var user = new Model.User
            {
                Name = tbUserLogin.Text,
                Email = tbUserEmail.Text,
                Surname = tbUserEmail.Text
            };
            if (user.Email == _client.GetUser(user.Email).Email)
            {
                MainForm form = new MainForm(_client.GetUser(user.Email).Id);
                form.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Данного аккаунта нет", "Вход", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btSignUp_Click(object sender, EventArgs e)
        {
            var user = new Model.User
            {
                Name = tbUserLogin.Text,
                Email = tbUserEmail.Text,
                Surname = tbUserEmail.Text
            };
            MainForm form = new MainForm(user);
            form.Show();
        }

        private void lkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            btSignUp.Visible = true;
            btSignIn.Visible = false;
            tbUserLogin.Visible = true;
            lbLogin.Visible = true;
            tbSurname.Visible = true;
            lbSurname.Visible = true;
            lkSignUp.Visible = false;
            lkSignIn.Visible = true;
        }

        private void lkSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbSurname.Visible = false;
            lbSurname.Visible = false;
            tbUserLogin.Visible = false;
            lbLogin.Visible = false;
            btSignIn.Visible = true;
            btSignUp.Visible = false;
            lkSignIn.Visible = false;
            lkSignUp.Visible = true;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
