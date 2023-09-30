using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Services;

namespace SWD_API.Controllers
{
    [Route("api/[controller]")]   
    //[Route("api/projects")]
    [ApiController]

    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepo _projectRepo;

        public ProjectController(IProjectRepo projectRepo)
        {
            _projectRepo = projectRepo;
        }

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
    }
}
