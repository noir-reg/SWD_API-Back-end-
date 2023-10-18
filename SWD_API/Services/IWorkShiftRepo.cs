using SWD_API.Payload.Request.WorkShift;
using SWD_API.Payload.Response.InternWorkShift;
using SWD_API.Repository.Models;

namespace SWD_API.Services;

public interface IWorkShiftRepo
{
    List<WorkShiftModel> GetAll();
    Task<WorkShiftModel> GetById(Guid id);
    Task<List<GetInternWorkShiftResponse>> GetInternWorkShifts(Guid id);
    Task<List<WorkShiftModel>> GetTeamWorkShifts(Guid teamLeaderId);
    Task<bool> CreateTeamWorkShift(CreateTeamWorkShiftRequest createTeamWorkShiftRequest);
    Task<bool> UpdateTeamWorkShift(UpdateTeamWorkShiftRequest updateTeamWorkShiftRequest);   
    Task<bool> DeleteTeamWorkShift(Guid id);
    Task<bool> CreateInternWorkShift(Guid workShiftId,Guid internId,DateTime checkIn,DateTime checkOut);
    Task<bool> UpdateInternWorkShift(UpdateInternWorkShiftRequest updateTeamWorkShiftRequest);
    Task<bool> DeleteInternWorkShift(Guid id);
}