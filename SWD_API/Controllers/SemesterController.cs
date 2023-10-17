using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Data;
using SWD_API.Enums;
using SWD_API.Repository.Models;
using SWD_API.Services;

namespace SWD_API.Controllers
{
    [Route("api/semesters")]
    //[Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterRepo _semesterRepo;

        public SemesterController(ISemesterRepo semesterRepo)
        {
            _semesterRepo = semesterRepo;
        }

        [Authorize(Roles = RoleConst.Admin)]
        [HttpGet("{id}")]
        public IActionResult GetbyId(string id)
        {
            try
            {
                var data = _semesterRepo.GetById(id);

                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = RoleConst.Admin)]
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, InternshipSemesterModel model)
        {
            if(id != model.Id)
            {
                return BadRequest();
            }
            try
            {
                _semesterRepo.Update(model);
                return Ok();
            }
            catch
            {
                return BadRequest("Error at server side");
            }
        }

        [Authorize(Roles = RoleConst.Admin)]
        [HttpPost]
        public IActionResult Add(InternshipSemesterData data)
        {
            try
            {
                return Ok(_semesterRepo.Add(data));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = RoleConst.Admin)]
        [HttpGet]
        public IActionResult getValue(string? search)
        {
            try
            {
                return Ok(_semesterRepo.GetValue(search));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
