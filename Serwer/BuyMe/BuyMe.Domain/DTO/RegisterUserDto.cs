namespace BuyMe.Domain.DTO
{
    public class RegisterUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateOnly? DateofBirth { get; set; }
        public byte[] Picture { get; set; }
    }
}
