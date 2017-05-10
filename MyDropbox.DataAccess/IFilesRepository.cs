using MyDropbox.Model;
using System;
using System.Collections.Generic;

namespace MyDropbox.DataAccess
{
    public interface IFilesRepository
    {
        File Add(File file);
        void Delete(Guid id);
        void UpdateContent(Guid id, byte[] content);
        File GetInfo(Guid id);
        byte[] GetContent(Guid id);
        IEnumerable<File> GetUserFiles(Guid id);
    }
}
