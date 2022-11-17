using System.ComponentModel.DataAnnotations.Schema;

namespace BuyMe.Domain.Entities
{
    public class Book : AuditableEntity
    {
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publishinghosue { get; set; }
        public DateOnly Releasedate { get; set; }
        public int NumOfPag { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        // Relations
        [ForeignKey("BookCategoryId")]
        public int BookCategoryId { get; set; }
        public BookCategory BookCategory { get; set; }
        public List<BookComment> BookComments { get; set; }
    }
}
