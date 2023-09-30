using SWD_API.Models;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly SWDProjectContext _context = new();


        public List<ProjectModel> GetAll()
        {
            //throw new NotImplementedException();
            var projects = _context.Projects.Select(pro =>
                    new ProjectModel
                    {
                       Id = pro.Id,
                       Name = pro.Name,
                       Description = pro.Description,
                       Code = pro.Code,
                       Status = pro.Status,
                       StartDate = pro.StartDate,
                       EndDate = pro.EndDate,
                       UpdateTime = pro.UpdateTime
                    });
            return projects.ToList();

        }

        public ProjectModel GetById(string id)
        {
            //throw new NotImplementedException();
            var project = _context.Projects.SingleOrDefault(pro =>
                pro.Id == Guid.Parse(id));
            if(project != null)
            {
                return new ProjectModel
                {
                    Id= project.Id,
                    Name= project.Name,
                    Description= project.Description,
                    Code = project.Code,
                    Status = project.Status,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    UpdateTime = project.UpdateTime
                };
            }
            return null;
        }
    }
}
