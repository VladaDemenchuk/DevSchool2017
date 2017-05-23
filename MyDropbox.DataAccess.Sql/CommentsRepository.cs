using System;
using System.Collections.Generic;
using MyDropbox.Model;
using System.Data.SqlClient;

namespace MyDropbox.DataAccess.Sql
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly string _connectionString;
        private readonly IFilesRepository _filesRepository;
        private readonly IUsersRepository _usersRepository;

        public CommentsRepository(string connectionString, IUsersRepository usersRepository, IFilesRepository filesRepository)
        {
            _connectionString = connectionString;
            _filesRepository = filesRepository;
            _usersRepository = usersRepository;
        }

        public Comment Add(Comment comment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    Guid id = Guid.NewGuid();
                    DateTime date = DateTime.Now;
                    command.CommandText = "insert into Comments (Id, FileId,UserId, Text) values (@Id, @FileId, @UserId, @Text)";
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Text", comment.Text);
                    command.Parameters.AddWithValue("@FileId", comment.File.Id);
                    command.Parameters.AddWithValue("@UserId", comment.User.Id);
                    command.ExecuteNonQuery();
                    comment.Id = id;
                    return comment;
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
                    command.CommandText = "delete from Comments where Id = @id";
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Comment> GetComments(Guid fileId)
        {
            var result = new List<Comment>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select Id from Comments where FileId = @FileId";
                    command.Parameters.AddWithValue("@FileId", fileId);
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

        public void Edit(Guid id, string text)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "update Comments set Text = @Text where Id = @Id";
                    command.Parameters.AddWithValue("@Text", text);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Comment> GetFileComments(Guid fileId)
        {
            var result = new List<Comment>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select Id from Comments where FileId = @FileId";
                    command.Parameters.AddWithValue("@FileId", fileId);
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

        public Comment GetInfo(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select Id, FileId, UserId, Text from Comments where Id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Comment
                            {
                                Text = reader.GetString(reader.GetOrdinal("Text")),
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                File = _filesRepository.GetInfo(reader.GetGuid(reader.GetOrdinal("FileId"))),
                                User = _usersRepository.GetInfo(reader.GetGuid(reader.GetOrdinal("UserId")))
                            };
                        }
                        throw new ArgumentException($"comment {id} not found");
                    }
                }
            }
        }
    }
}
