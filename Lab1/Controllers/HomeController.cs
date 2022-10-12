using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Lab1.Controllers
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
            return View();
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
        public string Hello()
        {
            string name = Request.Query["name"];
            string age = Request.Query["age"];
            if (int.TryParse(age, out var intAge))
            {
                int yearCurrent = DateTime.Now.Year;
                return $"Hello {name}, you birth year is {yearCurrent - intAge}. ";
            }
            else
            {
                Response.StatusCode = 400;
                return "";
            }
        }

        public string Calc([FromQuery] int? age, [FromQuery] string name)
        {
            if (age != null)
            {
                int yearCurrent = DateTime.Now.Year;
                return $"Hello {name}, you birth year is {yearCurrent - age}. ";
            }
            else
            {
                Response.StatusCode = 400;
                return "";
            }
        }
    }
}