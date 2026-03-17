using Microsoft.AspNetCore.Mvc;
using PlataformaCursos.Applications.Services;
using PlataformaCursos.DTOs.MatriculaDto;
using PlataformaCursos.Exceptions;

namespace PlataformaCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly MatriculaService _service;

        public MatriculaController(MatriculaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerMatriculaDto>> Listar()
        {
            List<LerMatriculaDto> matriculas = _service.Listar();

            return Ok(matriculas); 
        }

        [HttpGet("{id}")]
        public ActionResult<LerMatriculaDto> ObterPorId(int id)
        {
            try
            {
                LerMatriculaDto matricula = _service.ObterPorId(id);
                return Ok(matricula);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpPost]
        public ActionResult<LerMatriculaDto> Adicionar(CriarMatriculaDto matriculaDto)
        {
            try 
            {
                LerMatriculaDto matriculaCriada = _service.Adicionar(matriculaDto);
                return StatusCode(201, matriculaCriada);
            }
            catch (DomainException ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
