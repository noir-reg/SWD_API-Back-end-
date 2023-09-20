
using Microsoft.AspNetCore.Mvc;
using SWD_API.Enums;
using SWD_API.Repository;
using SWD_API.Services;

namespace SWD_API.Controllers;


[ApiController]
[Route("api/universities")]
public class UniversityController : ControllerBase
{
    private IUniversityServices service = new UniversityServices();
    [HttpGet]
    [Route("count")]
    public int CountUniversities()
    {
        int count = service.Count();
        return count;
    }
}