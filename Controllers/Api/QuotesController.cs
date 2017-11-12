using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Models;

namespace aspnetcore
{
    [Route("api/[controller]")]
    
    public class QuotesController : Controller
    {
        private QuotesContext _context;
        public QuotesController(QuotesContext context){
            _context = context;
        }
        
        [HttpGet]
        [Route("")]
        public IEnumerable<Quotes> Get()
        {
            
            //var  quotes = new QuotesContext1().Quotes.ToList();
            //var search = quotes.Where(x => x.Credit == "mike");
            var MoreQuotes = _context.Quotes.ToList();
            return MoreQuotes;
        }

        [HttpGet("{id}", Name = "GetQuotes")]
        public IActionResult GetById(long id)
        {
            var item = new QuotesContext().Quotes.ToList().FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] Quotes quote)
        {
            if (quote == null)
            {
                return BadRequest();
            }

        
            _context.Add(quote);
            _context.SaveChanges();
        
            return CreatedAtRoute("GetQuotes", new { id = quote.Id}, quote);
        }


        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Quotes item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var  context = new QuotesContext();

            var quote = context.Quotes.FirstOrDefault(t => t.Id == id);
            if (quote == null)
            {
                return NotFound();
            }

            quote.Credit = item.Credit;
            quote.Quote = item.Quote;

            context.Quotes.Update(quote);
            context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var  quote = new QuotesContext().Quotes.FirstOrDefault(x => x.Id == id);
            if (quote == null)
            {
                return NotFound();
            }
            var  context = new QuotesContext();
            context.Remove(quote);
            context.SaveChanges();
            return new NoContentResult();
        }

    }
}
