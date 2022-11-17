using AutoMapper;
using BuyMe.Domain.DTO;
using BuyMe.Domain.Entities;

namespace BuyMe.Application
{
    public class MapperConfig
    {
        private readonly IMapper mMapper;

        public MapperConfig()
        {
            mMapper = new MapperConfiguration(options =>
            {
                options.CreateMap<Book, BookDto>().ForMember(x => x.BookCategory, y => y.MapFrom(z => z.BookCategory.Name)).ReverseMap();

            }).CreateMapper();
        }

        #region
        public List<Book> Map(List<BookDto> books) => mMapper.Map<List<Book>>(books);
        public List<BookDto> Map(List<Book> books) => mMapper.Map<List<BookDto>>(books);
        public Book Map(BookDto book) => mMapper.Map<Book>(book);
        public BookDto Map(Book book) => mMapper.Map<BookDto>(book);
        #endregion
    }
}
