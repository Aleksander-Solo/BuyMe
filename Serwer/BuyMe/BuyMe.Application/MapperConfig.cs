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
                options.CreateMap<Book, CreateBookDto>().ReverseMap();
                options.CreateMap<Film, FilmDto>().ForMember(x => x.FilmCategory, y => y.MapFrom(z => z.FilmCategory.Name)).ReverseMap();
                options.CreateMap<Game, GameDto>().ForMember(x => x.GameCategory, y => y.MapFrom(z => z.GameCategory.Name)).ReverseMap();
                options.CreateMap<BookCommentDto, BookComment>().ReverseMap();

            }).CreateMapper();
        }

        #region Book
        public List<Book> Map(List<BookDto> books) => mMapper.Map<List<Book>>(books);
        public List<BookDto> Map(List<Book> books) => mMapper.Map<List<BookDto>>(books);
        public Book Map(BookDto book) => mMapper.Map<Book>(book);
        public BookDto Map(Book book) => mMapper.Map<BookDto>(book);
        public Book Map(CreateBookDto book) => mMapper.Map<Book>(book);
        #endregion

        #region Film
        public List<Film> Map(List<FilmDto> films) => mMapper.Map<List<Film>>(films);
        public List<FilmDto> Map(List<Film> films) => mMapper.Map<List<FilmDto>>(films);
        public Film Map(FilmDto film) => mMapper.Map<Film>(film);
        public FilmDto Map(Film film) => mMapper.Map<FilmDto>(film);
        #endregion

        #region Game
        public List<Game> Map(List<GameDto> games) => mMapper.Map<List<Game>>(games);
        public List<GameDto> Map(List<Game> games) => mMapper.Map<List<GameDto>>(games);
        public Game Map(GameDto game) => mMapper.Map<Game>(game);
        public GameDto Map(Game game) => mMapper.Map<GameDto>(game);
        #endregion
    }
}
