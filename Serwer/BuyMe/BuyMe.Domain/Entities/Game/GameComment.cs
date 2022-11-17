using System.ComponentModel.DataAnnotations.Schema;

namespace BuyMe.Domain.Entities
{
    public class GameComment : AuditableEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        public byte Stars { get; set; }

        [ForeignKey("GameId")]
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
