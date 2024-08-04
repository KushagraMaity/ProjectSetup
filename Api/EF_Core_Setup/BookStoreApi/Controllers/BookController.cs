
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBook book;
        public BookController(IConfiguration config) {
            book = new Book(config);
        }

        [HttpGet("GetBookList")]
        public IActionResult GetBooks() => Ok(book.ShowBooks());
        
    }
}
