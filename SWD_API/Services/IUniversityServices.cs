using Microsoft.AspNetCore.Mvc;

namespace SWD_API.Services
{
    public interface IUniversityServices
    {
        public Task<int> Count();
    }
}
