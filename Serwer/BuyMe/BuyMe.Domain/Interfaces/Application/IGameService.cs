using BuyMe.Domain.DTO;

namespace BuyMe.Domain.Interfaces.Application
{
    public interface IGameService
    {
        public List<GameDto> GetGames();
        public GameDto GetGame(int id);
        public void Delete(int id);
        public void Update(int id, GameDto game);
        public int Create(GameDto game);
    }
}
