using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Hotel.Controllers
{
    public class SignupController : Controller
    {
        private readonly IConfiguration _configuration;
 
        public SignupController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(RegisteredUser registeredUser)
         {

            if (ModelState.IsValid)
            {
                string connectString = _configuration.GetConnectionString("Default");
                using (SqlConnection con = new SqlConnection(connectString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO RegisteredUser(Id, FirstName, LastName, EmailAddress, Password, DateTime) " +
                                      "VALUES (@Id, @FirstName, @LastName, @EmailAddress, @Password, @DateTime)";
                    cmd.Connection = con;

                    // Add parameters to the command
                    cmd.Parameters.AddWithValue("@Id", registeredUser.Id);
                    cmd.Parameters.AddWithValue("@FirstName", registeredUser.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", registeredUser.LastName);
                    cmd.Parameters.AddWithValue("@EmailAddress", registeredUser.EmailAddress);
                    cmd.Parameters.AddWithValue("@Password", registeredUser.Password);
                    cmd.Parameters.AddWithValue("@DateTime", registeredUser.RegisteredDate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        
        }
    }

