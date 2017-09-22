using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using log_reg.Models;

namespace log_reg.Controllers
{
    public class LogregController : Controller
    {   
        private readonly DbConnector _dbConnector;
 
        public LogregController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/register")]
        public IActionResult Register(User user){
            if(ModelState.IsValid){
                string query = $"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Password}', NOW(), NOW());";
                _dbConnector.Execute(query);
                query = $"SELECT * FROM users WHERE email = '{user.Email}' AND password = '{user.Password}';";
                var reg_user = _dbConnector.Query(query);
                ViewBag.user = reg_user;
                return View ("Success");
            }
            else{
                return View ("Index");
            }
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(string email, string password){
            string query = $"SELECT * FROM users WHERE email = '{email}' AND password = '{password}';";
            var reg_user = _dbConnector.Query(query);
            if(reg_user.Count > 0){
                ViewBag.user = reg_user;
                return View("Success");
            }
            else{
                ViewBag.Error = "Not Found";
                return View("Index");
            }
        }


    }
}
