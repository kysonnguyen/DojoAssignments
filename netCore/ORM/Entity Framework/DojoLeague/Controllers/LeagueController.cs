using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoLeague.Models;
using System.Linq;

namespace DojoLeague.Controllers
{
    public class LeagueController : Controller
    {
        private MyContext context;
        public LeagueController(MyContext cnx){
            context = cnx;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/Ninjas")] 
        public IActionResult Ninjas()
        {
            ViewBag.Ninjas = context.Ninjas.ToList();
            // ViewBag.Rogues = NinjaFactory.GetRogueNinjas();
            ViewBag.Dojos = context.Dojos.ToList();
            return View();
        }

        // [HttpPost]
        // [Route("/Ninjas/Register")] 
        // public IActionResult RegisterNinja(Ninja info)
        // {
        //     NinjaFactory.Add(info);
        //     return RedirectToAction("Ninjas");
        // }
        
        // [HttpGet]
        // [Route("/Ninja/{id}")] 
        // public IActionResult Ninja(int id)
        // {   
        //     var ninja = NinjaFactory.GetNinjaById(id);
        //     if(ninja == null){
        //         ninja = NinjaFactory.GetRogueNinjaById(id);
        //     }
        //     ViewBag.Ninja = ninja;
        //     return View();
        // }

        // [HttpGet]
        // [Route("/Dojos")] 
        // public IActionResult Dojos()
        // {
        //     ViewBag.Dojos = DojoFactory.GetAllDojos();
        //     return View("Dojos");
        // }

        // [HttpPost]
        // [Route("/RegisterDojo")] 
        // public IActionResult RegisterDojo(Dojo info)
        // {
        //     if(ModelState.IsValid){
        //         Console.WriteLine(info);
        //         dojoFactory.Add(info);
        //         return RedirectToAction("Dojos");
        //     }
        //     else{
        //         ViewBag.Errors = ModelState.Values;
        //         return View("Index");
        //     }
        // }
        
        // [HttpGet]
        // [Route("/Dojo/{id}")] 
        // public IActionResult Dojo(int id)
        // {   
        //     Dojo dojo = DojoFactory.GetDojoById(id);
        //     ViewBag.Dojo = dojo;
        //     ViewBag.Rogues = NinjaFactory.GetRogueNinjas();
        //     HttpContext.Session.SetInt32("dojo_id", dojo.id); 
        //     return View();
        // }

        // [HttpGet]
        // [Route("/Recruit/{id}")]
        // public IActionResult Recruit(int id)
        // {
        //     int dojo_id = (int) HttpContext.Session.GetInt32("dojo_id");
        //     NinjaFactory.Recruit(dojo_id, id);
        //     return RedirectToAction("Dojo", new{id = dojo_id});
        // }

        // [HttpGet]
        // [Route("/Banish/{id}")]
        // public IActionResult Banish(int id)
        // {
        //     int dojo_id = (int) HttpContext.Session.GetInt32("dojo_id");
        //     NinjaFactory.Banish(id);
        //     // return View("Dojos");
        //     return RedirectToAction("Dojo", new{id = dojo_id});
        // }
    }
}
