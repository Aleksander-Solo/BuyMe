using BuyMe.Domain.Entities;
using BuyMe.Domain.Interfaces.Infrastructure;

namespace BuyMe.Infrastructure.Repositiores
{
    public class GameRepositiory : IGameRepositiory
    {
        private readonly ApplicationDbContext _context;
        public GameRepositiory(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Create(Game game)
        {
            game.CreateDate = DateTime.Now;
            _context.Games.Add(game);
            _context.SaveChanges();
            return game.Id;
        }

        public void Delete(int id)
        {
            Game game = _context.Games.FirstOrDefault(x => x.Id == id);

            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        public Game GetGame(int id)
        {
            Game game = _context.Games.FirstOrDefault(x => x.Id == id);
            return game;
        }

        public List<Game> GetGames()
        {
            return _context.Games.ToList();
        }

        public void Update(Game game)
        {
            _context.Update(game);
            _context.SaveChanges();
        }
    }
}
