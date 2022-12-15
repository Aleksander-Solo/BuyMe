namespace BuyMe.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string meesage) : base(meesage)
        {
        }
    }
}
