using Dapper;
using Domain.Dtos;
using Domain.Emtities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BooksServices
    {
        private string _connectionString;
        public BooksServices()
        {
            _connectionString = "Server = 127.0.0.1; Port = 5433; Database = School; User Id = postgres; Password = 45sD67ghone;";
        }
        public async Task<int> AddBooks(Books book)
        {
            // Add contact to database
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string sql = $"INSERT INTO Books (title, authorid, id) VALUES ('{book.Title}', '{book.AuthorId}', '{book.Id}')";
                var response = await connection.ExecuteAsync(sql);

                return response;
            }

        }
        public async Task<int> UpdateBooks(Books book)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"UPDATE  Books SET title = '{book.Title}', authorid = '{book.AuthorId}', id = '{book.Id}' WHERE id = '{book.Id}'";
                var response = await connection.ExecuteAsync(sql);
                return response;
            }
        }
        public async Task<int> DeleteBooks(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"DELETE FROM Books WHERE id = '{id}'";
                var response = await connection.ExecuteAsync(sql);
                return response;
            }
        }
        public async Task<List<Books>> GetBooks()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Books";
                var list = await connection.QueryAsync<Books>(sql);
                return list.ToList();
            }
        }
        public async Task <List<BookDto>> GetBooksDto()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT b.title as Title, b.id as Id, a.name as AuthorName FROM Books as b JOIN Authors as a ON b.id = a.id;";
                var list = await connection.QueryAsync<BookDto>(sql);
                return list.ToList();
            }
        }
    }
}

