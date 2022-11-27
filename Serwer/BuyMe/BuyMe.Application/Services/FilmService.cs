using BuyMe.Domain.DTO;
using BuyMe.Domain.Entities;
using BuyMe.Domain.Interfaces.Application;
using BuyMe.Domain.Interfaces.Infrastructure;

namespace BuyMe.Application.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _repository;
        private readonly MapperConfig _mapper;
        public FilmService(IFilmRepository repository, MapperConfig mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int Create(FilmDto film)
        {
            return _repository.Create(_mapper.Map(film));
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public FilmDto GetFilm(int id)
        {
            return _mapper.Map(_repository.GetFilm(id));
        }

        public List<FilmDto> GetFilms()
        {
            return _mapper.Map(_repository.GetFilms());
        }

        public void Update(int id, FilmDto film)
        {
            Film mappedFilm = _mapper.Map(film);
            mappedFilm.Id = id;
            _repository.Update(mappedFilm);
        }
    }
}
