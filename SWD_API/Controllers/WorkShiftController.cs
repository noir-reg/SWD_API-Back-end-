using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Services;

namespace SWD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkShiftController : ControllerBase
    {
        private readonly IWorkShiftRepo _workShiftRepo;

        public WorkShiftController(IWorkShiftRepo workShiftRepo)
        {
            _workShiftRepo = workShiftRepo;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                return Ok(_workShiftRepo.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
