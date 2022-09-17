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
        public async Task<int> AddAuthors(Authors author)
        {
            // Add contact to database
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string sql = $"INSERT INTO Authors (name, surname) VALUES ('{author.Name}', '{author.Surname}')";
                var response = await connection.ExecuteAsync(sql);

                return response;
            }

        }
        public async Task<int> UpdateAuthors(Authors author)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"UPDATE  Authors SET name = '{author.Name}', surname = '{author.Surname}' WHERE id = {author.Id}";
                var response = await connection.ExecuteAsync(sql);
                return response;
            }
        }
        public async Task<int> DeleteAuthors(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"DELETE FROM Authors WHERE id = '{id}'";
                var response =await connection.ExecuteAsync(sql);
                return response;
            }
        }
        public async Task<List<Authors>> GetAuthors()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Authors";
                var list = await connection.QueryAsync<Authors>(sql);
                return list.ToList();
            }
        }
    }
}
