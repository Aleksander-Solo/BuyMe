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

        public int Create(GameDto game)
        {
            return _repositiory.Create(_mapper.Map(game));
        }

        public void Delete(int id)
        {
            _repositiory.Delete(id);
        }

        public GameDto GetGame(int id)
        {
            return _mapper.Map(_repositiory.GetGame(id));
        }

        public List<GameDto> GetGames()
        {
            return _mapper.Map(_repositiory.GetGames());
        }

        public void Update(int id, GameDto game)
        {
            Game mappedGame = _mapper.Map(game);
            mappedGame.Id = id;
            _repositiory.Update(mappedGame);
        }
    }
}
