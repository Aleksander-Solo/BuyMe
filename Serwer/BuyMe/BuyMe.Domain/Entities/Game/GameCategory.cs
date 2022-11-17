namespace BuyMe.Domain.Entities
{
    public class GameCategory : AuditableEntity
    {
        public string Name { get; set; }
        public List<Game> Games { get; set; }
    }
}
