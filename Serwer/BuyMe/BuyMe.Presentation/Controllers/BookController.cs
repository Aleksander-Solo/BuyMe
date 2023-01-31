using BuyMe.Domain.DTO;
using BuyMe.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult GetBooks(string? sort, int pageSize, int PageNumber, string? category, string? phrase)
        {
            return Ok(_bookService.GetBooks(pageSize, PageNumber, category, phrase, sort));
        }
        [HttpGet("categories")]
        public IActionResult GetBookCategorys()
        {
            return Ok(_bookService.GetCategories());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetBook(int id)
        {
            return Ok(_bookService.GetBook(id));
        }
        [HttpPost("comment")]
        public IActionResult AddBookComments([FromBody] BookCommentDto commentDto)
        {
            _bookService.CreateComment(commentDto);
            return Ok();
        }
        [Authorize(Roles = "Admin, Owner")]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Owner")]
        public IActionResult Add([FromBody] CreateBookDto book)
        {
            int id = _bookService.Create(book);
            return Created($"api/Book/{id}", _bookService.GetBook(id));
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin, Owner")]
        public IActionResult Update(int id, [FromBody] BookDto book)
        {
            _bookService.Update(id, book);
            return Ok();
        }
    }
}
