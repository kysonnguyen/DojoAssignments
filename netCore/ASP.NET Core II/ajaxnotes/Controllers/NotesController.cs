using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace ajaxnotes.Controllers
{
    public class NotesController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            
            ViewBag.Error = TempData["Error"];
            
            return View();
        }

        [HttpPost]
        [Route("/add")]
        public IActionResult Add(string title = null, string content = null)
        {
            if(title == null){           
                TempData["Error"] = "Title cannot be empty";
                return RedirectToAction("Index");
            }
            string esc_title = title.Replace("'", "''");
            string query = $"INSERT INTO notes (title, content, created_at, updated_at) VALUES ('{esc_title}', '{content}', NOW(), NOW());";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("/update")]
        public void Update(int id, string content)
        {
            Console.WriteLine($"the id of the note is {id}");
            Console.WriteLine($"the content of the note is {content}");            
            string esc_content = content.Replace("'", "''");
            string query = $"UPDATE notes SET content = '{esc_content}' WHERE id = {id};";
            DbConnector.Execute(query);
        }

        [HttpPost]
        [Route("/delete/{id}")]
        public IActionResult Delete(int id)
        {
            string query = $"DELETE FROM notes WHERE id = {id}";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        [Route("/get")]
        public JsonResult Get(){
            string query = $"SELECT * FROM notes;";
            var notes = DbConnector.Query(query);
            return Json(notes);
        }
    }
}
