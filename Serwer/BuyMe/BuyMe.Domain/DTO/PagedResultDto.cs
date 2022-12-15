namespace BuyMe.Domain.DTO
{
    public class PagedResultDto<T>
    {
        public List<T> items { get; set; }
        public int totalItemCount { get; set; }
        public int totalPages { get; set; }
        public PagedResultDto(List<T> items, int totalCount, int pageSize)
        {
            this.items = items;
            this.totalItemCount = totalCount;
            this.totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
    }
}
