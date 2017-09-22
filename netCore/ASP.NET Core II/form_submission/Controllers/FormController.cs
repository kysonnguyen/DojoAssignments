using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using form_submission.Models;

namespace form_submission.Controllers
{
    public class FormController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/create")]
        public IActionResult Create(string Fname, string Lname, int age, string email, string password){
            User NewUser = new User
        {
            Fname = Fname,
            Lname = Lname,
            Age = age, 
            Email = email,
            Password = password
        };

        TryValidateModel(NewUser);
        ViewBag.errors = ModelState.Values;
        if(ModelState.IsValid){
            return View("Success");
        }
        else{
            return View ("Index");
        }
        // if(ViewBag.errors){
        // }
        // else{
        //     return View("Success");
        //     }
        }
    }
}
