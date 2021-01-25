using System;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Model;
using SmartSchool.API.Repository.Intefaces;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/v1/disciplina")]
    public class DisciplinaController: ControllerBase
    {

        private readonly IUnitOfWork _uow;
        public DisciplinaController(IUnitOfWork uow)
        {
            _uow = uow;
        }

       [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Post(Disciplina disciplina)
        {
            try
            {
                _uow.Add(disciplina);
                _uow.Commit();
                return Ok(disciplina);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex.Message);
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