namespace BuyMe.Domain.Entities
{
    public class BookCategory : AuditableEntity
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
