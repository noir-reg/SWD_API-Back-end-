using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public interface IWorkShiftRepo
    {
        List<WorkShiftModel> GetAll();
    }
}
