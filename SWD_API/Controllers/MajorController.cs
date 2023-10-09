using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD_API.Data;
using SWD_API.Enums;
using SWD_API.Repository.Models;
using SWD_API.Services;

namespace SWD_API.Controllers
{
    [Route("api/majors")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private readonly IMajorRepo _majorRepo;

        public MajorController(IMajorRepo majorRepo)
        {
            _majorRepo = majorRepo;
        }

        [Authorize(Roles = RoleConst.Admin+","+RoleConst.Intern)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_majorRepo.getAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = RoleConst.Admin)]
        [HttpPost]
        public IActionResult Add(MajorData majorData)
        {
            try
            {
                var data = _majorRepo.Add(majorData);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = RoleConst.Admin)]
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, MajorModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            try
            {
                _majorRepo.Update(model);
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
                _majorRepo.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest("Error at server side");
            }
        }
    }
}
