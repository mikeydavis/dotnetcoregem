using Microsoft.AspNetCore.Mvc;

namespace Models
{
interface IQuote
 {
    int Id { get; set; }
    string Credit { get; set; }
    string Quote { get; set; }
    JsonResult GetQuotes();

 }

}
    