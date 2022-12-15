using BuyMe.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BuyMe.Infrastructure
{
    public class AppSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AppSeeder(ApplicationDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.Roles.Any())
                {
                    _context.Roles.AddRange(new Role[3]
                    {
                        new Role { CreateDate = DateTime.Now, Name = "User"},
                        new Role { CreateDate = DateTime.Now, Name = "Admin"},
                        new Role { CreateDate = DateTime.Now, Name = "Owner"}
                    });
                    _context.SaveChanges();
                }
                if (!_context.Users.Any())
                {
                    User user = new User { Name = "Mr. Owner", CreateDate = DateTime.Now, Email = "someEmail@gmail.com" };
                    user.Role = _context.Roles.SingleOrDefault(x => x.Name == "Owner");
                    user.HashPassword = _passwordHasher.HashPassword(user, "Secret123!");
                    user.Picture = new byte[1];
                    _context.Users.Add(user);
                    _context.SaveChanges();
                }
            }
        }
    }
}
