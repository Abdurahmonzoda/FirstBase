using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Emtities;
using Npgsql;
using Dapper; 
namespace Services.Services
{
    public class ContactServices
    {
        private string _connectionString;
        public ContactServices()
        {
            _connectionString = "Server = 127.0.0.1; Port = 5433; Database = Contact; User Id = postgres; Password = 45sD67ghone;";
        }
        public int AddContact(Contact contact)
        {
            // Add contact to database
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string sql = $"INSERT INTO contact (name, phone, messange) VALUES ('{contact.Name}', '{contact.Phone}', '{contact.Messange}')";
                var response = connection.Execute(sql);

                return response;
            }

        }
        public int UpdateContact(Contact contact)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"UPDATE  contact SET name = '{contact.Name}', phone = '{contact.Phone}', messange = '{contact.Messange}' WHERE id = '{contact.Id}'";
                var response = connection.Execute(sql);
                return response;
            }
        }
        public int DeleteContact(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"DELETE FROM contact WHERE id = '{id}'";
                var response = connection.Execute(sql);
                return response;
            }
        }
        public List<Contact> GetContact()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM contact";
                var list = connection.Query<Contact>(sql).ToList();
                return list; 
            }
        }
    }
}
