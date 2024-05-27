using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Joshua_POE_CLDV.Models
{
    public class Craftwork 
    {
        public static string con_String = "Server = tcp:joshua-poe-cldv-server.database.windows.net,1433;Initial Catalog = joshua - poe - cdlv; Persist Security Info=False;User ID = Joshua; Password={your_password\r\n    }; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";
        public static SqlConnection con = new SqlConnection(con_String);
        private readonly IConfiguration _configuration;

        public Craftwork(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public List<Craftwork> Search(string query)
        {
            var craftworks = new List<Craftwork>();
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Craftwork WHERE Name LIKE @query", conn);
                cmd.Parameters.AddWithValue("@query", "%" + query + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    craftworks.Add(new Craftwork(_configuration)
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = (decimal)reader["Price"],
                        ImageUrl = reader["ImageUrl"].ToString()
                    });
                }
            }
            return craftworks;
        }


    }
}
