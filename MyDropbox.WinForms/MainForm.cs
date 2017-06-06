using MyDropbox.Model;
using System;
using System.IO;
using System.Windows.Forms;

namespace MyDropbox.WinForms
{
    public partial class MainForm : Form
    {
        public const string url = "http://localhost:56829/api/";

        public MainForm(User user)
        {
            InitializeComponent();
            _client = new ServiceClient(url);
            _userId = _client.CreateUser(user);
        }

        public MainForm(Guid userId)
        {
            InitializeComponent();
            _client = new ServiceClient(url);
            _userId = _client.GetUser(userId).Id;
        }

        private readonly Guid _userId;

        private readonly ServiceClient _client;

        private void MainForm_Load(object sender, EventArgs e)
        {

            RefreshFileList();
            RefreshShareFileList();
            lbUserNameLabel.Text += _client.GetUser(_userId).Name;
            var shareItem = lbSharesFiles.SelectedItem as Model.File;
            if (lbFiles.Items.Count != 0)
            {
                var item = lbFiles.SelectedItem as Model.File;
                var fileId = item.Id;
                RefreshCommentList(fileId);
            }
            lbComments.Enabled = false;
            gbComments.Enabled = false;
        }

        private void RefreshFileList()
        {
            lbFiles.DataSource = _client.GetUserFiles(_userId);
        }

        private void RefreshCommentList(Guid fileId)
        {
            lbComments.DataSource = _client.GetFileComments(fileId);
        }

        private void RefreshShareFileList()
        {
            lbSharesFiles.DataSource = _client.GetUserAllowedFiles(_userId);
        }

        private void btAddFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new OpenFileDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var fileContent = System.IO.File.ReadAllBytes(dialog.FileName);
                        var file = new Model.File
                        {
                            Name = Path.GetFileName(dialog.FileName),
                            Owner = new User
                            {
                                Id = _userId
                            }
                        };
                        var fileId = _client.CreateFile(file);
                        _client.UploadFileContent(fileId, fileContent);
                        RefreshFileList();
                        MessageBox.Show($"Файл {file.Name} успешно загружен", "Загрузка файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось загрузить файл, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Comment listBoxItem in lbComments.Items)
                {
                    _client.DeleteComment(listBoxItem.Id);
                    RefreshCommentList(listBoxItem.File.Id);
                }

                var item = lbFiles.SelectedItem as Model.File;
                if (item != null)
                {
                    _client.DeleteFile(item.Id);
                    RefreshFileList();
                    MessageBox.Show($"Файл {item.Name} успешно удален", "Удаление файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось удалить файл, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDownloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                var item = lbFiles.SelectedItem as Model.File;
                var shateItem = lbSharesFiles.SelectedItem as Model.File;
                if (item != null && tcfiles.SelectedTab == tbMyFile)
                {
                    using (var dialog = new SaveFileDialog())
                    {
                        dialog.FileName = item.Name;
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            var content = _client.DownloadFile(item.Id);
                            System.IO.File.WriteAllBytes(dialog.FileName, content);
                        }
                    }
                }
                if (shateItem != null && tcfiles.SelectedTab == tbShares)
                {
                    using (var dialog = new SaveFileDialog())
                    {
                        dialog.FileName = shateItem.Name;
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            var content = _client.DownloadFile(shateItem.Id);
                            System.IO.File.WriteAllBytes(dialog.FileName, content);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось скачать файл, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btAddComment_Click(object sender, EventArgs e)
        {
            try
            {
                var item = lbSharesFiles.SelectedItem as Model.File;
                var fileId = item.Id;
                var comment = new Model.Comment
                {
                    Text = rbCommentText.Text,
                    File = _client.GetFile(fileId),
                    User = _client.GetUser(_userId)
                };

                _client.CreateComment(comment);
                RefreshCommentList(fileId);
                MessageBox.Show($"Комментарий  успешно добавлен", "Добавление комментария", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось добавить комментарий, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDeleteComment_Click(object sender, EventArgs e)
        {
            try
            {
                var item = lbComments.SelectedItem as Model.Comment;
                if (item != null)
                {
                    _client.DeleteComment(item.Id);
                    RefreshCommentList(item.File.Id);
                    MessageBox.Show($"комментарий успешно удален", "Удаление файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось удалить комментарий, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btShare_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _client.GetUser(tbEmail.Text);
                var item = lbFiles.SelectedItem as Model.File;
                var fileId = item.Id;
                var file = _client.GetFile(fileId);
                var share = new Model.Share
                {
                    File = file,
                    User = user
                };
                _client.CreateShare(share);
                MessageBox.Show($"Доступ к файлу {file} открыт пользователю {user}", "Открытие доступа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось открыть доступ пользователю c email {tbEmail.Text}, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form openForm = Application.OpenForms[0];
            openForm.Show();
        }

        private void lbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbFiles.Items.Count != 0 && lbComments.Items.Count != 0)
            {
                var item = lbSharesFiles.SelectedItem as Model.File;
                if (item != null)
                {
                    var fileId = item.Id;
                    RefreshCommentList(fileId);
                }

                var shareItem = lbComments.SelectedItem as Model.File;
                if (shareItem != null)
                {
                    var shareFileId = shareItem.Id;
                    RefreshCommentList(shareFileId);
                }
            }
        }

        private void tcfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcfiles.SelectedTab == tbShares)
            {
                btDeleteFile.Enabled = false;
                btAddFile.Enabled = false;
                var item = lbSharesFiles.SelectedItem as Model.File;
                if (item != null)
                {
                    var fileId = item.Id;
                    RefreshCommentList(fileId);
                }
                btAddFile.Enabled = false;
                lbComments.Enabled = true;
                gbComments.Enabled = true;
            }

            if (tcfiles.SelectedTab == tbMyFile)
            {
                btDeleteFile.Enabled = true;
                btAddFile.Enabled = true;
                lbComments.Enabled = false;
                gbComments.Enabled = false;
            }
        }
    }
}
