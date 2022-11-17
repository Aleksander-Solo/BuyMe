using BuyMe.Domain.Entities;

namespace BuyMe.Domain.Interfaces.Infrastructure
{
    public interface IBookRepositiore
    {
        public List<Book> GetBooks();
        public Book GetBook(int id);
        public void Delete(int id);
        public void Update(int id, Book book);
        public int Create(Book book);
    }
}
