using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace Controllers
{
    public class HomeController : Controller
    {
        private QuotesContext _context;
        public HomeController(QuotesContext context){
            _context = context;
        }

        [HttpGet]
        public JsonResult Get(string credit)
        {
            return Json(_context.Quotes);
        }
        public async Task<IActionResult> Index()
        {
            var quotes = await _context.Quotes.ToListAsync();
            return View(quotes);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        [HttpPost("Contact")]
        public IActionResult Contact(Quotes model)
        {
            //ViewData["Message"] = "Your contact page.";
            if (model.Credit == null)
            {
                return BadRequest();
            }
            _context.Add(model);
            _context.SaveChanges();
            var quotes = _context.Quotes.ToList();
            return View("Index", quotes);
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
