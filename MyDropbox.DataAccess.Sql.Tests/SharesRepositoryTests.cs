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
        private const string ConnectionString = @"Data Source=WIN-P42TA030VHD;Initial Catalog=Dropbox;Integrated Security=True";
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
        private Share Share { get; set; }

        [TestInitialize]
        public void Init()
        {
            TestUser = _usersRepository.Add("Alex", "Ivanov", "test@test.com");

            var file = new File
            {
                Name = "testFile",
                Owner = TestUser
            };

            TestFile = _filesRepository.Add(file);
            Share = new Share()
            {
                File = TestFile,
                User = TestUser
            };
            _sharesRepository.Add(Share);
        }

        [TestCleanup]
        public void Clean()
        {
            if (TestUser != null)
            {
                foreach (var file in _filesRepository.GetUserFiles(TestUser.Id))
                {
                    _sharesRepository.Delete(Share);
                    _filesRepository.Delete(file.Id);
                }

                _usersRepository.Delete(TestUser.Id);
            }
        }

        [TestMethod]
        public void ShouldCreateAndGetShares()
        {
            Assert.AreEqual(Share.User.Id, TestUser.Id);
            Assert.AreEqual(Share.File.Id, TestFile.Id);
        }

        [TestMethod]
        public void ShouldDeleteShares()
        {
            _sharesRepository.Add(Share);
            _sharesRepository.Delete(Share);
            Assert.IsTrue(_sharesRepository.GetUserFiles(Share.User.Id).Count() == 0);
        }
    }
}
