using BuyMe.Domain.DTO;

namespace BuyMe.Domain.Interfaces.Application
{
    public interface IAccountService
    {
        public void CreateUser(RegisterUserDto user);
        public bool CheckEmail(string email);
        public UserTokenDto GenerateJwt(LoginUserDto loginUser);
    }
}
