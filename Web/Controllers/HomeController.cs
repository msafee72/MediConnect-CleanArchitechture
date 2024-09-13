using Medi_Connect.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //***********SESSION***********
            string message = string.Empty;

            if (HttpContext.Session.Keys.Contains("first-visit"))
            {
                string? data = HttpContext.Session.GetString("first-visit");
                message = $"Welcome Back {data}";
            }
            else
            {
                message = $"Welcome! You visited first time";
                HttpContext.Session.SetString("first-visit", DateTime.Now.ToString());
            }
            //return View("Index", message);
            return View((object)message);




            //***********COOKIE***********
            //string message = string .Empty;

            //if (HttpContext.Request.Cookies.ContainsKey("first-visit"))
            //{
            //    string? data = HttpContext.Request.Cookies["first-visit"];

            //    message = $"Welcome Back {data}";
            //}
            //else
            //{
            //    CookieOptions option = new CookieOptions();
            //    option.Expires = System.DateTime.Now.AddDays(1);

            //    message = $"Welcome! You visited first time";
            //    HttpContext.Response.Cookies.Append("first-visit", DateTime.Now.ToString(), option);
            //}

            ////return View("Index", message);
            //return View((object)message);

        }

        public IActionResult Remove()
        {
            //***********SESSION***********
            HttpContext.Session.Remove("first-visit");
            return View("Index");

            //***********COOKIE***********
            //HttpContext.Response.Cookies.Delete("first-visit");
            //return View("Index");

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
