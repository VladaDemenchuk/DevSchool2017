using MyDropbox.DataAccess;
using MyDropbox.Model;
using System;
using System.Data.SqlClient;

namespace MyDropbox
{
    public class UsersRepository : IUsersRepository
    {
        private readonly string _connectionString;

        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User Add(string name, string surname, string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    var userId = Guid.NewGuid();
                    command.CommandText = "insert into Users (Id, Name, Surname, Email) values (@Id, @Name, @Surname, @Email)";
                    command.Parameters.AddWithValue("@Id", userId);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Surname", surname);
                    command.Parameters.AddWithValue("@Email", email);
                    command.ExecuteNonQuery();
                    return new User
                    {
                        Id = userId,
                        Email = email,
                        Name = name,
                        Surname = surname
                    };
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
                    command.CommandText = "delete from Users where Id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public User Get(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select Id, Name, Surname, Email from users where Id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Surname = reader.GetString(reader.GetOrdinal("Surname")),
                                Email = reader.GetString(reader.GetOrdinal("Email"))
                            };
                        }
                        throw new ArgumentException("user not found");
                    }
                }
            }
        }
    }
}

