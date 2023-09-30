using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public interface IInternRepo
    {
        List<InternModel> GetAll();

        InternModel GetById(string id);
    }
}
