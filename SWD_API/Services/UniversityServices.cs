using Microsoft.AspNetCore.Authorization;
using SWD_API.Enums;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public class UniversityServices : IUniversityServices
    {
        private SWDProjectContext _db = new();
        public int Count()
        {
            int count = _db.Universities.Count();
            return count;
        }
    }
}
