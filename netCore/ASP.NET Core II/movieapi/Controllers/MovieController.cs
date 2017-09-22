using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Options;

namespace movieapi.Controllers
{
    public class MovieController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        private readonly string ApiKey;

        public MovieController(DbConnector connect, IOptions<ApiOption> config)
        {
            _dbConnector = connect;
            ApiKey = config.Value.ApiKey;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/search/{movie}")]
        public IActionResult QueryMovie(string movie = null)
        {   
            if(movie == null){
                ViewBag.Error = "Please input a movie title";
                return View("Index");
            }
            var result = new Dictionary<string, object>();
            // var movieInfo = new Dictionary<string, object>();
            WebRequest.GetDataAsync(movie, ApiKey, ApiResponse =>
                {
                    result = ApiResponse;
                }
            ).Wait();
            if((int)(long)result["total_results"] == 0){
                ViewBag.Error = "not found";
                return View("Index");
            }
            else{
                var resArr = result["results"] as JArray;
                float rating = (float)resArr[0]["vote_average"];
                string release_date = (string )resArr[0]["release_date"];
                string title = (string)resArr[0]["title"];
                string esc_title = title.Replace("'","''");
                string query = $"INSERT INTO movies (title, rating, release_date, created_at, updated_at) VALUES ('{esc_title}', '{rating}', '{release_date}',NOW(), NOW());";
                _dbConnector.Execute(query);
            }           
            return View("Index");
        }

        [HttpGet]
        [Route("/get")]
        public JsonResult Get(){
            string query = "SELECT * FROM movies ORDER BY created_at DESC;";
            var movies = _dbConnector.Query(query);
            Console.WriteLine($"here are the movies objects {movies}");
            return Json(movies);
        }
    }
}
