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
    public class BooksServices
    {
        private string _connectionString;
        public BooksServices()
        {
            _connectionString = "Server = 127.0.0.1; Port = 5433; Database = School; User Id = postgres; Password = 45sD67ghone;";
        }
        public int AddBooks(Books book)
        {
            // Add contact to database
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string sql = $"INSERT INTO Books (title, authorid, id) VALUES ('{book.Title}', '{book.AuthorId}', '{book.Id}')";
                var response = connection.Execute(sql);

                return response;
            }

        }
        public int UpdateBooks(Books book)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"UPDATE  Books SET title = '{book.Title}', authorid = '{book.AuthorId}', id = '{book.Id}' WHERE id = '{book.Id}'";
                var response = connection.Execute(sql);
                return response;
            }
        }
        public int DeleteBooks(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"DELETE FROM Books WHERE id = '{id}'";
                var response = connection.Execute(sql);
                return response;
            }
        }
        public List<Books> GetBooks()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Books";
                var list = connection.Query<Books>(sql).ToList();
                return list;
            }
        }
    }
}

