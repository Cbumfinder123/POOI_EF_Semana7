using AssetManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace AssetManagement.Data
{
    public class EmployeeDataAccess
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["AssetManagementDB"].ConnectionString;

        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        employee_id = Convert.ToInt32(reader["employee_id"]),
                        first_name = reader["first_name"].ToString(),
                        last_name = reader["last_name"].ToString(),
                        departament = reader["departament"].ToString(),
                        extension = reader["extension"] != DBNull.Value ? reader["extension"].ToString() : null, 
                        email_address = reader["email_address"].ToString(),
                        other_details = reader["other_details"] != DBNull.Value ? reader["other_details"].ToString() : null 
                    });
                }
            }
            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@first_name", employee.first_name);
                cmd.Parameters.AddWithValue("@last_name", employee.last_name);
                cmd.Parameters.AddWithValue("@departament", employee.departament);
                cmd.Parameters.AddWithValue("@extension", employee.extension);
                cmd.Parameters.AddWithValue("@email_address", employee.email_address);
                cmd.Parameters.AddWithValue("@other_details", employee.other_details ?? (object)DBNull.Value);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }




        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employee_id", employee.employee_id);
                cmd.Parameters.AddWithValue("@first_name", employee.first_name);
                cmd.Parameters.AddWithValue("@last_name", employee.last_name);
                cmd.Parameters.AddWithValue("@departament", employee.departament);
                cmd.Parameters.AddWithValue("@extension", employee.extension);
                cmd.Parameters.AddWithValue("@email_address", employee.email_address);
                cmd.Parameters.AddWithValue("@other_details", employee.other_details);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



        public void DeleteEmployee(int employee_id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employee_id", employee_id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
