using SWD_API.Payload.Response.InternWorkShift;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public interface IWorkShiftRepo
    {
        List<WorkShiftModel> GetAll();
        Task<WorkShiftModel> GetById(Guid id);
        Task<List<GetInternWorkShiftResponse>> GetInternWorkShifts(Guid id);
    }
}
