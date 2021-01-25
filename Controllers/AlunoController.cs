using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Model;
using SmartSchool.API.Repository.Intefaces;
using SmartSchool.API.Repository.UnitOfWork;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/v1/alunos")]
    public class AlunoController: ControllerBase
    {

        private readonly IUnitOfWork _uow;
        public AlunoController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok();
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Aluno aluno)
        {
            try
            {
                _uow.Add(aluno);
                _uow.Commit();
                return Ok(aluno);                
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
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}