using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Joshua_POE_CLDV.Models
{
    public class Table_1 : Controller
    {
        public static string con_String = "Server = tcp:joshua-poe-cldv-server.database.windows.net,1433;Initial Catalog = joshua - poe - cdlv; Persist Security Info=False;User ID = Joshua; Password={your_password\r\n    }; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30"; 
        public static SqlConnection con = new SqlConnection(con_String);

        public String Name { get; set; }
        public String Surname {  get; set; } 
        public String Email { get; set; } 

        public int InsertUser(Table_1 n)
        {
            string sql = "insert into Table_1 (user_Name, user_Surname, user_Email) VALUES (@Name, @Surname, @Email)";
            SqlCommand cmd = new SqlCommand(sql, con); 
            cmd.Parameters.AddWithValue("@Name", n.Name);
            cmd.Parameters.AddWithValue("@Surname", n.Surname);
            cmd.Parameters.AddWithValue("@Email", n.Email);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }
    }
}
