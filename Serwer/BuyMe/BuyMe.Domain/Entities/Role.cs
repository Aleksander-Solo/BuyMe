namespace BuyMe.Domain.Entities
{
    public class Role : AuditableEntity
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
