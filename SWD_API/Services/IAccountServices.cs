using SWD_API.Payload.Request.Account;
using SWD_API.Payload.Response;
using SWD_API.Payload.Response.Account;

namespace SWD_API.Services
{
    public interface IAccountServices
    {
        public Task <LoginResponse>? Login(string email);
        public Task< GetAccountResponse>? GetAcccountDetail(GetAccountRequest getAccountRequest);
        public Task<bool> UpdateAccountStatus(UpdateAccountStatusRequest updateAcccountStatusRequest);

    }
}
