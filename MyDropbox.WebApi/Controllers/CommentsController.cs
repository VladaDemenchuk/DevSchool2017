﻿using MyDropbox.DataAccess;
using MyDropbox.DataAccess.Sql;
using MyDropbox.Model;
using System;
using System.Web.Http;

namespace MyDropbox.WebApi.Controllers
{
    public class CommentsController : ApiController
    {
        private const string ConnectionString = @"Data Source=WIN-P42TA030VHD;Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ICommentsRepository _commentsRepository;

        public CommentsController()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _commentsRepository = new CommentsRepository(ConnectionString, _usersRepository, _filesRepository);
        }

        [HttpPost]
        public Comment CreateComment([FromBody]Comment comment)
        {
            return _commentsRepository.Add(comment);
        }

        [HttpGet]
        [Route("api/comments/{id}")]
        public Comment GetComment(Guid id)
        {
            return _commentsRepository.GetInfo(id);
        }

        [HttpDelete]
        public void DeleteComment(Guid id)
        {
            _commentsRepository.Delete(id);
        }
    }
}
