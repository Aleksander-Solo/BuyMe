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
                options.CreateMap<Book, BookDto>()
                    .ForMember(x => x.BookCategory, y => y.MapFrom(z => z.BookCategory.Name)).ReverseMap();
                options.CreateMap<Book, CreateBookDto>().ReverseMap();
                options.CreateMap<Film, FilmDto>().ForMember(x => x.FilmCategory, y => y.MapFrom(z => z.FilmCategory.Name)).ReverseMap();
                options.CreateMap<Film, CreateFilmDto>().ReverseMap();
                options.CreateMap<Game, GameDto>().ForMember(x => x.GameCategory, y => y.MapFrom(z => z.GameCategory.Name)).ReverseMap();
                options.CreateMap<Game, CreateGameDto>().ReverseMap();
                //Comments
                options.CreateMap<BookCommentDto, BookComment>().ReverseMap(); ;
                options.CreateMap<FilmCommentDto, FilmComment>();
                options.CreateMap<GameCommentDto, GameComment>();
                //Users
                options.CreateMap<RegisterUserDto, User>().ForMember(x => x.HashPassword, y => y.MapFrom(z => z.Password));
                //Category
                options.CreateMap<BookCategoryDto, BookCategory>().ReverseMap();

            }).CreateMapper();
        }
        #region User
        public User Map(RegisterUserDto user) => mMapper.Map<User>(user);
        #endregion

        #region Book
        public IEnumerable<Book> Map(IEnumerable<BookDto> books) => mMapper.Map<IEnumerable<Book>>(books);
        public IEnumerable<BookDto> Map(IEnumerable<Book> books) => mMapper.Map<IEnumerable<BookDto>>(books);
        public Book Map(BookDto book) => mMapper.Map<Book>(book);
        public BookDto Map(Book book) => mMapper.Map<BookDto>(book);
        public Book Map(CreateBookDto book) => mMapper.Map<Book>(book);
        public BookComment Map(BookCommentDto comment) => mMapper.Map<BookComment>(comment);
        public List<BookCategoryDto> Map(List<BookCategory> bookCategory) => mMapper.Map<List<BookCategoryDto>>(bookCategory);
        public BookCategory Map(BookCategoryDto bookCategory) => mMapper.Map<BookCategory>(bookCategory);
        #endregion

        #region Film
        public List<Film> Map(List<FilmDto> films) => mMapper.Map<List<Film>>(films);
        public List<FilmDto> Map(List<Film> films) => mMapper.Map<List<FilmDto>>(films);
        public Film Map(FilmDto film) => mMapper.Map<Film>(film);
        public FilmDto Map(Film film) => mMapper.Map<FilmDto>(film);
        public Film Map(CreateFilmDto film) => mMapper.Map<Film>(film);
        public FilmComment Map(FilmCommentDto film) => mMapper.Map<FilmComment>(film);
        #endregion

        #region Game
        public List<Game> Map(List<GameDto> games) => mMapper.Map<List<Game>>(games);
        public List<GameDto> Map(List<Game> games) => mMapper.Map<List<GameDto>>(games);
        public Game Map(GameDto game) => mMapper.Map<Game>(game);
        public GameDto Map(Game game) => mMapper.Map<GameDto>(game);
        public Game Map(CreateGameDto game) => mMapper.Map<Game>(game);
        public GameComment Map(GameCommentDto game) => mMapper.Map<GameComment>(game);
        #endregion
    }
}
