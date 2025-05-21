using Microsoft.AspNetCore.Mvc;
using ibikeNet.Dtos;

[ApiController]
[Route("motos")]
public class MotoController : ControllerBase
{
    private readonly MotoService _service;
    private readonly ILogger<MotoController> _logger;

    public MotoController(MotoService service, ILogger<MotoController> logger)
    {
        _service = service;
        _logger = logger;
    }

    // GET /motos
    [HttpGet]
    public async Task<ActionResult<List<MotoReadDto>>> GetAll()
    {
        var motos = await _service.GetAllAsync();
        return Ok(motos);
    }

    // GET /motos/{placa}
    [HttpGet("{placa}")]
    public async Task<ActionResult<MotoReadDto>> GetByPlaca(string placa)
    {
        var moto = await _service.GetByPlacaAsync(placa);
        if (moto == null) return NotFound();
        return Ok(moto);
    }


    // POST /motos
    [HttpPost]
    public async Task<ActionResult<MotoReadDto>> Create([FromBody] MotoCreateDto dto)
    {
        _logger.LogInformation($"Cadastrando moto {dto.Placa}");
        var moto = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetByPlaca), new { placa = moto.Placa }, moto);
    }

    // PUT /motos/{placa}
    [HttpPut("{placa}")]
    public async Task<IActionResult> Update(string placa, [FromBody] MotoUpdateDto dto)
    {
        var updated = await _service.UpdateAsync(placa, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    // DELETE /motos/{placa}
    [HttpDelete("{placa}")]
    public async Task<IActionResult> Delete(string placa)
    {
        var deleted = await _service.DeleteAsync(placa);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
