using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public class InternRepo : IInternRepo
    {
        private readonly SWDProjectContext _context = new();
        public List<InternModel> GetAll()
        {
            //throw new NotImplementedException();
            var intern = _context.Interns.Select(it =>
                    new InternModel
                    {
                        Id = it.Id,
                        FullName = it.FullName,
                        UniversityId = it.UniversityId,
                        MajorId = it.MajorId,
                        InternshipSemesterId = it.InternshipSemesterId,
                        TeamId = it.TeamId,
                        Dob = it.Dob,
                        Gender = it.Gender,
                        Role = it.Role,
                        Email = it.Email,
                        PhoneNumber = it.PhoneNumber,
                        Status = it.Status,
                        UpdateTime = it.UpdateTime
                    });
            return intern.ToList();
        }

        public InternModel GetById(string id)
        {
            //throw new NotImplementedException();
            var intern = _context.Interns
                .SingleOrDefault(it =>
                    it.Id == Guid.Parse(id));
            if (intern != null)
            {
                return new InternModel
                {
                    Id = intern.Id,
                    FullName = intern.FullName,
                    UniversityId= intern.UniversityId,
                    MajorId= intern.MajorId,
                    InternshipSemesterId= intern.InternshipSemesterId,
                    TeamId = intern.TeamId,
                    Dob = intern.Dob,
                    Gender = intern.Gender,
                    Role = intern.Role,
                    Email = intern.Email,
                    PhoneNumber = intern.PhoneNumber,
                    Status = intern.Status,
                    UpdateTime = intern.UpdateTime
                };
            }
            return null;
        }
    }
}
