using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Random_Passcode{
    public class PasscodeController:Controller {
        [Route("/")]
        [HttpGet]
        public IActionResult Index(){
            int? count = HttpContext.Session.GetInt32("count");
            if(count == null){
                count = 0;
            }
            count +=1;
            HttpContext.Session.SetInt32("count", (int)count);
            
            string passcode = "";
            string choices = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random Rand = new Random();
            for(int i = 0; i<14; i++){
                passcode = passcode + choices[Rand.Next(0,choices.Length)];
            }
            ViewBag.Passcode = passcode;
            ViewBag.Count = count;
            
            return View();
        }

        
    }
}