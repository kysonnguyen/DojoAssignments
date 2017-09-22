using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PokeInfo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/GetPokemon")]
        public IActionResult GetInfo(int id){
            Dictionary<string,object> PokeInfo = new Dictionary<string,object>(); 
            WebRequest.GetPokemonDataAsync(id, (response) => {
                PokeInfo["name"] = response["name"];
                var typeList = new List<string>();
                var typesArray = response["types"] as JArray;
                for(int idx = 0; idx < typesArray.Count; idx++)
                {
                    typeList.Add((string)typesArray[idx]["type"]["name"]);
                }
                PokeInfo["types"] = typeList;
                PokeInfo["weight"] = response["weight"];
                PokeInfo["height"] = response["height"];
            }).Wait();
            ViewBag.PokeInfo = PokeInfo;
            return View("Index");
        }
    }
}
