using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace aspnetcore
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Quotes1> Get()
        {
            var  quotes = new QuotesContext1().Quotes.ToList();
            return quotes;
        }

        [HttpGet("{id}", Name = "GetQuotes")]
        public IActionResult GetById(long id)
        {
            var item = new QuotesContext1().Quotes.ToList().FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Quotes1 quote)
        {
            if (quote == null)
            {
                return BadRequest();
            }

            var  context = new QuotesContext1();
            context.Add(quote);
            context.SaveChanges();
        
            return CreatedAtRoute("GetQuotes", new { id = quote.Id}, quote);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var  quote = new QuotesContext1().Quotes.FirstOrDefault(x => x.Id == id);
            if (quote == null)
            {
                return NotFound();
            }
            var  context = new QuotesContext1();
            context.Remove(quote);
            context.SaveChanges();
            return new NoContentResult();
        }

    }
}
