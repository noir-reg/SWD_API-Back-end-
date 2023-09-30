using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Services;

namespace SWD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternController : ControllerBase
    {
        private readonly IInternRepo _internRepo;

        public InternController(IInternRepo internRepo)
        {
            _internRepo = internRepo;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                return Ok(_internRepo.GetAll());
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
                return Ok(_internRepo.GetById(id));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
