using AssetManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AssetManagement.Data
{
    public class ITAssetInventoryDataAccess
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["AssetManagementDB"].ConnectionString;

        public IEnumerable<ITAssetInventory> GetAllITAssetInventories()
        {
            List<ITAssetInventory> inventories = new List<ITAssetInventory>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllITAssetInventories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    inventories.Add(new ITAssetInventory
                    {
                        it_asset_inventory_id = Convert.ToInt32(reader["it_asset_inventory_id"]),
                        asset_id = Convert.ToInt32(reader["asset_id"]),
                        inventory_date = Convert.ToDateTime(reader["inventory_date"]),
                        number_assigned = Convert.ToInt32(reader["number_assigned"]),
                        number_in_stock = Convert.ToInt32(reader["number_in_stock"]),
                        other_details = reader["other_details"].ToString()
                    });
                }
            }
            return inventories;
        }

        public void AddITAssetInventory(ITAssetInventory inventory)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddITAssetInventory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@asset_id", inventory.asset_id);
                cmd.Parameters.AddWithValue("@inventory_date", inventory.inventory_date);
                cmd.Parameters.AddWithValue("@number_assigned", inventory.number_assigned);
                cmd.Parameters.AddWithValue("@number_in_stock", inventory.number_in_stock);
                cmd.Parameters.AddWithValue("@other_details", inventory.other_details ?? (object)DBNull.Value);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



        public void UpdateITAssetInventory(ITAssetInventory inventory)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateITAssetInventory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@it_asset_inventory_id", inventory.it_asset_inventory_id);
                cmd.Parameters.AddWithValue("@asset_id", inventory.asset_id);
                cmd.Parameters.AddWithValue("@inventory_date", inventory.inventory_date);
                cmd.Parameters.AddWithValue("@number_assigned", inventory.number_assigned);
                cmd.Parameters.AddWithValue("@number_in_stock", inventory.number_in_stock);
                cmd.Parameters.AddWithValue("@other_details", inventory.other_details ?? (object)DBNull.Value);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteITAssetInventory(int it_asset_inventory_id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteITAssetInventory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@it_asset_inventory_id", it_asset_inventory_id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
