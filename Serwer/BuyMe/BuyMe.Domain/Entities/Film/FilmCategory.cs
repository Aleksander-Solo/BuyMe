namespace BuyMe.Domain.Entities
{
    public class FilmCategory : AuditableEntity
    {
        public string Name { get; set; }
        public List<Film> Films { get; set; }
    }
}
