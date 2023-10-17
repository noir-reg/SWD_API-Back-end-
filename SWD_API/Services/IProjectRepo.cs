using SWD_API.Models;
using SWD_API.Payload.Response.Project;

namespace SWD_API.Services
{
    public interface IProjectRepo
    {
        List<ProjectModel> GetAll();
        ProjectModel GetById(string id);
        Task<List<GetInternProjectResponse>> GetInternProjects(Guid id);
        List<ProjectModel> GetValue(string? search, string? sortbyname, int page=1);
    }
}
