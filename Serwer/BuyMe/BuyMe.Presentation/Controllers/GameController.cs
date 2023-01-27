using BuyMe.Domain.DTO;
using BuyMe.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyMe.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpGet]
        public IActionResult GetGames(string? sort, int pageSize, int PageNumber, string? category)
        {
            PagedResultDto<GameDto> games = _gameService.GetGames(pageSize, PageNumber, category);
            if (!String.IsNullOrEmpty(sort))
            {
                if (sort == "priceLower")
                {
                    games.items = games.items.OrderBy(x => x.Price);
                    return Ok(games);
                }
                else if (sort == "priceUpper")
                {
                    games.items = games.items.OrderBy(x => x.Price).Reverse();
                    return Ok(games);
                }
                else if (sort == "alfabeth")
                {
                    games.items = games.items.OrderBy(x => x.Title);
                    return Ok(games);
                }
                else if (sort == "alfabethReverse")
                {
                    games.items = games.items.OrderBy(x => x.Title).Reverse();
                    return Ok(games);
                }
                else if (sort == "releaseDate")
                {
                    games.items = games.items.OrderBy(x => x.Releasedate).Reverse();
                    return Ok(games);
                }
            }
            else
            {
                return Ok(games);
            }

            return BadRequest();
        }
        [HttpGet("{id:int}")]
        public IActionResult GetGame(int id)
        {
            return Ok(_gameService.GetGame(id));
        }
        [HttpGet("categories")]
        public IActionResult GetBookCategorys()
        {
            return Ok(_gameService.GetCategories());
        }
        [HttpPost("comment")]
        public IActionResult AddBookComments([FromBody] GameCommentDto commentDto)
        {
            _gameService.CreateComment(commentDto);
            return Ok();
        }
        [Authorize(Roles = "Admin, Owner")]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _gameService.Delete(id);
            return NoContent();
        }
        [Authorize(Roles = "Admin, Owner")]
        [HttpPost]
        public IActionResult Add([FromBody] CreateGameDto game)
        {
            int id = _gameService.Create(game);
            return Created($"api/Game/{id}", _gameService.GetGame(id));
        }
        [Authorize(Roles = "Admin, Owner")]
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] GameDto game)
        {
            _gameService.Update(id, game);
            return Ok();
        }
    }
}
