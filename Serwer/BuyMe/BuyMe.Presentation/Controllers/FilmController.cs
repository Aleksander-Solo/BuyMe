using BuyMe.Domain.DTO;
using BuyMe.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace BuyMe.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        [HttpGet]
        public IActionResult GetFilms()
        {
            return Ok(_filmService.GetFilms());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetFilm(int id)
        {
            return Ok(_filmService.GetFilm(id));
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _filmService.Delete(id);
            return NoContent();
        }
        [HttpPost]
        public IActionResult Add([FromBody] FilmDto film)
        {
            int id = _filmService.Create(film);
            return Created($"api/Film/{id}", _filmService.GetFilm(id));
        }
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] FilmDto film)
        {
            _filmService.Update(id, film);
            return Ok();
        }
    }
}
