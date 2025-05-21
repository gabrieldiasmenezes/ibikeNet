using Microsoft.AspNetCore.Mvc;
using ibikeNet.Model;
using ibikeNet.Model.DTO;

[ApiController]
[Route("administrador")]
public class AdministradorController : ControllerBase
{
    private readonly AdministradorService _service;

    public AdministradorController(AdministradorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Administrador>>> GetAll()
    {
        var admins = await _service.GetAllAsync();
        return Ok(admins);
    }

    [HttpGet("{cpf}")]
    public async Task<ActionResult<Administrador>> GetByCpf(string cpf)
    {
        var admin = await _service.GetByCpfAsync(cpf);
        if (admin == null)
            return NotFound("Administrador não encontrado.");

        return Ok(admin);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] AdminDto dto)
    {
        if (await _service.ExistsByCpfAsync(dto.Cpf))
            return Conflict("Já existe um administrador com este CPF.");

        var admin = new Administrador
        {
            Cpf = dto.Cpf,
            Nome = dto.Nome,
            Email = dto.Email,
            Password = dto.Password, // Se quiser aplicar hash, faça aqui
            PatioId = dto.PatioId,
            Status = dto.Status
        };

        await _service.CreateAsync(admin);
        return CreatedAtAction(nameof(GetByCpf), new { cpf = admin.Cpf }, admin);
    }

    [HttpPut("{cpf}")]
    public async Task<ActionResult> Update(string cpf, [FromBody] AdminDto dto)
    {
        var admin = await _service.GetByCpfAsync(cpf);
        if (admin == null)
            return NotFound("Administrador não encontrado.");

        admin.Nome = dto.Nome;
        admin.Email = dto.Email;
        admin.Password = dto.Password; // Novamente, aplicar hash se quiser
        admin.PatioId = dto.PatioId;
        admin.Status = dto.Status;

        await _service.UpdateAsync(admin);
        return Ok(admin);
    }

    [HttpDelete("{cpf}")]
    public async Task<ActionResult> Delete(string cpf)
    {
        var admin = await _service.GetByCpfAsync(cpf);
        if (admin == null)
            return NotFound("Administrador não encontrado.");

        await _service.DeleteAsync(admin);
        return NoContent();
    }
}
