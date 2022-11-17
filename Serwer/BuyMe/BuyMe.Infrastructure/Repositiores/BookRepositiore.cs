using BuyMe.Domain.Entities;
using BuyMe.Domain.Interfaces.Infrastructure;

namespace BuyMe.Infrastructure.Repositiores
{
    public class BookRepositiore : IBookRepositiore
    {
        private readonly ApplicationDbContext _context;

        public BookRepositiore(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book.Id;
        }

        public void Delete(int id)
        {
            Book book = _context.Books.FirstOrDefault(x => x.Id == id);
            _context.Books.Remove(book);
        }

        public Book GetBook(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public void Update(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
