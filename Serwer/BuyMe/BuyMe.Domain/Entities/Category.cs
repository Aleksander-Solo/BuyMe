namespace BuyMe.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
