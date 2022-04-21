using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace EmployeeTask2.Models
{
    public class EmployeesData
    {
        public string GetEmployeeFullNameById(int id)
        {
            Employee employee = null;
            using (SqlConnection sConnection = new SqlConnection(SQL.connection))
            {
                sConnection.Open();
                string query = "SELECT FullName FROM Employees WHERE Id=@id";
                SqlCommand command = new SqlCommand(query, sConnection);
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader sDataReader = command.ExecuteReader())
                {
                    while (sDataReader.Read())
                    {
                         employee = new Employee
                        {
                            FullName = sDataReader.GetString(1)
                        };
                    }
                }
            }
            return employee.FullName;
        }

        public List<string> GetEmployeeFullName()
        {
            Employee employee = null;

            List<String> employeesNames = new List<string>();
            using (SqlConnection sConnection = new SqlConnection(SQL.connection))
            {
                sConnection.Open();
                string query = "SELECT FullName FROM Employees";
                SqlCommand command = new SqlCommand(query, sConnection);

                using (SqlDataReader sDataReader = command.ExecuteReader())
                {
                    while (sDataReader.Read())
                    {
                        employee = new Employee
                        {
                            FullName = sDataReader.GetString(1)
                        };
                        employeesNames.Add(employee.FullName);
                    }
                }
            }
            return employeesNames;
        }

        public void AddEmployee(string fullName)
        {
            using (SqlConnection sConnection = new SqlConnection(SQL.connection))
            {
                sConnection.Open();
                string query = $"INSERT INTO Employees VALUES ('{fullName}')";
                SqlCommand command = new SqlCommand(query, sConnection);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection sConnection = new SqlConnection(SQL.connection))
            {
                sConnection.Open();
                string query = "DELETE FROM Employees WHERE Id=@id";
                SqlCommand command = new SqlCommand(query, sConnection);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
