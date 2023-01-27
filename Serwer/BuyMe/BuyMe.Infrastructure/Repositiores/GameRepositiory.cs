using BuyMe.Domain.DTO;
using BuyMe.Domain.Entities;
using BuyMe.Domain.Interfaces.Infrastructure;
using Microsoft.EntityFrameworkCore;

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

        public void CreateComment(GameComment comment)
        {
            comment.CreateDate = DateTime.Now;
            _context.GamesComment.Add(comment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Game game = _context.Games.FirstOrDefault(x => x.Id == id);

            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        public List<GameCategory> GetCategories()
        {
            return _context.GamesCategory.ToList();
        }

        public Game GetGame(int id)
        {
            Game game = _context.Games.FirstOrDefault(x => x.Id == id);
            return game;
        }

        public PagedResultDto<Game> GetGames(int pageSize, int PageNumber, string category)
        {
            IQueryable<Game> games;
            if (!String.IsNullOrEmpty(category))
            {
                games = _context.Games.Include(x => x.GameCategory).Where(x => x.GameCategory.Name == category);
            }
            else
            {
                games = _context.Games.Include(x => x.GameCategory);
            }


            IEnumerable<Game> pagGames = games.Skip(pageSize * (PageNumber - 1)).Take(pageSize);

            return new PagedResultDto<Game>(pagGames, games.Count(), pageSize);
        }

        public void Update(Game game)
        {
            _context.Update(game);
            _context.SaveChanges();
        }
    }
}
