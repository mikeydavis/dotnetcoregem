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

    }
}
