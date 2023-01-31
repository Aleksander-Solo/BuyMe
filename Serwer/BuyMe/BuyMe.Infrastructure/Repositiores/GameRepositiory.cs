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
            Game game = _context.Games.Include(x => x.GameCategory).Include(x => x.GameComments).FirstOrDefault(x => x.Id == id);
            return game;
        }

        public PagedResultDto<Game> GetGames(int pageSize, int PageNumber, string category, string phrase, string sort)
        {
            IQueryable<Game> games = null;

            if (!String.IsNullOrEmpty(category))
            {
                if (!String.IsNullOrEmpty(phrase))
                {
                    if (!String.IsNullOrEmpty(sort))
                    {
                        if (sort == "priceLower")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.GameCategory.Name == category && x.Title.Contains(phrase)).OrderBy(x => x.Price);
                        }
                        else if (sort == "priceUpper")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.GameCategory.Name == category && x.Title.Contains(phrase)).OrderBy(x => x.Price).Reverse();
                        }
                        else if (sort == "alfabeth")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.GameCategory.Name == category && x.Title.Contains(phrase)).OrderBy(x => x.Title);
                        }
                        else if (sort == "alfabethReverse")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.GameCategory.Name == category && x.Title.Contains(phrase)).OrderBy(x => x.Title).Reverse();
                        }
                        else if (sort == "releaseDate")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.GameCategory.Name == category && x.Title.Contains(phrase)).OrderBy(x => x.Releasedate).Reverse();
                        }
                    }
                    else
                    {
                        games = _context.Games.Include(x => x.GameCategory).Where(x => x.GameCategory.Name == category && x.Title.Contains(phrase));
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(sort))
                    {
                        if (sort == "priceLower")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.GameCategory.Name == category).OrderBy(x => x.Price);
                        }
                        else if (sort == "priceUpper")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.GameCategory.Name == category).OrderBy(x => x.Price).Reverse();
                        }
                        else if (sort == "alfabeth")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.GameCategory.Name == category).OrderBy(x => x.Title);
                        }
                        else if (sort == "alfabethReverse")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.GameCategory.Name == category).OrderBy(x => x.Title).Reverse();
                        }
                        else if (sort == "releaseDate")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.GameCategory.Name == category).OrderBy(x => x.Releasedate).Reverse();
                        }
                    }
                    else
                    {
                        games = _context.Games.Include(x => x.GameCategory).Where(x => x.GameCategory.Name == category);
                    }
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(phrase))
                {
                    if (!String.IsNullOrEmpty(sort))
                    {
                        if (sort == "priceLower")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.Title.Contains(phrase)).OrderBy(x => x.Price);
                        }
                        else if (sort == "priceUpper")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.Title.Contains(phrase)).OrderBy(x => x.Price).Reverse();
                        }
                        else if (sort == "alfabeth")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.Title.Contains(phrase)).OrderBy(x => x.Title);
                        }
                        else if (sort == "alfabethReverse")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.Title.Contains(phrase)).OrderBy(x => x.Title).Reverse();
                        }
                        else if (sort == "releaseDate")
                        {
                            games = _context.Games.Include(x => x.GameCategory).Where(x => x.Title.Contains(phrase)).OrderBy(x => x.Releasedate).Reverse();
                        }
                    }
                    else
                    {
                        games = _context.Games.Include(x => x.GameCategory).Where(x => x.Title.Contains(phrase));
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(sort))
                    {
                        if (sort == "priceLower")
                        {
                            games = _context.Games.Include(x => x.GameCategory).OrderBy(x => x.Price);
                        }
                        else if (sort == "priceUpper")
                        {
                            games = _context.Games.Include(x => x.GameCategory).OrderBy(x => x.Price).Reverse();
                        }
                        else if (sort == "alfabeth")
                        {
                            games = _context.Games.Include(x => x.GameCategory).OrderBy(x => x.Title);
                        }
                        else if (sort == "alfabethReverse")
                        {
                            games = _context.Games.Include(x => x.GameCategory).OrderBy(x => x.Title).Reverse();
                        }
                        else if (sort == "releaseDate")
                        {
                            games = _context.Games.Include(x => x.GameCategory).OrderBy(x => x.Releasedate).Reverse();
                        }
                    }
                    else
                    {
                        games = _context.Games.Include(x => x.GameCategory);
                    }
                }
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
