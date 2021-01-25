using System;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Model;
using SmartSchool.API.Model.Response;
using SmartSchool.API.Repository.Intefaces;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/v1/adm")]
    public class AdmController: ControllerBase
    {

        private readonly IUnitOfWork _uow;
        public AdmController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost("matricula")]
        public IActionResult MatricularAlunoId(AlunoDisciplina alunoDisciplina)
        {
            try
            {
                _uow.Add(alunoDisciplina);
                _uow.Commit();
                return Ok("Matricula realizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao realizar matricula: " + ex.Message);
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