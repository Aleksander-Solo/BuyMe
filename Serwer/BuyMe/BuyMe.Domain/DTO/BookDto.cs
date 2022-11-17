using BuyMe.Domain.Entities;

namespace BuyMe.Domain.DTO
{
    public class BookDto
    {
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publishinghosue { get; set; }
        public DateOnly Releasedate { get; set; }
        public int NumOfPag { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string BookCategory { get; set; }
        public List<BookComment> BookComments { get; set; }
    }
}
