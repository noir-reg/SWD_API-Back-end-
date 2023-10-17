using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Enums;
using SWD_API.Services;

namespace SWD_API.Controllers
{
    [Route("api/projectextensives")]
    [ApiController]
    public class ProjectExtensiveController : ControllerBase
    {
        private readonly IProjectRepo _projectRepo;

        public ProjectExtensiveController(IProjectRepo projectRepo)
        {
            _projectRepo = projectRepo;
        }

        [Authorize(Roles = RoleConst.TeamLeader + "," + RoleConst.Intern)]
        [HttpGet]
        public IActionResult GetValue(string? search, string? sortbyname, int page=1)
        {
            try
            {
                var result = _projectRepo.GetValue(search, sortbyname, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
