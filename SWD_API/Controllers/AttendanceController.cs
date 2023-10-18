using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Enums;
using SWD_API.Payload.Request.Attendance;
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

        [Authorize(Roles = RoleConst.Admin)]
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
        [Authorize(Roles = RoleConst.Intern + "," + RoleConst.TeamLeader)]
        [HttpGet("intern")]
        public async Task<IActionResult> GetInternAttendances(Guid id)
        {
            var result = await _attendanceRepo.GetInternAttendances(id);
            return Ok(result);
        }
        [Authorize(RoleConst.TeamLeader)]
        [HttpPost("create")]
        public async Task<IActionResult> CreateAttendance(CreateAttendanceRequest createAttendanceRequest)
        {
            var result = await _attendanceRepo.CreateAttendance(createAttendanceRequest);
            if (result)
                return Ok(result);
            return BadRequest("Can not create attendance");
        }
        [Authorize(RoleConst.TeamLeader)]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAttendance(Guid id, [FromQuery] string status)
        {
            var result = await _attendanceRepo.UpdateAttendanceStatus(id, status);
            if (result)
                return Ok(result);
            return BadRequest("Can not update attendance");
        }
    }
}
