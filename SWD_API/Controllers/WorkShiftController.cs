using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Enums;
using SWD_API.Payload.Request.WorkShift;
using SWD_API.Repository.Models;
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
        [HttpGet("{id}")]
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

        [Authorize(Roles = RoleConst.TeamLeader)]
        [HttpGet]
        [Route("intern/create")]
       public async Task<IActionResult> CreateInternWorkShift(Guid workShiftId, Guid internId,[FromQuery] DateTime checkIn,[FromQuery] DateTime checkOut)
        {
            var result =await  _workShiftRepo.CreateInternWorkShift(workShiftId, internId, checkIn, checkOut);
            if(result)
                return Ok(result);
            return BadRequest("Can not create intern workshift");
        }
        [Authorize(Roles = RoleConst.TeamLeader)]
        [HttpPost]
        [Route("team/create")]
        public async Task<IActionResult> CreateTeamWorkShift(CreateTeamWorkShiftRequest createTeamWorkShiftRequest)
        {
            var result = await _workShiftRepo.CreateTeamWorkShift(createTeamWorkShiftRequest);
            if (result)
                return Ok(result);
            return BadRequest("Can not create intern workshift");
        }
        [Authorize(Roles = RoleConst.TeamLeader)]
        [HttpDelete]
        [Route("team/delete")]
        public async Task<IActionResult> DeleteTeamWorkShift(Guid id)
        {
            var result=await _workShiftRepo.DeleteTeamWorkShift(id);
            if(result)
            return Ok(result);
            return BadRequest("Can not delete team workshift");
        }
        [Authorize(Roles = RoleConst.TeamLeader)]
        [HttpDelete]
        [Route("intern/delete")]
        public async Task<IActionResult> DeleteInternWorkShift(Guid id)
        {
            var result =await _workShiftRepo.DeleteInternWorkShift(id);
            if (result)
                return Ok(result);
            return BadRequest("Can not delete intern workshift");
        }

        [Authorize(Roles = RoleConst.TeamLeader)]
        [HttpGet]
        [Route("team")]
        public async Task<IActionResult> GetTeamWorkShifts(Guid teamLeaderId)
        {
            var result = await _workShiftRepo.GetTeamWorkShifts(teamLeaderId);
            return Ok(result);
        }

        [Authorize(Roles = RoleConst.TeamLeader)]
        [HttpPut]
        [Route("team/update")]
        public async Task<IActionResult> UpdateTeamWorkShift(UpdateTeamWorkShiftRequest updateTeamWorkShiftRequest)
        {
            var result=await _workShiftRepo.UpdateTeamWorkShift(updateTeamWorkShiftRequest);
            if(result) return Ok(result);
            return BadRequest("Can not update team workshift");
        }
        [Authorize(Roles = RoleConst.TeamLeader)]
        [HttpPut]
        [Route("intern/update")]
        public async Task<IActionResult> UpdateInternWorkShift(UpdateInternWorkShiftRequest updateInternWorkShiftRequest)
        {
            var result = await _workShiftRepo.UpdateInternWorkShift(updateInternWorkShiftRequest);
            if (result) return Ok(result);
            return BadRequest("Can not update intern workshift");
        }
    }
}
