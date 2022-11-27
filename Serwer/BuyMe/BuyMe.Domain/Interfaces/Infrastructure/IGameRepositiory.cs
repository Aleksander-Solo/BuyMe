using BuyMe.Domain.Entities;

namespace BuyMe.Domain.Interfaces.Infrastructure
{
    public interface IGameRepositiory
    {
        public List<Game> GetGames();
        public Game GetGame(int id);
        public void Delete(int id);
        public void Update(Game game);
        public int Create(Game game);
    }
}
