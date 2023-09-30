using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Services;

namespace SWD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepo _attendanceRepo;

        public AttendanceController(IAttendanceRepo attendanceRepo)
        {
            _attendanceRepo = attendanceRepo;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                return Ok(_attendanceRepo.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
