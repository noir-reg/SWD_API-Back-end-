using SWD_API.Payload.Response;

namespace SWD_API.Services
{
    public interface IAccountServices
    {
        public LoginResponse? Login(string email);
    }
}
