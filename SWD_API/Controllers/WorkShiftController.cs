using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Enums;
using SWD_API.Services;

namespace SWD_API.Controllers
{
    [Route("api/workshifts")]
    [ApiController]
    public class WorkShiftController : ControllerBase
    {
        private readonly IWorkShiftRepo _workShiftRepo;

        public WorkShiftController(IWorkShiftRepo workShiftRepo)
        {
            _workShiftRepo = workShiftRepo;
        }

        [Authorize(Roles = RoleConst.TeamLeader + "," + RoleConst.Intern)]
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
