using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Quotes
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Give credit")]
        [Display(Name = "Add Credit")]
        public string Credit { get; set; }
        [Required(ErrorMessage = "Add your quote")]
        [Display(Name = "Add Quote")]
        public string Quote { get; set; }
    }
}
