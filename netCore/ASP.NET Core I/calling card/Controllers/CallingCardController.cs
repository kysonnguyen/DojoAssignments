using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class CallingCardController : Controller
    {
        [HttpGet]
        [Route("card/{FirstName}/{LastName}/{Age}/{FavoriteColor}")]
        public JsonResult Card(string FirstName, string LastName, int Age, string FavoriteColor)
        {
            var Card = new
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                FavoriteColor = FavoriteColor
            };
            return Json(Card);
        }
    }
}