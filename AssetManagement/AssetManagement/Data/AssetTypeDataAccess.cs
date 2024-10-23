using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class AssetTypeDataAccess
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["AssetManagementDB"].ConnectionString;

        public IEnumerable<AssetType> GetAllAssetTypes()
        {
            List<AssetType> assetTypes = new List<AssetType>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC GetAllAssetTypes";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    assetTypes.Add(new AssetType
                    {
                        AssetTypeId = (int)reader["asset_type_id"],
                        AssetTypeDescription = reader["asset_type_description"].ToString()
                    });
                }
            }

            return assetTypes;
        }

        public void AddAssetType(AssetType assetType)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC AddAssetType @asset_type_description";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@asset_type_description", assetType.AssetTypeDescription);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAssetType(AssetType assetType)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC UpdateAssetType @asset_type_id, @asset_type_description";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@asset_type_id", assetType.AssetTypeId);
                cmd.Parameters.AddWithValue("@asset_type_description", assetType.AssetTypeDescription);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAssetType(int assetTypeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "EXEC DeleteAssetType @asset_type_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@asset_type_id", assetTypeId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
