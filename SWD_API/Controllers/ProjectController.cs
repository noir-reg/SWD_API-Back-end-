using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Enums;
using SWD_API.Services;

namespace SWD_API.Controllers
{

    [Route("api/projects")]
    [ApiController]

    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepo _projectRepo;

        public ProjectController(IProjectRepo projectRepo)
        {
            _projectRepo = projectRepo;
        }

        [Authorize(Roles = RoleConst.Admin)]
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                return Ok(_projectRepo.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = RoleConst.TeamLeader + "," + RoleConst.Intern + "," + RoleConst.Admin)]
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                return Ok(_projectRepo.GetById(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize(Roles = RoleConst.Intern)]
        [HttpGet("intern")]
        public async Task<IActionResult> GetInternProjects(Guid id)
        {
            var result= await _projectRepo.GetInternProjects(id);
            return Ok(result);
        }
    }
}
