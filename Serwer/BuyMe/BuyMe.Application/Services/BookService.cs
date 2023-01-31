using BuyMe.Domain.DTO;
using BuyMe.Domain.Entities;
using BuyMe.Domain.Interfaces.Application;
using BuyMe.Domain.Interfaces.Infrastructure;

namespace BuyMe.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepositiory _repositiory;
        private readonly MapperConfig _mapper;

        public BookService(IBookRepositiory repositiory, MapperConfig mapper)
        {
            _repositiory = repositiory;
            _mapper = mapper;
        }

        public int Create(CreateBookDto book)
        {
            return _repositiory.Create(_mapper.Map(book));
        }

        public void CreateComment(BookCommentDto comment)
        {
            _repositiory.CreateComment(_mapper.Map(comment));
        }

        public void Delete(int id)
        {
            _repositiory.Delete(id);
        }

        public BookDto GetBook(int id)
        {
            return _mapper.Map(_repositiory.GetBook(id));
        }

        public PagedResultDto<BookDto> GetBooks(int pageSize, int PageNumber, string category, string phrase, string sort)
        {
            PagedResultDto<Book> books = _repositiory.GetBooks(pageSize, PageNumber, category, phrase, sort);
            PagedResultDto<BookDto> mappedBooks = new PagedResultDto<BookDto>(_mapper.Map(books.items), books.totalItemCount, pageSize);
            return mappedBooks;
        }

        public List<BookCategoryDto> GetCategories()
        {
            return _mapper.Map(_repositiory.GetCategories());
        }

        public void Update(int id, BookDto book)
        {
            Book mappedBook = _mapper.Map(book);
            mappedBook.Id = id;
            _repositiory.Update(mappedBook);
        }
    }
}
