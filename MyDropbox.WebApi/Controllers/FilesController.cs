using MyDropbox.DataAccess;
using MyDropbox.DataAccess.Sql;
using MyDropbox.Log;
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
            Logger.ServiceLog.Info("Create file with id: {0}", file.Id);
            return _filesRepository.Add(file);
        }

        [HttpGet]
        [Route("api/files/{id}")]
        public File GetFileInfo(Guid id)
        {
            Logger.ServiceLog.Fatal("Get file with id: {0}", id);
            return _filesRepository.GetInfo(id);
        }

        [HttpGet]
        [Route("api/files/{id}/content")]
        public byte[] GetFileContent(Guid id)
        {
            Logger.ServiceLog.Info("Get file content with id: {0}", id);
            return _filesRepository.GetContent(id);
        }


        [HttpGet]
        [Route("api/files/{id}/comments")]
        public IEnumerable<Comment> GetFileComments(Guid id)
        {
            Logger.ServiceLog.Info("Get file comments with id: {0}", id);
            return _commentsRepository.GetFileComments(id);
        }

        [HttpPut]
        [Route("api/files/{id}/content")]
        public async Task UpdateFileContent(Guid id)
        {
            var bytes = await Request.Content.ReadAsByteArrayAsync();
            Logger.ServiceLog.Info("Update file content with id: {0}", id);
            _filesRepository.UpdateContent(id, bytes);
        }

        [HttpDelete]
        [Route("api/files/{id}")]
        public void DeleteFile(Guid id)
        {
            Logger.ServiceLog.Info("Delete file with id: {0}", id);
            _filesRepository.Delete(id);
        }
    }
}
