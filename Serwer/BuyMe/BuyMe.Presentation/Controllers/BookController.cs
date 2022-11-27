using BuyMe.Domain.DTO;
using BuyMe.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace BuyMe.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_bookService.GetBooks());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBook(int id)
        {
            return Ok(_bookService.GetBook(id));
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateBookDto book)
        {
            int id = _bookService.Create(book);
            return Created($"api/Book/{id}", _bookService.GetBook(id));
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] BookDto book)
        {
            _bookService.Update(id, book);
            return Ok();
        }
    }
}
