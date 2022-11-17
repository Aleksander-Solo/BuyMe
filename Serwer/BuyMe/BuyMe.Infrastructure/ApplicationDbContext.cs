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

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

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
            modelBuilder.Entity<Product>().Property(x => x.Description).HasColumnType("text");

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
    }
}
