using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class QuoteController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/quotes")]
        public IActionResult Add(string name, string quote)
        {
            string esc_quote = quote.Replace("'","''");
            string esc_name = name.Replace("'","''");
            string query = $"INSERT INTO quotes (name, quote, created_at, updated_at) VALUES ('{esc_name}', '{esc_quote}', NOW(), NOW());";
            DbConnector.Execute(query);
            query = "SELECT * FROM quotes ORDER BY created_at DESC;";
            var quotes = DbConnector.Query(query);
            ViewBag.Quotes = quotes;
            return View("Quotes");
        }

        [HttpGet]
        [Route("/quotes")]
        public IActionResult Quotes()
        {
            string query = "SELECT * FROM quotes ORDER BY created_at DESC;";
            var quotes = DbConnector.Query(query);
            ViewBag.Quotes = quotes;
            return View();
        }

    }
}
