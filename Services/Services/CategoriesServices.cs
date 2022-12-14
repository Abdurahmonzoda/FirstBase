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
    public class CategoriesServices
    {
        private string _connectionString;
        public CategoriesServices()
        {
            _connectionString = "Server = 127.0.0.1; Port = 5433; Database = School; User Id = postgres; Password = 45sD67ghone;";
        }
        public async Task<int> AddCategories(Categories categorie)
        {
            // Add contact to database
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string sql = $"INSERT INTO Categories (name, id) VALUES ('{categorie.Name}', '{categorie.Id}')";
                var response = await connection.ExecuteAsync(sql);

                return response;
            }

        }
        public async Task<int> UpdateCategories(Categories categorie)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"UPDATE  Categories SET name = '{categorie.Name}', id = '{categorie.Id}' WHERE id = '{categorie.Id}'";
                var response = await connection.ExecuteAsync(sql);
                return response;
            }
        }
        public async Task<int> DeleteCategories(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"DELETE FROM Categories WHERE id = '{id}'";
                var response = await connection.ExecuteAsync(sql);
                return response;
            }
        }
        public async  Task<List<Categories>> GetCategories()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Categories";
                var list = await connection.QueryAsync<Categories>(sql);
                return list.ToList();
            }
        }
    }
}
