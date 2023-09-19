using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Models;

namespace SWD_Api.Controllers;
[ApiController]
[Route("api/universities")]
public class UniversityController : ControllerBase
{

    readonly SWDProjectContext _projectContext = new();
    [HttpGet]
    [Route("count")]
    public int Count()
    {

        int count = _projectContext.Universities.Count();
        return count;
    }
}
