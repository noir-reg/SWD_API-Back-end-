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
        public IActionResult GetAll()
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

        [Authorize(Roles = RoleConst.TeamLeader + "," + RoleConst.Intern)]
        [HttpGet]
        public async Task <IActionResult> GetById(Guid id)
        {
            var result=await _workShiftRepo.GetById(id);
            return Ok(result);
        }


        [Authorize(Roles = RoleConst.TeamLeader + "," + RoleConst.Intern)]
        [HttpGet("intern")]
        public async Task<IActionResult> GetInternWorkshifts(Guid id)
        { 
            var result=await _workShiftRepo.GetInternWorkShifts(id);
            return Ok(result);
        }
    }
}
