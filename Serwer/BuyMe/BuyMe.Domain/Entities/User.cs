using System.ComponentModel.DataAnnotations.Schema;

namespace BuyMe.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public byte[] Picture { get; set; }
        public DateOnly? DateofBirth { get; set; }

        // Relations

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<BookComment> BookComment { get; set; }
        public ICollection<FilmComment> FilmComment { get; set; }
        public ICollection<GameComment> GameComment { get; set; }
        public ICollection<Comment> Comment { get; set; }
    }
}
