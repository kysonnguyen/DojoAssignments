using System;
using LostInTheWoods.Factory;
using LostInTheWoods.Models;
using Microsoft.AspNetCore.Mvc;

namespace LostInTheWoods.Controllers
{
    public class TrailController : Controller
    {
        private readonly TrailFactory trailFactory;
        public TrailController()
        {
            trailFactory = new TrailFactory();
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var trails = TrailFactory.GetAllTrails();
            ViewBag.Trails = trails;
            return View();
        }

        [HttpGet]
        [Route("/NewTrail")]
        public IActionResult NewTrail()
        {
            return View();
        }

        [HttpPost]
        [Route("/addtrail")]
        public IActionResult AddTrail(Trail Info)
        {
            if(ModelState.IsValid){
                TrailFactory.Add(Info);
                return RedirectToAction("Index");
            }
            else{
                ViewBag.Errors = ModelState.Values;
                return View("NewTrail");
            }
        }

        [HttpGet]
        [Route("/trails/{id}")]
        public IActionResult Trail(int id)
        {
            ViewBag.Trail = TrailFactory.GetTrailById(id);
            return View();
        }
    }
}
