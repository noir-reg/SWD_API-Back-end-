using SWD_API.Data;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public interface ISemesterRepo
    {
        InternshipSemesterModel GetById(string id);
        InternshipSemesterModel Add(InternshipSemesterData internshipSemester);
        void Update(InternshipSemesterModel model);
        List<InternshipSemesterModel> GetValue(string? search);
    }
}
