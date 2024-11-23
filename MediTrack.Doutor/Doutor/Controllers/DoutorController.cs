using Doutor.DTO;
using Doutor.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Doutor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoutorController : ControllerBase
    {
        private readonly ServDoutor _servDoutor;

        public DoutorController(ServDoutor servDoutor)
        {
            _servDoutor = servDoutor;
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] InserirDoutorDto inserirDto)
        {
            try
            {
                var doutor = new DoutorModel
                {
                    Nome = inserirDto.Nome,
                    Cpf = inserirDto.Cpf,
                    Email = inserirDto.Email,
                    Telefone = inserirDto.Telefone,
                    Endereco = inserirDto.Endereco,
                    Ativo = true
                };

                _servDoutor.Inserir(doutor);
                return Created("", doutor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult BuscarDoutor(int id)
        {
            try
            {
                var doutor = _servDoutor.BuscarDoutor(id);
                if (doutor == null)
                    return NotFound();

                return Ok(doutor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult BuscarTodos()
        {
            try
            {
                var listaDoutores = _servDoutor.BuscarTodos();
                return Ok(listaDoutores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] DoutorModel doutor)
        {
            try
            {
                doutor.Id = id;
                _servDoutor.Editar(doutor);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}