using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Conference.Models;

namespace aspnetcore.Controllers
{
    public class HomeController : Controller
    {
         //private readonly QuoteContext _context;

        //public HomeController(QuoteContext context)
        //{
        //    _context = context;
        //}
        public IActionResult Index()
        {
            //var quotes = _context.Quotes.ToList();
            //return View(quotes);
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
