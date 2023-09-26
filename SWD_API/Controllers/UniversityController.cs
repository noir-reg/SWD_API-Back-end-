
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Enums;
using SWD_API.Repository;
using SWD_API.Services;

namespace SWD_API.Controllers;


[ApiController]
[Route("api/universities")]
public class UniversityController : ControllerBase
{
    private readonly IUniversityServices _service;
     public UniversityController(IUniversityServices service)
    {
        _service = service;
    }

    // [AllowAnonymous]
    [Authorize(Roles =RoleConst.Admin)]
    [HttpGet]
    [Route("count")]
    public ActionResult CountUniversities()
    {
        var count = _service.Count();
        return Ok(count);
    }
}