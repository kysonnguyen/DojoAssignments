using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using restauranter.Models;

namespace restauranter.Controllers
{
    public class RestauranterController : Controller
    {
        private MyContext ctx;
 
        public RestauranterController(MyContext context)
        {
            ctx = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/Add")]
        public IActionResult Add(Review info)
        {
            ctx.Add(info);
            
            return View("Index");
        }
    }
}
