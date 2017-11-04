using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Models;

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
            var search = quotes.Where(x => x.Credit == "mike");

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
        [ValidateAntiForgeryToken]
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


        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Quotes1 item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var  context = new QuotesContext1();

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
