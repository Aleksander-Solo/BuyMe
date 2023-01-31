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
            comment.User = null;
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
            Book book = _context.Books.Include(x => x.BookCategory).Include(x => x.BookComments).ThenInclude(x => x.User).FirstOrDefault(x => x.Id == id);

            if (book is null)
                throw new NotFoundException("Book not found");
            return book;
        }

        public PagedResultDto<Book> GetBooks(int pageSize, int PageNumber, string category, string phrase, string sort)
        {
            IQueryable<Book> books = null;
            if (!String.IsNullOrEmpty(category))
            {
                if (!String.IsNullOrEmpty(phrase))
                {
                    if (!String.IsNullOrEmpty(sort))
                    {
                        if (sort == "priceLower")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.BookCategory.Name == category && x.Title.Contains(phrase)).OrderBy(x => x.Price);
                        }
                        else if (sort == "priceUpper")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.BookCategory.Name == category && x.Title.Contains(phrase)).OrderBy(x => x.Price).Reverse();
                        }
                        else if (sort == "alfabeth")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.BookCategory.Name == category && x.Title.Contains(phrase)).OrderBy(x => x.Title);
                        }
                        else if (sort == "alfabethReverse")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.BookCategory.Name == category && x.Title.Contains(phrase)).OrderBy(x => x.Title).Reverse();
                        }
                        else if (sort == "releaseDate")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.BookCategory.Name == category && x.Title.Contains(phrase)).OrderBy(x => x.Releasedate).Reverse();
                        }
                    }
                    else
                    {
                        books = _context.Books.Include(x => x.BookCategory).Where(x => x.BookCategory.Name == category && x.Title.Contains(phrase));
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(sort))
                    {
                        if (sort == "priceLower")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.BookCategory.Name == category).OrderBy(x => x.Price);
                        }
                        else if (sort == "priceUpper")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.BookCategory.Name == category).OrderBy(x => x.Price).Reverse();
                        }
                        else if (sort == "alfabeth")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.BookCategory.Name == category).OrderBy(x => x.Title);
                        }
                        else if (sort == "alfabethReverse")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.BookCategory.Name == category).OrderBy(x => x.Title).Reverse();
                        }
                        else if (sort == "releaseDate")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.BookCategory.Name == category).OrderBy(x => x.Releasedate).Reverse();
                        }
                    }
                    else
                    {
                        books = _context.Books.Include(x => x.BookCategory).Where(x => x.BookCategory.Name == category);
                    }
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(phrase))
                {
                    if (!String.IsNullOrEmpty(sort))
                    {
                        if (sort == "priceLower")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.Title.Contains(phrase)).OrderBy(x => x.Price);
                        }
                        else if (sort == "priceUpper")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.Title.Contains(phrase)).OrderBy(x => x.Price).Reverse();
                        }
                        else if (sort == "alfabeth")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.Title.Contains(phrase)).OrderBy(x => x.Title);
                        }
                        else if (sort == "alfabethReverse")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.Title.Contains(phrase)).OrderBy(x => x.Title).Reverse();
                        }
                        else if (sort == "releaseDate")
                        {
                            books = _context.Books.Include(x => x.BookCategory).Where(x => x.Title.Contains(phrase)).OrderBy(x => x.Releasedate).Reverse();
                        }
                    }
                    else
                    {
                        books = _context.Books.Include(x => x.BookCategory).Where(x => x.Title.Contains(phrase));
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(sort))
                    {
                        if (sort == "priceLower")
                        {
                            books = _context.Books.Include(x => x.BookCategory).OrderBy(x => x.Price);
                        }
                        else if (sort == "priceUpper")
                        {
                            books = _context.Books.Include(x => x.BookCategory).OrderBy(x => x.Price).Reverse();
                        }
                        else if (sort == "alfabeth")
                        {
                            books = _context.Books.Include(x => x.BookCategory).OrderBy(x => x.Title);
                        }
                        else if (sort == "alfabethReverse")
                        {
                            books = _context.Books.Include(x => x.BookCategory).OrderBy(x => x.Title).Reverse();
                        }
                        else if (sort == "releaseDate")
                        {
                            books = _context.Books.Include(x => x.BookCategory).OrderBy(x => x.Releasedate).Reverse();
                        }
                    }
                    else
                    {
                        books = _context.Books.Include(x => x.BookCategory);
                    }
                }
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
