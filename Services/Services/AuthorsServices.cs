using Dapper;
using Domain.Emtities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AuthorsServices
    {
        private string _connectionString;
        public AuthorsServices()
        {
            _connectionString = "Server = 127.0.0.1; Port = 5433; Database = School; User Id = postgres; Password = 45sD67ghone;";
        }
        public int AddAuthors(Authors author)
        {
            // Add contact to database
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string sql = $"INSERT INTO Authors (name, surname, id) VALUES ('{author.Name}', '{author.Surname}', '{author.Id}')";
                var response = connection.Execute(sql);

                return response;
            }

        }
        public int UpdateAuthors(Authors author)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"UPDATE  Authors SET name = '{author.Name}', surname = '{author.Surname}', id = '{author.Id}' WHERE id = '{author.Id}'";
                var response = connection.Execute(sql);
                return response;
            }
        }
        public int DeleteAuthors(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"DELETE FROM Authors WHERE id = '{id}'";
                var response = connection.Execute(sql);
                return response;
            }
        }
        public List<Authors> GetAuthors()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Authors";
                var list = connection.Query<Authors>(sql).ToList();
                return list;
            }
        }
    }
}
