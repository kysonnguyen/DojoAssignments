using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dojodachi{
    public class myDachi{
        public int Happiness {get; set;}
        public int Fullness {get; set;}
        public int Energy {get;set;}
        public int Meals {get; set;}

        public myDachi(){
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
        }
    }
    public class DojodachiController: Controller{
        
        [Route("")]
        public IActionResult Index(){

            if(HttpContext.Session.GetObjectFromJson<myDachi>("Dachi") == null){
                HttpContext.Session.SetObjectAsJson("Dachi",new myDachi());
                ViewBag.Message = "Welcome to Dojodachi. You just obtained a new Dachi. Enjoy the game!";
                ViewBag.GameStatus = "ongoing");
                return View();
            }

            ViewBag.Message = TempData["message"];
            ViewBag.GameStatus = TempData["GameStatus"];
            ViewBag.myDachi = HttpContext.Session.GetObjectFromJson<myDachi>("Dachi");

            return View();
        }

        [Route("process")]
        [HttpPost]
        public IActionResult Process(string action){
            ViewBag.GameStatus = "ongoing";
            Random Rand = new Random();
            myDachi update = HttpContext.Session.GetObjectFromJson<myDachi>("Dachi");
            string message = "";
            string GameStatus = "ongoing";
            switch(action)
            {
                case "Feed":
                    if (update.Meals > 0)
                    {
                        update.Meals -=1;
                        if(Rand.Next(0,4)>0)
                        {
                            update.Fullness += Rand.Next(5,11);
                            message = $"Dojodachi liked the food :)";
                        }
                        else
                        {
                            message = "Dojodachi didn't like the food...";
                        }
                    }
                    else
                    {
                        message = "You have no food left. Work to gain more food.";
                    }
                    break;
                case "Play":
                    if (update.Energy >=5)
                    {
                        update.Energy -= 5;
                        if(Rand.Next(0,4)>0)
                        {
                            update.Happiness += Rand.Next(5,11);
                            message = "Dojodachi liked the game. Happiness increased :)";
                        }
                        else
                        {
                            message ="Dojodachi was bored";
                        }
                    }
                    else
                    {
                        message = "Not enough Energy. Get some sleep.";
                    }
                    break;
                case "Work":
                    if (update.Energy >=5)
                    {
                        update.Energy -= 5;                        
                        update.Meals += Rand.Next(1,4);
                        message = "You worked and earned more meals";
                    }
                    else
                    {
                        message = "Not enough Energy. Get some sleep.";
                    }
                    break;
                case "Sleep":
                    update.Energy += 15;
                    update.Fullness -= 5;
                    update.Happiness -= 5;
                    message = "You and Dojodachi had a good sleep.";
                    break;
            }
            if (update.Energy > 100 && update.Fullness > 100 && update.Happiness > 100)
            {
                message = "Congratz! You Won";
                GameStatus = "Game Over";
            }
            
            if (update.Fullness <= 0 || update.Happiness <= 0)
            {
                message = "Boo your Dojodachi died! You Lost";
                GameStatus = "Game Over";
            }
            
            TempData["message"] = message;
            TempData["GameStatus"] = GameStatus;
            HttpContext.Session.SetObjectAsJson("Dachi", update);

            return RedirectToAction("Index");
        }

        [Route("reset")]
        public IActionResult Reset(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upone retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

    }
}