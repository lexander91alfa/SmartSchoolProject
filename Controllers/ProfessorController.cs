using System;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Model;
using SmartSchool.API.Repository.Intefaces;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/v1/professores")]
    public class ProfessorController: ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public ProfessorController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            try
            {
                _uow.Add(professor);
                _uow.Commit();
                return Ok(professor);                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }
        [HttpPatch]
        public IActionResult Patch()
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}