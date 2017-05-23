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
    public class SharesRepositoryTests
    {
        private const string ConnectionString = @"Data Source=DESKTOP-RH0RND7\SQLEXPRESS;Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ISharesRepository _sharesRepository;

        public SharesRepositoryTests()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _sharesRepository = new SharesRepository(ConnectionString, _filesRepository);
        }

        private User TestUser { get; set; }
        private File TestFile { get; set; }

        [TestInitialize]
        public void Init()
        {
            TestUser = _usersRepository.Add("Alex", "Ivanov", "test@test.com");

            var file = new File
            {
                Name = "testFile",
                Owner = TestUser
            };

            var TestFile = _filesRepository.Add(file);
        }

        [TestCleanup]
        public void Clean()
        {
            if (TestUser != null)
            {
                foreach (var file in _filesRepository.GetUserFiles(TestUser.Id))
                    _filesRepository.Delete(file.Id);
                _usersRepository.Delete(TestUser.Id);
            }
        }

        [TestMethod]
        public void ShouldCreateAndGetShares()
        {
            var share = new Share()
            {
                FileId = TestFile,
                UserId = TestUser
            };
            _sharesRepository.Add(share);
            Assert.AreEqual(share.UserId, TestUser.Id);
            Assert.AreEqual(share.FileId, TestFile.Id);
        }

        [TestMethod]
        public void ShouldDeleteShares()
        {
            var share = new Share()
            {
                FileId = TestFile,
                UserId = TestUser
            };
            _sharesRepository.Delete(share);
            Assert.IsNull(share.UserId);
            Assert.IsNull(share.FileId);
        }
    }
}
