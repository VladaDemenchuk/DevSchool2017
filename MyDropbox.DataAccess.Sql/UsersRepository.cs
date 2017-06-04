using MyDropbox.Log;
using MyDropbox.Model;
using System;
using System.Data.SqlClient;

namespace MyDropbox.DataAccess.Sql
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
                try
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        var id = Guid.NewGuid();
                        command.CommandText = "insert into Users (Id, Name, Surname, Email) values (@Id, @Name, @Surname, @Email)";
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Surname", surname);
                        command.Parameters.AddWithValue("@Email", email);
                        command.ExecuteNonQuery();
                        return new User
                        {
                            Id = id,
                            Email = email,
                            Name = name,
                            Surname = surname
                        };
                    }
                }
                catch (SqlException ex)
                {
                    Logger.ServiceLog.Fatal("Подключение к бд не установлено");
                    throw ex;
                }
            }
        }


        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "delete from Users where Id = @Id";
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Logger.ServiceLog.Fatal("Подключение к бд не установлено");
                    throw ex;
                }
            }
        }

        public User GetInfo(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select Id, Name, Surname, Email from Users where Id = @Id";
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
                        Log.Logger.ServiceLog.Error("Пользователь с id {0} не найден", id);
                        throw new ArgumentException("user not found");
                    }
                }
            }
        }
    }
}
