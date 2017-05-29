using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDropbox.DataAccess;
using MyDropbox.DataAccess.Sql;
using MyDropbox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDropbox.DataAccess.Sql.Tests
{
    [TestClass]
    public class UsersRepositoryTests
    {

        private const string ConnectionString = @"Data Source=WIN-P42TA030VHD;Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private User TestUser { get; set; }

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
                _usersRepository.Delete(TestUser.Id);
            }
        }

        [TestMethod]
        public void ShouldCreateAndGetUser()
        {
            var result = _usersRepository.GetInfo(TestUser.Id);
            Assert.AreEqual(TestUser.Name, result.Name);
            Assert.AreEqual(TestUser.Surname, result.Surname);
            Assert.AreEqual(TestUser.Email, result.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldDeleteUser()
        {
            _usersRepository.Delete(TestUser.Id);
            var result = _usersRepository.GetInfo(TestUser.Id);
        }
    }
}
