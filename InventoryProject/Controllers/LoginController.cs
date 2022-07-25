using InventoryProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;


namespace InventoryProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginModel loginModel)
        {
            using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Integrated Security=true;Initial Catalog=InventoryDB"))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Login", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email",loginModel.Email);
                    cmd.Parameters.AddWithValue("@UserPassword", loginModel.Password);
                    con.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if(sqlDataReader.Read())
                    {
                        LoginModel obj = new LoginModel();
                        obj.Email = sqlDataReader["Email"].ToString();
                        
                        return RedirectToAction("Welcome");
                    }
                    else
                    {
                        ViewData["Message"] = "user login details failed";
                    }
                    con.Close();
                }
            }
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }
    }
}
