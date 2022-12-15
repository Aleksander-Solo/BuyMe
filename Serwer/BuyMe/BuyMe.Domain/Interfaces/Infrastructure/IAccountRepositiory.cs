using BuyMe.Domain.Entities;

namespace BuyMe.Domain.Interfaces.Infrastructure
{
    public interface IAccountRepositiory
    {
        public void CreateUser(User user);
        public bool CheckEmail(string email);
        public User GetUser(string email);
    }
}
