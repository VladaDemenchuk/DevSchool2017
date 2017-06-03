using MyDropbox.DataAccess;
using MyDropbox.DataAccess.Sql;
using MyDropbox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyDropbox.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private const string ConnectionString = @"Data Source=WIN-P42TA030VHD;Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ISharesRepository _sharesRepository;

        public UsersController()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _sharesRepository = new SharesRepository(ConnectionString, _filesRepository);
        }

        [HttpPost]
        public User CreateUser([FromBody]User user)
        {
            return _usersRepository.Add(user.Name, user.Surname, user.Email);
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public User GetUser(Guid id)
        {
            return _usersRepository.GetInfo(id);
        }

        [Route("api/users/{id}/files")]
        [HttpGet]
        public IEnumerable<File> GetUserFiles(Guid id)
        {
            return _filesRepository.GetUserFiles(id);
        }

        [Route("api/users/{id}/sharings")]
        [HttpGet]
        public IEnumerable<File> GetUserSharesFiles(Guid id)
        {
            return _sharesRepository.GetUserFiles(id);
        }

        [HttpDelete]
        public void DeleteUser(Guid id)
        {
            //Log.Logger.ServiceLog.Info("Delete user with id: {0}", id);
            _usersRepository.Delete(id);
        }
    }
}

