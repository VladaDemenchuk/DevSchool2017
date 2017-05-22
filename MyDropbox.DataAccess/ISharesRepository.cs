using MyDropbox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDropbox.DataAccess
{
    public interface ISharesRepository
    {
        void Add(Share share);
        void Delete(Share share);
        IEnumerable<File> GetUserFiles(Guid userId);
    }
}
