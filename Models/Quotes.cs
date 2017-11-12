using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Quotes
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Credit { get; set; }
        [Required]
        public string Quote { get; set; }
    }
}
