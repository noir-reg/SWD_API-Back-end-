using Microsoft.AspNetCore.Mvc;
using SWD_API.Data;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public interface IUniversityServices
    {
        public Task<int> Count();
        UniversityModel Add(UniversityData university);
        List<UniversityModel> getAll();
        void Update(UniversityModel university);
        void Delete(Guid id);
    }
}
