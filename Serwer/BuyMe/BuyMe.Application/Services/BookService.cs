using BuyMe.Domain.DTO;
using BuyMe.Domain.Interfaces.Application;
using BuyMe.Domain.Interfaces.Infrastructure;

namespace BuyMe.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepositiore _repositiory;
        private readonly MapperConfig _mapper;

        public BookService(IBookRepositiore repositiory, MapperConfig mapper)
        {
            _repositiory = repositiory;
            _mapper = mapper;
        }

        public int Create(BookDto book)
        {
            return _repositiory.Create(_mapper.Map(book));
        }

        public void Delete(int id)
        {
            _repositiory.Delete(id);
        }

        public BookDto GetBook(int id)
        {
            return _mapper.Map(_repositiory.GetBook(id));
        }

        public List<BookDto> GetBooks()
        {
            return _mapper.Map(_repositiory.GetBooks());
        }

        public void Update(int id, BookDto book)
        {
            _repositiory.Update(id, _mapper.Map(book));
        }
    }
}
