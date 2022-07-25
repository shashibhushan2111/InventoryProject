using InventoryProject.Models;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;

namespace InventoryProject.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(RegistrationModel registrationModel)
        {
            using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Integrated Security=true;Initial Catalog=InventoryDB"))
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertDetail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", registrationModel.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", registrationModel.LastName);
                    cmd.Parameters.AddWithValue("@UserPassword", registrationModel.UserPassword);
                    cmd.Parameters.AddWithValue("@Gender", registrationModel.Gender);
                    cmd.Parameters.AddWithValue("@Email", registrationModel.Email);
                    cmd.Parameters.AddWithValue("@Phone", registrationModel.PhoneNumber);
                    cmd.Parameters.AddWithValue("@status", "INSERT");
                    con.Open();
                    ViewData["result"] = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return View("Success");
        }
    }
}
