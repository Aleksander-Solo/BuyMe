namespace BuyMe.Domain.DTO
{
    public class BookCommentDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public byte Stars { get; set; }
        public int BookId { get; set; }
    }
}
