using System.ComponentModel.DataAnnotations.Schema;

namespace BuyMe.Domain.Entities
{
    public class Game : AuditableEntity
    {
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string? Producer { get; set; }
        public DateOnly Releasedate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Carrier { get; set; }
        [ForeignKey("GameCategoryId")]
        public int GameCategoryId { get; set; }
        public GameCategory GameCategory { get; set; }
        public List<GameComment> GameComments { get; set; }
    }
}
