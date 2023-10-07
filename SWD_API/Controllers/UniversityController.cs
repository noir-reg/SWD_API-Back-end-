
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Data;
using SWD_API.Enums;
using SWD_API.Repository;
using SWD_API.Repository.Models;
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
    //[Authorize(Roles =RoleConst.Admin)]
    [HttpGet]
    [Route("count")]
    public async Task<ActionResult> CountUniversities()
    {
        var count =  await _service.Count();
        return Ok(count);
    }

    [Authorize(Roles =RoleConst.Admin)]
    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            return Ok(_service.getAll());
        }
        catch
        {
            return BadRequest();
        }
    }

    [Authorize(Roles = RoleConst.Admin)]
    [HttpPost]
    public IActionResult Add(UniversityData university)
    {
        try
        {
            var data = _service.Add(university);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [Authorize(Roles = RoleConst.Admin)]
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, UniversityModel university)
    {
        if(id != university.Id)
        {
            return BadRequest();
        }
        try
        {
            _service.Update(university);
            return Ok();
        }
        catch
        {
            return BadRequest("Error at server side");
        }
    }

    [Authorize(Roles = RoleConst.Admin)]
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _service.Delete(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}