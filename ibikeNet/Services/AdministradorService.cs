using Microsoft.EntityFrameworkCore;
using ibikeNet.Data;
using ibikeNet.Model;

public class AdministradorService
{
    private readonly AppDbContext _context;

    public AdministradorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Administrador>> GetAllAsync()
    {
        return await _context.Administradores.Include(a => a.Patio).ToListAsync();
    }

    public async Task<Administrador?> GetByCpfAsync(string cpf)
    {
        return await _context.Administradores.Include(a => a.Patio)
                                             .FirstOrDefaultAsync(a => a.Cpf == cpf);
    }

    public async Task<bool> ExistsByCpfAsync(string cpf)
    {
        return await _context.Administradores.AnyAsync(a => a.Cpf == cpf);
    }

    public async Task CreateAsync(Administrador admin)
    {
        _context.Administradores.Add(admin);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Administrador admin)
    {
        _context.Administradores.Update(admin);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Administrador admin)
    {
        _context.Administradores.Remove(admin);
        await _context.SaveChangesAsync();
    }
}
