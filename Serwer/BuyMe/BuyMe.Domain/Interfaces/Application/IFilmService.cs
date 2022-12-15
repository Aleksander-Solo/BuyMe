using BuyMe.Domain.DTO;

namespace BuyMe.Domain.Interfaces.Application
{
    public interface IFilmService
    {
        public List<FilmDto> GetFilms();
        public FilmDto GetFilm(int id);
        public void Delete(int id);
        public void Update(int id, FilmDto film);
        public int Create(CreateFilmDto film);
        public void CreateComment(FilmCommentDto comment);
    }
}
