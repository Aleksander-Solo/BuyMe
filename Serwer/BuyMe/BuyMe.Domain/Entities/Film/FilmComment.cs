using System.ComponentModel.DataAnnotations.Schema;

namespace BuyMe.Domain.Entities
{
    public class FilmComment : AuditableEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        public byte Stars { get; set; }

        [ForeignKey("FilmId")]
        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
