using MyDropbox.Model;
using System;
using System.Collections.Generic;

namespace MyDropbox.DataAccess
{
    public interface ICommentsRepository
    {
        Comment GetInfo(Guid fileId);
        Comment Add(Comment comment);
        void Delete(Guid id);
        IEnumerable<Comment> GetFileComments(Guid fileId);
    }
}
