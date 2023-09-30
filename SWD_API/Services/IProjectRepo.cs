using SWD_API.Models;

namespace SWD_API.Services
{
    public interface IProjectRepo
    {
        List<ProjectModel> GetAll();
        ProjectModel GetById(string id);
    }
}
