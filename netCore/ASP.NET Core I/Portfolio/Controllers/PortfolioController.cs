using Microsoft.AspNetCore.Mvc;

namespace Portfolio {

    public class PortfolioController: Controller {

        [Route("/")]
        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        [Route("/Projects")]
        public IActionResult Projects() {
            return View();
        }

        [Route("/Contact")]
        public IActionResult Contact() {
            return View();
        }


    }
}