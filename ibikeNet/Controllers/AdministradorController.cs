using Microsoft.AspNetCore.Mvc;
using ibikeNet.dto;
using ibikeNet.Services;
namespace ibikeNet.Controllers
{
    [ApiController]
    [Route("/administrador")]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorService _service;

        public AdministradorController(IAdministradorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdministradorResultDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<AdministradorResultDto>> GetById(string cpf)
        {
            var result = await _service.GetByIdAsync(cpf);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AdministradorResultDto>> Create(AdministradorCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { cpf = result.Cpf }, result);
        }

        [HttpPut("{cpf}")]
        public async Task<IActionResult> Update(string cpf, AdministradorUpdateDto dto)
        {
            await _service.UpdateAsync(cpf, dto);
            return NoContent();
        }

        [HttpDelete("{cpf}")]
        public async Task<IActionResult> Delete(string cpf)
        {
            await _service.DeleteAsync(cpf);
            return NoContent();
        }
    }
}