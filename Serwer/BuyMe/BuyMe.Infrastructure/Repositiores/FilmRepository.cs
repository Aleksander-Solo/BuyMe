using BuyMe.Domain.Entities;
using BuyMe.Domain.Interfaces.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BuyMe.Infrastructure.Repositiores
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ApplicationDbContext _context;
        public FilmRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Create(Film film)
        {
            film.CreateDate = DateTime.Now;
            _context.Films.Add(film);
            _context.SaveChanges();
            return film.Id;
        }

        public void CreateComment(FilmComment comment)
        {
            comment.CreateDate = DateTime.Now;
            _context.FilmsComment.Add(comment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Film? film = _context.Films.FirstOrDefault(x => x.Id == id);
            _context.Films.Remove(film);
            _context.SaveChanges();
        }

        public Film GetFilm(int id)
        {
            Film? film = _context.Films.Include(x => x.FilmCategory)
                .Include(x => x.FilmComments).ThenInclude(x => x.User).FirstOrDefault(x => x.Id == id);

            return film;
        }

        public List<Film> GetFilms()
        {
            return _context.Films.ToList();
        }

        public void Update(Film film)
        {
            _context.Films.Update(film);
            _context.SaveChanges();
        }
    }
}
