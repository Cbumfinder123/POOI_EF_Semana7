using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class ITAssetDataAccess
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["AssetManagementDB"].ConnectionString;

        public IEnumerable<ITAsset> GetAllITAssets()
        {
            List<ITAsset> itAssets = new List<ITAsset>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC GetAllITAssets";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    itAssets.Add(new ITAsset
                    {
                        asset_id = (int)reader["asset_id"],
                        asset_type_id = (int)reader["asset_type_id"],
                        asset_name = reader["asset_name"].ToString(),
                        description = reader["description"].ToString(),
                        other_details = reader["other_details"].ToString()
                    });
                }
            }

            return itAssets;
        }

        public void AddITAsset(ITAsset itAsset)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC AddITAsset @asset_type_id, @asset_name, @description, @other_details";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@asset_type_id", itAsset.asset_type_id);
                cmd.Parameters.AddWithValue("@asset_name", itAsset.asset_name);
                cmd.Parameters.AddWithValue("@description", itAsset.description);
                cmd.Parameters.AddWithValue("@other_details", itAsset.other_details ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateITAsset(ITAsset itAsset)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC UpdateITAsset @asset_id, @asset_type_id, @asset_name, @description, @other_details";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@asset_id", itAsset.asset_id);
                cmd.Parameters.AddWithValue("@asset_type_id", itAsset.asset_type_id);
                cmd.Parameters.AddWithValue("@asset_name", itAsset.asset_name);
                cmd.Parameters.AddWithValue("@description", itAsset.description);
                cmd.Parameters.AddWithValue("@other_details", itAsset.other_details ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteITAsset(int asset_id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC DeleteITAsset @asset_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@asset_id", asset_id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
