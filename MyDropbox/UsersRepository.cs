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
                    command.CommandText = "insert into users (id, name, surname, email) values (@id, @name, @surname, @email)";
                    command.Parameters.AddWithValue("@id", userId);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@surname", surname);
                    command.Parameters.AddWithValue("email", email);
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
                    command.CommandText = "delete from users where id = @id";
                    command.Parameters.AddWithValue("@id", id);
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
                    command.CommandText = "select id, name, surname, email from users where id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new User
                            {
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                Id = reader.GetGuid(reader.GetOrdinal("id")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Surname = reader.GetString(reader.GetOrdinal("surname")),
                            };
                        }
                        throw new ArgumentException("user not found");
                    }
                }
            }
        }
    }
}

