using BuyMe.Domain.Entities;

namespace BuyMe.Domain.DTO
{
    public class GameDto
    {
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string? Producer { get; set; }
        public DateOnly Releasedate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Carrier { get; set; }
        public int GameCategoryId { get; set; }
        public string GameCategory { get; set; }
        public List<GameComment>? GameComments { get; set; }
    }
}
