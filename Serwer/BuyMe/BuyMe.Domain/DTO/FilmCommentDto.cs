namespace BuyMe.Domain.DTO
{
    public class FilmCommentDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public byte Stars { get; set; }
        public int FilmId { get; set; }
    }
}
