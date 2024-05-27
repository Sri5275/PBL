using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Microsoft.Data.SqlClient;

namespace SQLRepository
{
    public class StudentData : IStudentData
    {
        private readonly IDbConnection _connection;

        public StudentData(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }

        public async Task<List<StudentClass>> GetAllStudentsAsync()
        {
            List<StudentClass> student = new List<StudentClass>();
            _connection.Open();
            string query = "select id, username, email from students;";
            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    StudentClass studentClass = new StudentClass()
                    {
                        id = Convert.ToInt32(reader["id"]),
                        username = Convert.ToString(reader["username"]),
                        email = Convert.ToString(reader["email"])
                    };
                    student.Add(studentClass);
                }
            }
            return student;
        }

        public async Task<StudentClass> GetByStudentIdAsync(int id)
        {
            _connection.Open();
            string query = "select id, username, email from students where id=@id;";
            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
            command.Parameters.AddWithValue("@id", id);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    return new StudentClass()
                    {
                        id = Convert.ToInt32(reader["id"]),
                        username = Convert.ToString(reader["username"]),
                        email = Convert.ToString(reader["email"])
                    };
                }
            }
            return null;
        }

        public async Task<bool> UpdateStudentAsync(StudentClass student)
        {
            _connection.Open();
            string query = "UPDATE students SET username = @username, email = @emial WHERE id = @id;";
            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
            command.Parameters.AddWithValue("@id", student.id);
            command.Parameters.AddWithValue("@username", student.username);
            command.Parameters.AddWithValue("@email", student.email);

            int rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }

        public async Task<int> InsertStudentAsync(StudentClass student)
        {
            try
            {
                _connection.Open();
                string query = "INSERT INTO students (id, username, email) VALUES (@id, @username, @email);";
                SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
                object idParam = student.id != null ? (object)student.id : DBNull.Value;
                object usernameParam = !string.IsNullOrEmpty(student.username) ? (object)student.username : DBNull.Value;
                object emailParam = !string.IsNullOrEmpty(student.email) ? (object)student.email : DBNull.Value;
                command.Parameters.AddWithValue("@RollNumber", rollNumberParam);
                command.Parameters.AddWithValue("@StudentName", studentNameParam);
                command.Parameters.AddWithValue("@Department", departmentParam);
                int result = await command.ExecuteNonQueryAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                _connection.Close();
            }
            //return result != null ? Convert.ToInt32(result) : 0;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            _connection.Open();
            string query = "DELETE FROM students WHERE id = @id;";
            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
            command.Parameters.AddWithValue("@RollNumber", id);

            int rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }


        public async Task<List<StudentClass2>> GetAllStudentDataAsync()
        {
            List<StudentClass2> student2 = new List<StudentClass2>();
            _connection.Open();
            string query = "select id, username, email from students;";
            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    StudentClass2 studentClass2 = new StudentClass2()
                    {
                        id = Convert.ToInt32(reader["id"]),
                        username = Convert.ToString(reader["username"]),
                        email = Convert.ToString(reader["email"]),


                    };
                    student2.Add(studentClass2);
                }
            }
            return student2;
        }
    }
}
