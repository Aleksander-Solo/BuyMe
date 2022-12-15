using BuyMe.Domain.Entities;
using BuyMe.Domain.Interfaces.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BuyMe.Infrastructure.Repositiores
{
    public class AccountRepositiory : IAccountRepositiory
    {
        private readonly ApplicationDbContext _context;
        public AccountRepositiory(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CheckEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public void CreateUser(User user)
        {
            user.CreateDate = DateTime.Now;
            user.Role = _context.Roles.First(x => x.Name == "User");
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(string email)
        {
            return _context.Users.Include(x => x.Role).FirstOrDefault(x => x.Email == email);
        }
    }
}
