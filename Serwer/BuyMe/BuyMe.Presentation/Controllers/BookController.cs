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
        public IActionResult GetBooks(string? sort, int pageSize, int PageNumber)
        {
            PagedResultDto<BookDto> books = _bookService.GetBooks(pageSize, PageNumber);
            if (!String.IsNullOrEmpty(sort))
            {
                if (sort == "priceLower")
                {
                    books.items.OrderBy(x => x.Price);
                    return Ok(books);
                }
                else if (sort == "priceUpper")
                {
                    books.items.OrderBy(x => x.Price).Reverse();
                    return Ok(books);
                }
                else if (sort == "alfabeth")
                {
                    books.items.OrderBy(x => x.Title);
                    return Ok(books);
                }
                else if (sort == "alfabethReverse")
                {
                    books.items.OrderBy(x => x.Title).Reverse();
                    return Ok(books);
                }
                else if (sort == "releaseDate")
                {
                    books.items.OrderBy(x => x.Releasedate).Reverse();
                    return Ok(books);
                }
            }
            else
            {
                return Ok(books);
            }

            return BadRequest();
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
