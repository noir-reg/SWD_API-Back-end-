﻿using Microsoft.EntityFrameworkCore;
using SWD_API.Models;
using SWD_API.Payload.Response.Project;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly SWDProjectContext _context = new();
        public static int PAGE_SIZE { get; set; } = 5;
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

        public async Task<List<GetInternProjectResponse>> GetInternProjects(Guid id)
        {
            var list=await _context.InternProjectMappings.Where(x=>x.InternId.Equals(id)).Include(x=>x.Project).Select(x=>new GetInternProjectResponse
            {
                Id= x.Id,
                ProjectId= x.ProjectId,
                ProjectName=x.Project==null?null:x.Project.Name,
                UpdateTime= x.UpdateTime
            }).ToListAsync();
            return list;
        }

        public List<ProjectModel> GetValue(string? search, string? sortbyname, int page=1)
        {
            //throw new NotImplementedException();
            var value = _context.Projects.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                value = value.Where(pro => pro.Name.Contains(search));
            }

            value = value.OrderBy(pro => pro.Name);

            if (!string.IsNullOrEmpty(sortbyname))
            {
                switch (sortbyname)
                {
                    case "name_asc":
                        value = value.OrderBy(pro =>
                        pro.Name); break;
                    case "name_desc":
                        value = value.OrderByDescending(pro =>
                        pro.Name); break;
                }
            }

            value = value.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);

            var result = value.Select(pro => new ProjectModel
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

            return result.ToList();
        }
    }
}
