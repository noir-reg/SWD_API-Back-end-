
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using SWD_API.Enums;
using SWD_API.Payload.Request.Account;
using SWD_API.Repository;
using SWD_API.Services;

namespace SWD_API.Controllers;


[ApiController]
[Route("api/accounts")]
public class AccountController : ControllerBase
{
    private readonly IAccountServices _service;

    public AccountController(IAccountServices service)
    {
        _service = service;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] string email)
    {
        var result = await _service.Login(email);
        if (result == null)
        {
            return Unauthorized(new
            {
                StatusCode = StatusCodes.Status401Unauthorized,
                Error = "Invalid login",
                TimeStamp = DateTime.Now
            });
        }
        if (result.Status == AccountStatusConst.Inacctive)
        {
            return Unauthorized(new
            {
                StatusCode = StatusCodes.Status401Unauthorized,
                Error = "Inactive account",
                TimeStamp = DateTime.Now
            });
        }
        return Ok(result);
    }
    [AllowAnonymous]
    [HttpPost]
    [Route("detail")]
    public async Task<IActionResult> GetAccountDetail(GetAccountRequest getAccountRequest)
    {
        var result = await _service.GetAcccountDetail(getAccountRequest);

        return Ok(result);

    }
    [Authorize(Roles = RoleConst.Admin + "," + RoleConst.TeamLeader)]
    [HttpPatch]
    [Route("status/update")]
    public async Task<IActionResult> UpdateAccountStatus(UpdateAccountStatusRequest updateAccountStatusRequest)
    {
        var result = await _service.UpdateAccountStatus(updateAccountStatusRequest);
        if (result)
            return Ok(result);
        return Ok("Fail to update account status");
    }
    [Authorize(Roles = RoleConst.Intern)]
    [HttpPatch]
    [Route("intern/update")]
    public async Task<IActionResult> UpdateInternInfor(UpdateInternInforRequest updateInternInforRequest) { 
        var result= await _service.UpdateInternInfor(updateInternInforRequest);
        if(result)
        return Ok("Update successfully");
        else
        return Ok("Fail to update infor");

     }
    [Authorize(Roles = RoleConst.TeamLeader)]
    [HttpGet]
    [Route("team/members")]
    public async Task<IActionResult> GetTeamMembers(Guid teamLeaderId)
    {
        var result = await _service.GetTeamMembers(teamLeaderId);
        return Ok(result);
    }
   
}