using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using thewall.Models;
using thewall.Factories;

namespace thewall.Controllers
{
    public class WallController : Controller
    {
        private readonly UserFactory userFactory;
        private readonly MessageFactory messageFactory;
        private readonly CommentFactory commentFactory;
        public WallController() {
            userFactory = new UserFactory();
            messageFactory = new MessageFactory();
            commentFactory = new CommentFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/register")]
        public IActionResult Register(User Info)
        {   
            if(ModelState.IsValid)
            {
                var Hasher = new PasswordHasher<User>();
                Info.Password = Hasher.HashPassword(Info, Info.Password);
                UserFactory.Add(Info);
                User CurrentUser = UserFactory.GetLatestUser();
                HttpContext.Session.SetInt32("CurrUserId", CurrentUser.id);
                return RedirectToAction("Show");
            }

            ViewBag.Errors = ModelState.Values;
            return View("Index");
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(string Email, string Password)
        {   
            if(Email != null){
                User check = UserFactory.GetUserByEmail(Email);
                if (check != null){
                    var Hasher = new PasswordHasher<User>();
                    if(0 != Hasher.VerifyHashedPassword(check, check.Password, Password)){
                        HttpContext.Session.SetInt32("CurrUserId", check.id);
                        return RedirectToAction("Show");    
                    }
                    else{
                        ViewBag.Errors = "Email/Password do not match";
                        return View("Index");
                    }
                }
                ViewBag.Errors = "Email not found. Register as a new user?";
                return  View("Index");
            }
            else{
                ViewBag.Errors = "Please input a valid email";
                return View("Index");
            }
        }

        [HttpGet]
        [Route("wall")]
        public IActionResult Show()
        {
            User CurrentUser = UserFactory.GetUserById((int) HttpContext.Session.GetInt32("CurrUserId"));
            ViewBag.User = CurrentUser;
            var messages = MessageFactory.GetAllMessage();
            ViewBag.Messages = messages;
            return View("Wall");
        }

        [HttpPost]
        [Route("/postmessage")]
        public IActionResult PostMessage(Message Info)
        {
            if(Info.message != null){
                Info.user_id = (int)HttpContext.Session.GetInt32("CurrUserId");
                MessageFactory.Add(Info);
                return RedirectToAction("Show");
            }
            else{
                ViewBag.Errors = "Message cannot be empty.";
                return View("Wall");
            }
        }

        [HttpPost]
        [Route("/postcomment")]
        public IActionResult PostComment(Comment Info)
        {
            if(Info.comment != null){
                Info.user_id = (int)HttpContext.Session.GetInt32("CurrUserId");
                CommentFactory.Add(Info);
                return RedirectToAction("Show");
            }
            ViewBag.Errors = "Comment cannot be empty.";
            return View("Wall");
        }

        [HttpGet]
        [Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
