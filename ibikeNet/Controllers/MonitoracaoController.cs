using Microsoft.AspNetCore.Mvc;
using ibikeNet.Model;

[ApiController]
[Route("monitoracao")]
public class MonitoracaoController : ControllerBase
{
    private readonly MonitoracaoService _monitoracaoService;
    private readonly ILogger<MonitoracaoController> _logger;

    public MonitoracaoController(MonitoracaoService monitoracaoService, ILogger<MonitoracaoController> logger)
    {
        _monitoracaoService = monitoracaoService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<Monitoracao>>> GetAll()
    {
        var monitoracoes = await _monitoracaoService.GetAllAsync();
        return Ok(monitoracoes);
    }

    [HttpPost]
    public async Task<ActionResult<Monitoracao>> Create([FromBody] Monitoracao monitoracao)
    {
        // Ajusta dataHora para agora menos 1 dia, conforme regra de negócio
        monitoracao.DataHora = DateTime.Now.AddDays(-1);

        _logger.LogInformation($"Cadastrando monitoracao {monitoracao.Id}");

        await _monitoracaoService.CreateAsync(monitoracao);

        return CreatedAtAction(nameof(GetById), new { id = monitoracao.Id }, monitoracao);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Monitoracao>> GetById(long id)
    {
        _logger.LogInformation($"Buscando monitoracao {id}");

        var monitoracao = await _monitoracaoService.GetByIdAsync(id);

        if (monitoracao == null)
            return NotFound();

        return Ok(monitoracao);
    }
}
