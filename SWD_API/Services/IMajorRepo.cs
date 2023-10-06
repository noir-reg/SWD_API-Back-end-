using SWD_API.Data;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public interface IMajorRepo
    {
        MajorModel Add(MajorData major);
        List<MajorModel> getAll();
        void Update(MajorModel major);
        void Delete(Guid id);
    }
}
