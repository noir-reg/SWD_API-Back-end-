using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWD_API.Enums;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public class UniversityServices : IUniversityServices
    {
        private readonly SWDProjectContext _db = new();
        public async Task<int> Count()
        {
            int count = await _db.Universities.CountAsync();
            return count;
        }
    }
}
