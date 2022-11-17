using System.ComponentModel.DataAnnotations.Schema;

namespace BuyMe.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        public byte Stars { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
