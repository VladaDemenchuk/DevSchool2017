using System;
using System.Collections.Generic;
using MyDropbox.Model;
using System.Data.SqlClient;

namespace MyDropbox.DataAccess.Sql
{
    public class SharesRepository : ISharesRepository
    {
        private readonly string _connectionString;
        private readonly IFilesRepository _filesRepository;

        public SharesRepository(string connectionString, IFilesRepository filesRepository)
        {
            _connectionString = connectionString;
            _filesRepository = filesRepository;
        }

        public void Add(Share share)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "insert into Shares (FileId, UserId) values (@FileId, @UserId)";
                    command.Parameters.AddWithValue("@FileId", share.File.Id);
                    command.Parameters.AddWithValue("@UserId", share.User.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Share share)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "delete from Shares where FileId = @FileId and UserId = @UserId";
                    command.Parameters.AddWithValue("@FileId", share.File.Id);
                    command.Parameters.AddWithValue("@UserId", share.User.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<File> GetUserFiles(Guid userId)
        {
            var result = new List<File>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select FileId from Shares where UserId = @UserId";
                    command.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(_filesRepository.GetInfo(reader.GetGuid(reader.GetOrdinal("FileId"))));
                        }
                        return result;
                    }
                }
            }
        }
    }
}
