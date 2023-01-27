using BuyMe.Domain.DTO;
using BuyMe.Domain.Entities;

namespace BuyMe.Domain.Interfaces.Infrastructure
{
    public interface IGameRepositiory
    {
        public PagedResultDto<Game> GetGames(int pageSize, int PageNumber, string category);
        public Game GetGame(int id);
        public void Delete(int id);
        public void Update(Game game);
        public int Create(Game game);
        public void CreateComment(GameComment comment);
        public List<GameCategory> GetCategories();
    }
}
