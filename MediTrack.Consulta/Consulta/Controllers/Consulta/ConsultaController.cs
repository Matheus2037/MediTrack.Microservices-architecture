using Consulta.Domain.Consulta;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    
    [Route("api/Consulta")]
    public class ConsultaController : ControllerBase
    {
        private readonly IServiceConulta _srvConsulta;
        public ConsultaController(IServiceConulta srvConsulta) { 
            _srvConsulta = srvConsulta;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            try
            {
                return Ok(await _srvConsulta.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Consulta.Domain.Consulta.Consulta consulta)
        {
            try
            {
                await _srvConsulta.Inserir(consulta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> Put(Consulta.Domain.Consulta.Consulta consulta) {
            try
            {
                await _srvConsulta.Editar(consulta);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);    
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            try
            {
                await _srvConsulta.Deletar(id);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }

    }
}
