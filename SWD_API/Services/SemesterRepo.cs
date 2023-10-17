using SWD_API.Data;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public class SemesterRepo : ISemesterRepo
    {
        private readonly SWDProjectContext _context = new();
        public InternshipSemesterModel Add(InternshipSemesterData internshipSemester)
        {
            //throw new NotImplementedException();
            var data = new InternshipSemester
            {
                Id = internshipSemester.Id,
                Name = internshipSemester.Name,
                Code = internshipSemester.Code,
                StartDate = internshipSemester.StartDate,
                EndDate = internshipSemester.EndDate,
                Status = internshipSemester.Status,
                UpdateTime = internshipSemester.UpdateTime,

            };
            _context.Add(data);
            _context.SaveChanges();
            return new InternshipSemesterModel
            {
                Id = data.Id,
                Name = data.Name,
                Code = data.Code,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Status = data.Status,
                UpdateTime = data.UpdateTime
            };
        }

        public InternshipSemesterModel GetById(string id)
        {
            //throw new NotImplementedException();
            var data = _context.InternshipSemesters.SingleOrDefault(se =>
                se.Id == Guid.Parse(id));
            if(data != null)
            {
                return new InternshipSemesterModel
                {
                    Id = data.Id,
                    Name = data.Name,
                    Code = data.Code,
                    StartDate = data.StartDate,
                    EndDate = data.EndDate,
                    Status = data.Status,
                    UpdateTime = data.UpdateTime
                };
            }
            return null;
        }

        public List<InternshipSemesterModel> GetValue(string? search)
        {
            //throw new NotImplementedException();
            var data = _context.InternshipSemesters.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(se => se.Name.Contains(search));
            }

            var result = data.Select(se => new InternshipSemesterModel
            {
                Id = se.Id,
                Name = se.Name,
                Code= se.Code,
                StartDate = se.StartDate,
                EndDate = se.EndDate,
                Status = se.Status,
                UpdateTime = se.UpdateTime

            });
            return result.ToList(); 
        }

        public void Update(InternshipSemesterModel model)
        {
            //throw new NotImplementedException();
            var data = _context.InternshipSemesters.SingleOrDefault(se =>
                    se.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Code = model.Code;
                data.StartDate = model.StartDate;
                data.EndDate = model.EndDate;
                data.Status = model.Status;
                data.UpdateTime = model.UpdateTime;
                _context.SaveChanges();
            }
        }
    }
}
