using BuyMe.Domain.DTO;
using BuyMe.Domain.Entities;
using BuyMe.Domain.Interfaces.Application;
using BuyMe.Domain.Interfaces.Infrastructure;

namespace BuyMe.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepositiory _repositiory;
        private readonly MapperConfig _mapper;

        public GameService(IGameRepositiory repositiory, MapperConfig mapper)
        {
            _repositiory = repositiory;
            _mapper = mapper;
        }

        public int Create(CreateGameDto game)
        {
            return _repositiory.Create(_mapper.Map(game));
        }

        public void CreateComment(GameCommentDto comment)
        {
            _repositiory.CreateComment(_mapper.Map(comment));
        }

        public void Delete(int id)
        {
            _repositiory.Delete(id);
        }

        public List<GameCategoryDto> GetCategories()
        {
            return _mapper.Map(_repositiory.GetCategories());
        }

        public GameDto GetGame(int id)
        {
            return _mapper.Map(_repositiory.GetGame(id));
        }

        public PagedResultDto<GameDto> GetGames(int pageSize, int PageNumber, string category)
        {
            PagedResultDto<Game> games = _repositiory.GetGames(pageSize, PageNumber, category);
            PagedResultDto<GameDto> mappedGames = new PagedResultDto<GameDto>(_mapper.Map(games.items), games.totalItemCount, pageSize);
            return mappedGames;
        }

        public void Update(int id, GameDto game)
        {
            Game mappedGame = _mapper.Map(game);
            mappedGame.Id = id;
            _repositiory.Update(mappedGame);
        }
    }
}
