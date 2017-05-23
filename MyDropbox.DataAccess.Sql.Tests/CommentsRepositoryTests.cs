using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDropbox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDropbox.DataAccess.Sql.Tests
{
    [TestClass]
    public class CommentsRepositoryTests
    {
        private const string ConnectionString = @"Data Source=DESKTOP-RH0RND7\SQLEXPRESS;Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ICommentsRepository _commentsRepository;

        private User TestUser { get; set; }
        private File TestFile { get; set; }

        public CommentsRepositoryTests()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _commentsRepository = new CommentsRepository(ConnectionString, _usersRepository, _filesRepository);
        }

        [TestInitialize]
        public void Init()
        {
            if (TestUser != null)
            {
                foreach (var file in _filesRepository.GetUserFiles(TestUser.Id))
                    _filesRepository.Delete(file.Id);
                _usersRepository.Delete(TestUser.Id);
            }
            TestUser = _usersRepository.Add("Alex", "Ivanov", "test@test.com");
            TestFile = new File
            {
                Name = "file1",
                Owner = TestUser
            };
            var newFile = _filesRepository.Add(TestFile);
        }

        [TestCleanup]
        public void Clean()
        {
            if (TestUser != null)
            {
                foreach (var file in _filesRepository.GetUserFiles(TestUser.Id))
                {
                    foreach (var comment in _commentsRepository.GetFileComments(file.Id))
                        _commentsRepository.Delete(comment.Id);

                    _filesRepository.Delete(file.Id);
                }
                _usersRepository.Delete(TestUser.Id);
            }
        }

        [TestMethod]
        public void ShouldCreateAndGetComment()
        {
            var comment = new Comment
            {
                File = TestFile,
                User = TestUser,
                Text = "Good"
            };
            var newComment = _commentsRepository.Add(comment);
            var result = _commentsRepository.GetInfo(newComment.Id);
            Assert.AreEqual(newComment.Id, result.Id);
            Assert.AreEqual(newComment.File.Id, result.File.Id);
            Assert.AreEqual(newComment.User.Id, result.User.Id);
            Assert.AreEqual(newComment.Text, result.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldDeleteComment()
        {
            var comment = new Comment
            {
                File = TestFile,
                User = TestUser,
                Text = "Good"
            };

            var newComment = _commentsRepository.Add(comment);
            _commentsRepository.Delete(newComment.Id);
            var result = _commentsRepository.GetInfo(newComment.Id);
        }


        [TestMethod]
        public void ShouldGetFileComments()
        {
            List<Comment> comments = new List<Comment>();
            var comment1 = new Comment
            {
                File = TestFile,
                User = TestUser,
                Text = "New comment 1"
            };
            var comment2 = new Comment
            {
                File = TestFile,
                User = TestUser,
                Text = "New comment 1"
            };

            comments.Add(comment1);
            comments.Add(comment2);

            var newComment1 = _commentsRepository.Add(comments[0]);
            var newComment2 = _commentsRepository.Add(comments[1]);
            var result = (List<Comment>)_commentsRepository.GetFileComments(TestFile.Id);

            foreach (var res in result)
            {
                int i = comments.FindIndex(p => p.Id == res.Id);
                Assert.AreEqual(comments[i].Text, res.Text);
                Assert.AreEqual(comments[i].User.Id, res.User.Id);
                Assert.AreEqual(comments[i].File.Id, res.File.Id);
            }
        }
    }
}
