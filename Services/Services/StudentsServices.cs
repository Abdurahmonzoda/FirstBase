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
    public class StudentsServices
    {
        private string _connectionString;
        public StudentsServices()
        {
            _connectionString = "Server = 127.0.0.1; Port = 5433; Database = School; User Id = postgres; Password = 45sD67ghone;";
        }
        public async Task<int> AddStudents(Students student)
        {
            // Add contact to database
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string sql = $"INSERT INTO Students (firstname, lastname, fathername,birthdate,id) VALUES ('{student.Firtname}', '{student.Lastname}', '{student.Fathername}', '{student.BirthDate}', '{student.Id}' )";
                var response = await connection.ExecuteAsync(sql);

                return response;
            }

        }
        public async Task<int> UpdateStudents(Students student)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"UPDATE  Students SET firstname = '{student.Firtname}', lastname = '{student.Lastname}', fathername = '{student.Fathername}', birthdate = '{student.BirthDate}', id = '{student.Id}' WHERE id = '{student.Id}'";
                var response = await connection.ExecuteAsync(sql);
                return response;
            }
        }
        public async Task<int> DeleteStudents(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"DELETE FROM Students WHERE id = '{id}'";
                var response = await connection.ExecuteAsync(sql);
                return response;
            }
        }
        public async Task<List<Students>> GetStudents()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Students";
                var list = await connection.QueryAsync<Students>(sql);
                return list.ToList();
            }
        }
    }
}
