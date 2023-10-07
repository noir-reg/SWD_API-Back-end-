using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Enums;
using SWD_API.Services;

namespace SWD_API.Controllers
{
    [Route("api/attendances")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepo _attendanceRepo;

        public AttendanceController(IAttendanceRepo attendanceRepo)
        {
            _attendanceRepo = attendanceRepo;
        }

        [Authorize(Roles = RoleConst.TeamLeader + "," + RoleConst.Intern)]
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
