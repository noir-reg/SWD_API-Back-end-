using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
 
using SWD_API.Enums;
using SWD_API.Models;
using SWD_API.Repository;
namespace SWD_API.Controllers;


[ApiController]
[Route("api/universities")]
public class UniversityController : ControllerBase {

    readonly SWDProjectContext _projectContext = new();   
    [HttpGet]
    [Route("count")]
    public int Count()
    {
       
       int count= _projectContext.Universities.Count();
        return count;
    }
}