using BuyMe.Domain.Entities;
using BuyMe.Domain.Interfaces.Infrastructure;
using BuyMe.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BuyMe.Infrastructure.Repositiores
{
    public class BookRepositiory : IBookRepositiory
    {
        private readonly ApplicationDbContext _context;

        public BookRepositiory(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Create(Book book)
        {
            book.CreateDate = DateTime.Now;
            _context.Books.Add(book);
            _context.SaveChanges();
            return book.Id;
        }

        public void Delete(int id)
        {
            Book book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (book is null)
                throw new NotFoundException("Book not found");
            _context.Books.Remove(book);
        }

        public Book GetBook(int id)
        {
            Book book = _context.Books.Include(x => x.BookCategory).Include(x => x.BookComments).FirstOrDefault(x => x.Id == id);

            if (book is null)
                throw new NotFoundException("Book not found");
            return book;
        }

        public List<Book> GetBooks()
        {
            return _context.Books.Include(x => x.BookCategory).ToList();
        }

        public void Update(Book book)
        {
            if (_context.Books.FirstOrDefault(x => x.Id == book.Id) is null)
                throw new NotFoundException("Book not found");
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
