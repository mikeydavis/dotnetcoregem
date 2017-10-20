using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class HomeController : Controller
    {
         [HttpGet]
        public IEnumerable<Quotes> GetAll()
        {
            var  quotes = new QuotesContext().Quotes.ToList();
            return quotes;
        }
        public IActionResult Index()
        {
            
            return View();
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
