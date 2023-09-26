
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Enums;
using SWD_API.Repository;
using SWD_API.Services;

namespace SWD_API.Controllers;


[ApiController]
[Route("api/accounts")]
public class AccountController : ControllerBase
{
    private readonly IAccountServices _service  ;

    public AccountController(IAccountServices service)
    {
        _service = service;
    }

    [AllowAnonymous]

    [HttpGet]
    [Route("login")]
    public ActionResult Login(string email)
    {
        var result = _service.Login(email);
        if (result == null)
        {
            return Unauthorized(new
            {
                StatusCode = StatusCodes.Status401Unauthorized,
                Error = "Invalid login",
                TimeStamp = DateTime.Now
            });
        }
        if (result.Status==AccountStatusConst.Inacctive )
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
}