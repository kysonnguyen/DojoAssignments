using Microsoft.AspNetCore.Mvc;

namespace Dojo_Survey {
    public class SurveyController: Controller {
        [Route("/")]
        public IActionResult Index(){
            return View();
        }

        [Route("result")]
        [HttpPost]
        public IActionResult Result(string name, string location, string language, string comment = null)
        {
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Language = language;
            ViewBag.comment = comment;
            return View();
        }
    }
}