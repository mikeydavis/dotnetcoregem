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
        public void GetAll()
        {
            QuotesContext qc = new QuotesContext();
            //return quotes;
        }

        [HttpGet]
        public JsonResult Get(string credit)
        {
            return Json(new QuotesContext().Quotes.ToList());
        }
        public async Task<IActionResult> Index()
        {
            var quotes = await _context.Quotes.ToListAsync();
            //var  quotes = await new  QuotesContext1().Quotes.ToListAsync();
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
            string quot = model.Quote;
            var  context = new QuotesContext();
            context.Add(model);
            context.SaveChanges();
            //return  CreatedAtRoute("GetQuotes", new { id = model.Id}, model);
            //return View("",model.Quote);
            var  quotes = new  QuotesContext().Quotes.ToList<Quotes>();
            return View("Index", quotes);
        }


        public IActionResult Error()
        {
            return View();
        }
    }


    public class QuotesContext1 : DbContext
    {
        public DbSet<Quotes> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=midax-a-minjs-rds.cuxi7qfyfqir.us-west-2.rds.amazonaws.com;User Id=admin;Password=Aneeka97;Database=test");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quotes>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Quote)
                    .HasColumnName("quote")
                    .HasColumnType("varchar(200)");
            });
        }
    }

    public class Quotes1
    {
        public int Id { get; set; }
        public string Credit { get; set; }
        public string Quote { get; set; }
    }
}
