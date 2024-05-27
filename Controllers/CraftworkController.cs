using Joshua_POE_CLDV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Joshua_POE_CLDV.Controllers
{
    public class CraftworkController : Controller
    {
        private readonly IConfiguration _configuration;

        public CraftworkController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var craftworks = new List<Craftwork>();
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Craftwork", conn);
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
            return View(craftworks);
        }
    }
}
