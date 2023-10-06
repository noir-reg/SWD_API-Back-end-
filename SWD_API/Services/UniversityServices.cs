using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWD_API.Data;
using SWD_API.Enums;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public class UniversityServices : IUniversityServices
    {
        private readonly SWDProjectContext _db = new();

        public UniversityModel Add(UniversityData university)
        {
            //throw new NotImplementedException();
            var data = new University
            {
                Id = university.Id,
                Name = university.Name,
                Code = university.Code,
                UpdateTime = university.UpdateTime,
                Status = university.Status,
            };
            _db.Add(data);
            _db.SaveChanges();

            return new UniversityModel
            {
                Id = data.Id,
                Name = data.Name,
                Code = data.Code,
                UpdateTime = data.UpdateTime,
                Status = data.Status
            };
        }

        public async Task<int> Count()
        {
            int count = await _db.Universities.CountAsync();
            return count;
        }

        public void Delete(Guid id)
        {
            //throw new NotImplementedException();
            var data = _db.Universities.SingleOrDefault(uni =>
                    uni.Id == id);
            if (data != null)
            {
                _db.Remove(data);
                _db.SaveChanges();
            }
        }

        public List<UniversityModel> getAll()
        {
            //throw new NotImplementedException();
            var data = _db.Universities.Select(uni =>
                    new UniversityModel
                    {
                        Id = uni.Id,
                        Name = uni.Name,
                        Code = uni.Code,
                        UpdateTime = uni.UpdateTime,
                        Status = uni.Status,
                    });
            return data.ToList();
        }

        public void Update(UniversityModel university)
        {
            //throw new NotImplementedException();
            var data = _db.Universities.SingleOrDefault(uni =>
                    uni.Id == university.Id);
            if (data != null)
            {
                data.Name = university.Name;
                data.Code = university.Code;
                data.UpdateTime = university.UpdateTime;
                data.Status = university.Status;
                _db.SaveChanges();

            }
            

        }
    }
}
