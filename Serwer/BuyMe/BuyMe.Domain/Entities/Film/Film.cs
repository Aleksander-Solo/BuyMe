using System.ComponentModel.DataAnnotations.Schema;

namespace BuyMe.Domain.Entities
{
    public class Film : AuditableEntity
    {
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public DateOnly Releasedate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("FilmCategoryId")]
        public int FilmCategoryId { get; set; }
        public FilmCategory FilmCategory { get; set; }
        public List<FilmComment> FilmComments { get; set; }

    }
}
