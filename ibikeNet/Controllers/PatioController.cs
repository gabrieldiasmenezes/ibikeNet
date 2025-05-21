using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ibikeNet.Data;
using ibikeNet.Model;
using ibikeNet.components;
using ibikeNet.Services;
using ibikeNet.Model.DTO;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("patio")]
public class PatioController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<PatioController> _logger;
    private readonly PatioService _patioService;

    public PatioController(AppDbContext context, ILogger<PatioController> logger, PatioService patioService)
    {
        _context = context;
        _logger = logger;
        _patioService = patioService;
    }

    // GET /patio
    [HttpGet]
    public async Task<ActionResult<List<PatioDTO>>> Listar()
    {
        var patios = await _patioService.ListarPatiosAsync();
        return Ok(patios);
    }

    // POST /patio
    [HttpPost]
    public async Task<ActionResult<Patio>> Create([FromBody] Patio patio)
    {
        _logger.LogInformation($"Cadastrando pátio {patio.Nome}");

        _context.Patios.Add(patio);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = patio.Id }, patio);
    }

    // GET /patio/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Patio>> GetById(long id)
    {
        _logger.LogInformation($"Buscando pátio {id}");

        var patio = await _context.Patios.FindAsync(id);

        if (patio == null)
            return NotFound(new { message = "Pátio não encontrado" });

        return Ok(patio);
    }

    // GET /patio/filtro?status=Ativo
    [HttpGet("filtro")]
    public async Task<ActionResult<List<Patio>>> FiltrarPorStatus([FromQuery] StatusPatio? status)
    {
        var query = _context.Patios.AsQueryable();

        if (status.HasValue)
            query = query.Where(p => p.Status == status.Value);

        var patios = await query.ToListAsync();

        return Ok(patios);
    }
}
