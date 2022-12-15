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
        public IActionResult GetGames()
        {
            return Ok(_gameService.GetGames());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetGame(int id)
        {
            return Ok(_gameService.GetGame(id));
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
