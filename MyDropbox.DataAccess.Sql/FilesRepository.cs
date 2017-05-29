using System;
using System.Collections.Generic;
using MyDropbox.Model;
using System.Data.SqlClient;

namespace MyDropbox.DataAccess.Sql
{
    public class FilesRepository : IFilesRepository
    {

        private readonly string _connectionString;
        private readonly IUsersRepository _usersRepository;

        public FilesRepository(string connectionString, IUsersRepository usersRepository)
        {
            _connectionString = connectionString;
            _usersRepository = usersRepository;
        }

        public File Add(File file)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "insert into Files (Id, OwnerId, Name) values (@Id, @OwnerId, @Name)";
                    var fileId = Guid.NewGuid();
                    command.Parameters.AddWithValue("@Id", fileId);
                    command.Parameters.AddWithValue("@OwnerId", file.Owner.Id);
                    command.Parameters.AddWithValue("@Name", file.Name);
                    command.ExecuteNonQuery();
                    file.Id = fileId;
                    return file;
                }
            }
        }

        public byte[] GetContent(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select Content from Files where Id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            return reader.GetSqlBinary(reader.GetOrdinal("Content")).Value;
                        throw new ArgumentException($"file {id} not found");
                    }
                }
            }
        }

        public File GetInfo(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select Id, OwnerId, Name from Files where Id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new File
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("id")),
                                Owner = _usersRepository.GetInfo(reader.GetGuid(reader.GetOrdinal("ownerId"))),
                                Name = reader.GetString(reader.GetOrdinal("name"))
                            };
                        }
                        throw new ArgumentException("file not found");

                    }
                }
            }
        }

        public void UpdateContent(Guid id, byte[] content)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "update Files set Content = @Content Where Id = @Id";
                    command.Parameters.AddWithValue("@Content", content);
                    command.Parameters.AddWithValue("@Id", id);
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
                    command.CommandText = "select Id from Files where OwnerId = @OwnerId";
                    command.Parameters.AddWithValue("@OwnerId", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(GetInfo(reader.GetGuid(reader.GetOrdinal("Id"))));
                        }
                        return result;
                    }
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "delete from Files where Id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
