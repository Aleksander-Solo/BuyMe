using BuyMe.Domain.DTO;

namespace BuyMe.Domain.Interfaces.Application
{
    public interface IBookService
    {
        public List<BookDto> GetBooks();
        public BookDto GetBook(int id);
        public void Delete(int id);
        public void Update(int id, BookDto book);
        public int Create(BookDto book);
    }
}
