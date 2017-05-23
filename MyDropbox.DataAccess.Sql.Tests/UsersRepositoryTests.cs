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

        private const string ConnectionString = @"Data Source=DESKTOP-RH0RND7\SQLEXPRESS;Initial Catalog=Dropbox;Integrated Security=True";
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
            var newUser = _usersRepository.Add(TestUser.Name, TestUser.Surname, TestUser.Email);
            var result = _usersRepository.GetInfo(newUser.Id);
            Assert.AreEqual(newUser.Name, result.Name);
            Assert.AreEqual(newUser.Surname, result.Surname);
            Assert.AreEqual(newUser.Email, result.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldDeleteUser()
        {
            var newUser = _usersRepository.Add(TestUser.Name, TestUser.Surname, TestUser.Email);
            _usersRepository.Delete(newUser.Id);
            var result = _usersRepository.GetInfo(newUser.Id);
        }
    }
}
