using BuyMe.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuyMe.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BooksCategory { get; set; }
        public DbSet<BookComment> BooksComment { get; set; }

        public DbSet<Film> Films { get; set; }
        public DbSet<FilmCategory> FilmsCategory { get; set; }
        public DbSet<FilmComment> FilmsComment { get; set; }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameCategory> GamesCategory { get; set; }
        public DbSet<GameComment> GamesComment { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(40);
            modelBuilder.Entity<Book>().Property(x => x.Title).HasMaxLength(50);
            modelBuilder.Entity<Film>().Property(x => x.Title).HasMaxLength(50);
            modelBuilder.Entity<Game>().Property(x => x.Title).HasMaxLength(50);

            modelBuilder.Entity<Book>().Property(x => x.Description).HasColumnType("text");
            modelBuilder.Entity<Film>().Property(x => x.Description).HasColumnType("text");
            modelBuilder.Entity<Game>().Property(x => x.Description).HasColumnType("text");

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }

            modelBuilder.Entity<BookCategory>().HasData(new BookCategory[7]
            {
                new BookCategory { Id=1, Name = "Fantazy", CreateDate=DateTime.Now },
                new BookCategory { Id=2, Name = "Historyczny", CreateDate=DateTime.Now },
                new BookCategory { Id=3, Name = "Sci-fi", CreateDate=DateTime.Now },
                new BookCategory { Id=4, Name = "Thriller", CreateDate=DateTime.Now },
                new BookCategory { Id=5, Name = "Horror", CreateDate=DateTime.Now },
                new BookCategory { Id=6, Name = "Biografia i reportaż", CreateDate=DateTime.Now },
                new BookCategory { Id=7, Name = "Literatura dziecięca", CreateDate=DateTime.Now }
            });
            modelBuilder.Entity<GameCategory>().HasData(new GameCategory[8]
            {
                new GameCategory { Id=1, Name = "Zręcznościowe", CreateDate=DateTime.Now },
                new GameCategory { Id=2, Name = "Przygodowe", CreateDate=DateTime.Now },
                new GameCategory { Id=3, Name = "Fabularne", CreateDate=DateTime.Now },
                new GameCategory { Id=4, Name = "Strategiczne", CreateDate=DateTime.Now },
                new GameCategory { Id=5, Name = "Symulacyjne", CreateDate=DateTime.Now },
                new GameCategory { Id=6, Name = "Sportowe", CreateDate=DateTime.Now },
                new GameCategory { Id=7, Name = "Edukacyjne", CreateDate=DateTime.Now },
                new GameCategory { Id=8, Name = "Logiczne", CreateDate=DateTime.Now }
            });
            modelBuilder.Entity<FilmCategory>().HasData(new FilmCategory[9]
            {
                new FilmCategory { Id=1, Name = "Fantazy", CreateDate=DateTime.Now },
                new FilmCategory { Id=2, Name = "Historyczny", CreateDate=DateTime.Now },
                new FilmCategory { Id=3, Name = "Sci-fi", CreateDate=DateTime.Now },
                new FilmCategory { Id=4, Name = "Thriller", CreateDate=DateTime.Now },
                new FilmCategory { Id=5, Name = "Horror", CreateDate=DateTime.Now },
                new FilmCategory { Id=6, Name = "Komedia", CreateDate=DateTime.Now },
                new FilmCategory { Id=7, Name = "Kryminał", CreateDate=DateTime.Now },
                new FilmCategory { Id=8, Name = "Muzyczny", CreateDate=DateTime.Now },
                new FilmCategory { Id=9, Name = "Przygodowy", CreateDate=DateTime.Now }
            });
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
    }
}
