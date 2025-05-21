using Microsoft.EntityFrameworkCore;
using ibikeNet.Data;
using ibikeNet.Model;

public class MonitoracaoService
{
    private readonly AppDbContext _context;

    public MonitoracaoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Monitoracao>> GetAllAsync()
    {
        // Inclui a entidade Moto para acesso aos dados relacionados
        return await _context.Monitoracoes.Include(m => m.Moto).ToListAsync();
    }

    public async Task<Monitoracao?> GetByIdAsync(long id)
    {
        return await _context.Monitoracoes.Include(m => m.Moto)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task CreateAsync(Monitoracao monitoracao)
    {
        _context.Monitoracoes.Add(monitoracao);
        await _context.SaveChangesAsync();
    }
}
