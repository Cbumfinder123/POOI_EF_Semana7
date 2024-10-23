using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class EmployeeAssetDataAccess
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["AssetManagementDB"].ConnectionString;

        public IEnumerable<EmployeeAsset> GetAllEmployeeAssets()
        {
            List<EmployeeAsset> employeeAssets = new List<EmployeeAsset>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC GetAllEmployeeAssets";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employeeAssets.Add(new EmployeeAsset
                    {
                        AssetId = (int)reader["asset_id"],
                        EmployeeId = (int)reader["employee_id"],
                        DateOut = (DateTime)reader["date_out"],
                        DateReturned = reader["date_returned"] as DateTime?,
                        ConditionOut = reader["condition_out"].ToString(),
                        ConditionReturned = reader["condition_returned"].ToString(),
                        OtherDetails = reader["other_details"].ToString()
                    });
                }
            }

            return employeeAssets;
        }

        public void AddEmployeeAsset(EmployeeAsset employeeAsset)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC AddEmployeeAsset @asset_id, @employee_id, @date_out, @date_returned, @condition_out, @condition_returned, @other_details";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@asset_id", employeeAsset.AssetId);
                cmd.Parameters.AddWithValue("@employee_id", employeeAsset.EmployeeId);
                cmd.Parameters.AddWithValue("@date_out", employeeAsset.DateOut);
                cmd.Parameters.AddWithValue("@date_returned", employeeAsset.DateReturned ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@condition_out", employeeAsset.ConditionOut ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@condition_returned", employeeAsset.ConditionReturned ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@other_details", employeeAsset.OtherDetails ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployeeAsset(EmployeeAsset employeeAsset)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC UpdateEmployeeAsset @asset_id, @employee_id, @date_out, @date_returned, @condition_out, @condition_returned, @other_details";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@asset_id", employeeAsset.AssetId);
                cmd.Parameters.AddWithValue("@employee_id", employeeAsset.EmployeeId);
                cmd.Parameters.AddWithValue("@date_out", employeeAsset.DateOut);
                cmd.Parameters.AddWithValue("@date_returned", employeeAsset.DateReturned ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@condition_out", employeeAsset.ConditionOut ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@condition_returned", employeeAsset.ConditionReturned ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@other_details", employeeAsset.OtherDetails ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployeeAsset(int assetId, int employeeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC DeleteEmployeeAsset @asset_id, @employee_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@asset_id", assetId);
                cmd.Parameters.AddWithValue("@employee_id", employeeId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
