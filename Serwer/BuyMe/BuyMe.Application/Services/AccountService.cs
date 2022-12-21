using BuyMe.Application.Exceptions;
using BuyMe.Domain.DTO;
using BuyMe.Domain.Entities;
using BuyMe.Domain.Interfaces.Application;
using BuyMe.Domain.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuyMe.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepositiory _repositiory;
        private readonly MapperConfig _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSetting _authSetting;
        public AccountService(IAccountRepositiory repositiory, MapperConfig mapper, IPasswordHasher<User> passwordHasher, AuthenticationSetting authSetting)
        {
            _repositiory = repositiory;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _authSetting = authSetting;
        }
        public void CreateUser(RegisterUserDto user)
        {
            User user1 = _mapper.Map(user);
            user1.HashPassword = _passwordHasher.HashPassword(user1, user1.HashPassword);
            _repositiory.CreateUser(user1);
        }
        public bool CheckEmail(string email)
        {
            return _repositiory.CheckEmail(email);
        }

        public UserTokenDto GenerateJwt(LoginUserDto loginUser)
        {
            User user = _repositiory.GetUser(loginUser.Email);
            if (user is null)
                throw new BadRequestException("Invalid email or password!");

            var result = _passwordHasher.VerifyHashedPassword(user, user.HashPassword, loginUser.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new BadRequestException("Invalid email or password!");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.Name),
                //new Claim("DateOfBirth", user.DateofBirth.Value.ToString("yyyy-mm-dd")),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSetting.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authSetting.JwtExpireDays);

            var token = new JwtSecurityToken(_authSetting.JwtIssuer, _authSetting.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);
            var tokenHandler = new JwtSecurityTokenHandler();

            UserTokenDto userToken = new UserTokenDto()
            {
                Name = user.Name,
                Token = tokenHandler.WriteToken(token),
                Role = user.Role.Name,
                Id = user.Id
            };
            return userToken;
        }
    }
}
