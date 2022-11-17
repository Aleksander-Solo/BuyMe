namespace BuyMe.Domain.Entities
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
