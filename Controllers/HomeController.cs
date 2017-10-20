using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace aspnetcore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var quotes = new Models.QuotesContext().Quotes.ToList();
            return View(quotes);
        }

        public IActionResult About()
        {
            
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
