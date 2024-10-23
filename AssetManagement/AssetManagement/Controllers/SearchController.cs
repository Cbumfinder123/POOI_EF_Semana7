using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using AssetManagement.Models;

namespace AssetManagement.Controllers
{
    public class SearchController : Controller
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["AssetManagementDB"].ConnectionString;

        // GET: Search
        public ActionResult Index(string searchTerm)
        {
            List<SearchResult> results = new List<SearchResult>();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "EXEC SearchAssets @searchTerm";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@searchTerm", searchTerm);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(new SearchResult
                        {
                            FirstName = reader["first_name"].ToString(),
                            LastName = reader["last_name"].ToString(),
                            AssetName = reader["asset_name"].ToString(),
                            AssetTypeDescription = reader["asset_type_description"].ToString()
                        });
                    }
                }
            }

            return View(results);
        }
    }
}
