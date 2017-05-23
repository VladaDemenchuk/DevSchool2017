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
    public class FilesRepositoryTests
    {
        private const string ConnectionString = @"Data Source=DESKTOP-RH0RND7\SQLEXPRESS;Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;

        private User TestUser { get; set; }

        public FilesRepositoryTests()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
        }

        [TestInitialize]
        public void Init()
        {
            TestUser = _usersRepository.Add("Alex", "Ivanov", "test@test.com");
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
        public void ShouldCreateAndGetFile()
        {
            var file = new File
            {
                Name = "testFile",
                Owner = TestUser
            };
            var newFile = _filesRepository.Add(file);
            var result = _filesRepository.GetInfo(newFile.Id);
            Assert.AreEqual(file.Owner.Id, result.Owner.Id);
            Assert.AreEqual(file.Name, result.Name);
        }

        [TestMethod]
        public void ShoulUpdateAndGetFileContent()
        {
            var file = new File
            {
                Name = "file with content",
                Owner = TestUser
            };
            var content = Encoding.UTF8.GetBytes("Hello");
            var newFile = _filesRepository.Add(file);
            _filesRepository.UpdateContent(newFile.Id, content);
            var resultContent = _filesRepository.GetContent(newFile.Id);
            Assert.IsTrue(content.SequenceEqual(resultContent));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldDeleteFile()
        {
            var file = new File
            {
                Name = "testFile",
                Owner = TestUser
            };

            var newFile = _filesRepository.Add(file);
            _filesRepository.Delete(newFile.Id);
            var result = _filesRepository.GetInfo(newFile.Id);
        }

        [TestMethod]
        public void ShoulGetUserFiles()
        {
            var file1 = new File
            {
                Name = "file1",
                Owner = TestUser
            };

            var file2 = new File
            {
                Name = "file2",
                Owner = TestUser
            };
            List<File> files = new List<File>();
            files.Add(file1);
            files.Add(file2);
            var newFile1 = _filesRepository.Add(file1);
            var newFile2 = _filesRepository.Add(file2);
            var result = _filesRepository.GetUserFiles(TestUser.Id);
            foreach (var res in result)
            {
                int i = files.FindIndex(p => p.Id == res.Id);
                Assert.AreEqual(files[i].Name, res.Name);
                Assert.AreEqual(files[i].Owner.Id, res.Owner.Id);
            }
            Assert.AreEqual(result.Count(), 2);
        }
    }
}
