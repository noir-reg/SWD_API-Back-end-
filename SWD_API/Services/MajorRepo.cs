using SWD_API.Data;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public class MajorRepo : IMajorRepo
    {
        private readonly SWDProjectContext _context = new();
        public MajorModel Add(MajorData major)
        {
            //throw new NotImplementedException();
            var data = new Major
            {
                Id = major.Id,
                Name = major.Name,
                Code = major.Code,
                UpdateTime = major.UpdateTime,
                Status = major.Status
            };
            _context.Add(data);
            _context.SaveChanges();
            return new MajorModel
            {
                Id = data.Id,
                Name = data.Name,
                Code = data.Code,
                UpdateTime = data.UpdateTime,
                Status=data.Status
            };
        }

        public void Delete(Guid id)
        {
            //throw new NotImplementedException();
            var data = _context.Majors.SingleOrDefault(mj=>
                    mj.Id == id);
            if (data != null)
            {
                _context.Remove(data);
                _context.SaveChanges();
            }

        }

        public List<MajorModel> getAll()
        {
            //throw new NotImplementedException();
            var data = _context.Majors.Select(mj =>
                    new MajorModel
                    {
                        Id = mj.Id,
                        Name = mj.Name,
                        Code = mj.Code,
                        UpdateTime = mj.UpdateTime,
                        Status = mj.Status
                    });
            return data.ToList();
        }

        public void Update(MajorModel major)
        {
            //throw new NotImplementedException();
            var data = _context.Majors.SingleOrDefault(mj =>
                    mj.Id == major.Id);
            if(data != null)
            {
                data.Name = major.Name;
                data.Code = major.Code;
                data.UpdateTime = major.UpdateTime;
                data.Status = major.Status;
                _context.SaveChanges();
            }
        }
    }
}
