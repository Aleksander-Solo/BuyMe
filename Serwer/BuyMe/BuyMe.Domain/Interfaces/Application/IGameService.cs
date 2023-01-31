using BuyMe.Domain.DTO;

namespace BuyMe.Domain.Interfaces.Application
{
    public interface IGameService
    {
        public PagedResultDto<GameDto> GetGames(int pageSize, int PageNumber, string category, string phrase, string sort);
        public GameDto GetGame(int id);
        public void Delete(int id);
        public void Update(int id, GameDto game);
        public int Create(CreateGameDto game);
        public void CreateComment(GameCommentDto comment);
        public List<GameCategoryDto> GetCategories();
    }
}
