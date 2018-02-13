using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Models
{
    public class Quotes : IQuote
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Give credit")]
        [Display(Name = "Add Credit")]
        public string Credit { get; set; }
        [Required(ErrorMessage = "Add your quote")]
        [Display(Name = "Add Quote")]
        public string Quote { get; set; }
        
        private QuotesContext _context;
        
        public Quotes()
        {
        }
        public Quotes(QuotesContext context){
            _context = context;
        }
        public JsonResult GetQuotes(){   
            return new JsonResult(_context.Quotes);
        }
    }
}
