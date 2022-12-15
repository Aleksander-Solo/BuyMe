using BuyMe.Domain.Entities;

namespace BuyMe.Domain.Interfaces.Infrastructure
{
    public interface IFilmRepository
    {
        public List<Film> GetFilms();
        public Film GetFilm(int id);
        public void Delete(int id);
        public void Update(Film film);
        public int Create(Film film);
        public void CreateComment(FilmComment comment);
    }
}
