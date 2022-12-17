using BuyMe.Domain.DTO;
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

        public void CreateComment(BookComment comment)
        {
            comment.CreateDate = DateTime.Now;
            _context.BooksComment.Add(comment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Book book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (book is null)
                throw new NotFoundException("Book not found");
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public Book GetBook(int id)
        {
            Book book = _context.Books.Include(x => x.BookCategory).Include(x => x.BookComments).FirstOrDefault(x => x.Id == id);

            if (book is null)
                throw new NotFoundException("Book not found");
            return book;
        }

        public PagedResultDto<Book> GetBooks(int pageSize, int PageNumber, string category)
        {
            IQueryable<Book> books;
            if (!String.IsNullOrEmpty(category))
            {
                books = _context.Books.Include(x => x.BookCategory).Where(x => x.BookCategory.Name == category);
            }
            else
            {
                books = _context.Books.Include(x => x.BookCategory);
            }


            IEnumerable<Book> pagBooks = books.Skip(pageSize * (PageNumber - 1)).Take(pageSize);

            return new PagedResultDto<Book>(pagBooks, books.Count(), pageSize);
        }

        public List<BookCategory> GetCategories()
        {
            return _context.BooksCategory.ToList();
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
