using Cliente.DTO;
using Cliente.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ServCliente _servCliente;

        public ClienteController(ServCliente servCliente)
        {
            _servCliente = servCliente;
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] InserirClienteDto inserirDto)
        {
            try
            {
                var cliente = new ClienteModel
                {
                    Nome = inserirDto.Nome,
                    Cpf = inserirDto.Cpf,
                    Email = inserirDto.Email,
                    Telefone = inserirDto.Telefone,
                    Endereco = inserirDto.Endereco,
                    Ativo = true
                };

                _servCliente.Inserir(cliente);
                return Created("", cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("/api/[controller]/{id}")]
        [HttpGet]
        public ActionResult BuscarCliente(int id)
        {
            try
            {
                var cliente = _servCliente.BuscarCliente(id);
                if (cliente == null)
                    return NotFound();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("/api/[controller]")]
        [HttpGet]
        public ActionResult BuscarTodos()
        {
            try
            {
                var listaCliente = _servCliente.BuscarTodos();
                return Ok(listaCliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("/api/[controller]/{id}")]
        [HttpPut]
        public IActionResult Editar(int id, [FromBody] ClienteModel cliente)
        {
            try
            {
                cliente.Id = id;
                _servCliente.Editar(cliente);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}