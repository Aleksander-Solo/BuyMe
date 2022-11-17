using System.ComponentModel.DataAnnotations.Schema;

namespace BuyMe.Domain.Entities
{
    public class BookComment : AuditableEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        public byte Stars { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
