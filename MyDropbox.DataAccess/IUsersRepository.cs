using MyDropbox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MyDropbox.DataAccess
{
    public interface IUsersRepository
    {
        User GetInfo(Guid id);
        User GetInfo(string email);
        void Delete(Guid id);
        User Add(string name, string surname, string email);
    }
}
