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

        [Authorize(Roles =RoleConst.Admin)]
        [HttpGet]
        public IActionResult GetAll()
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
        [Authorize(Roles=RoleConst.Intern+","+RoleConst.TeamLeader)]
        [HttpGet("intern")]
        public async Task<IActionResult> GetInternAttendances(Guid id)
        {
            var result=await _attendanceRepo.GetInternAttendances(id);
            return Ok(result);
        }
    }
}
