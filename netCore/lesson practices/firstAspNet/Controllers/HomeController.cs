using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace firstAspNet {

    public class HomeController: Controller {
        
        [Route("/")]
        [HttpGet]
        public IActionResult Index() {
            var toDo = new List<string>() {"Laundry", "Dishes", "Homework"};
            ViewBag.toDo = toDo;
            if(TempData["rand"] != null){
                ViewBag.RandNum = TempData["rand"];
            }
            return View("Index");
            // if name of view is same as the method name it will call the view as custome view
            // return View();
        }
        
        [Route("/Other")]
        [HttpPost]
        public IActionResult Other() {
            Console.WriteLine("Made it to this page!");
            Console.WriteLine("Processing Data...");
            // redirect based on route name
            // return RedirectToRoute("/");

            // redirect based on method name
            return RedirectToAction("Index");
        }
        [Route("/json")]
        [HttpGet]
        public JsonResult Cool() {
            var contactInfo = new Dictionary<string,object>();
            contactInfo["Name"] = "Dylan Sharkey";
            contactInfo["PhoneNumber"] = 6091929933;
            contactInfo["Age"] = 27;
            contactInfo["Email"] = "dsharkey@codingdojo.com";
            contactInfo["Address"] = "123 Rando st, Earth, Wa 98000";
            
            return Json(contactInfo);
        }

        [Route("/GetRandom")]
        [HttpGet]
        public IActionResult GetRandom(){
            Random rand = new Random();
            int num = rand.Next(10) * 1;
            TempData["rand"] = num;
            return RedirectToAction("Index");
        }

        [Route("/RandomRange")]
        [HttpPost]
        public IActionResult GetRandomRange(int range = 10){
            Random rand = new Random();
            int num = rand.Next(range);
            TempData["rand"] = num;
            return RedirectToAction("Index");
        }

    }
}