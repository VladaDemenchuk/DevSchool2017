using MyDropbox.DataAccess;
using MyDropbox.DataAccess.Sql;
using MyDropbox.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyDropbox.WebApi.Controllers
{
    public class FilesController : ApiController
    {
        private const string ConnectionString = @"Data Source=WIN-P42TA030VHD;Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ICommentsRepository _commentsRepository;

        public FilesController()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _commentsRepository = new CommentsRepository(ConnectionString, _usersRepository, _filesRepository);
        }

        [HttpPost]
        public File CreateFile(File file)
        {
            return _filesRepository.Add(file);
        }

        [HttpGet]
        public File GetFileInfo(Guid id)
        {
            return _filesRepository.GetInfo(id);
        }

        [HttpGet]
        [Route("api/files/{id}/content")]
        public byte[] GetFileContent(Guid id)
        {
            return _filesRepository.GetContent(id);
        }


        [HttpGet]
        [Route("api/files/{id}/comments")]
        public IEnumerable<Comment> GetFileComments(Guid id)
        {
            return _commentsRepository.GetFileComments(id);
        }

        [HttpPut]
        [Route("api/files/{id}/content")]
        public async Task UpdateFileContent(Guid id)
        {
            var bytes = await Request.Content.ReadAsByteArrayAsync();
            _filesRepository.UpdateContent(id, bytes);
        }

        [HttpDelete]
        public void DeleteFile(Guid id)
        {
            _filesRepository.Delete(id);
        }

    }
}
