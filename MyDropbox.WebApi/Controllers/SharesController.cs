using MyDropbox.DataAccess;
using MyDropbox.DataAccess.Sql;
using MyDropbox.Model;
using System.Web.Http;

namespace MyDropbox.WebApi.Controllers
{
    public class SharesController : ApiController
    {
        private const string ConnectionString = @"Data Source=WIN-P42TA030VHD;Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ISharesRepository _sharesRepository;

        public SharesController()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _sharesRepository = new SharesRepository(ConnectionString, _filesRepository);
        }

        [HttpPost]
        public void CreateShare(Share share)
        {
            _sharesRepository.Add(share);
        }

        [HttpDelete]
        public void DeleteShare(Share share)
        {
            _sharesRepository.Delete(share);
        }
    }
}
