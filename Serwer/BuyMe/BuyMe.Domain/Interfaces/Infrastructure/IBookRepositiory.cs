using BuyMe.Domain.Entities;

namespace BuyMe.Domain.Interfaces.Infrastructure
{
    public interface IBookRepositiory
    {
        public List<Book> GetBooks();
        public Book GetBook(int id);
        public void Delete(int id);
        public void Update(Book book);
        public int Create(Book book);
    }
}
