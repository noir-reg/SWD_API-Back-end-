using Microsoft.AspNetCore.Mvc;
using SWD_API.Repository.Models;
namespace SWD_API.Controllers;


[ApiController]
[Route("api/universities")]
public class UniversityController : ControllerBase {

    readonly SWDProjectContext _projectContext= new();
    

   

    [HttpGet]
    [Route("count")]
    public int Count()
    {
       
       int name= _projectContext.Universities.Count();
        return name;
    }
}