using ibikeNet.Data;
using ibikeNet.Model;
using ibikeNet.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace ibikeNet.Services
{
    public class PatioService
    {
        private readonly AppDbContext _context;

        public PatioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PatioDTO>> ListarPatiosAsync()
        {
            var patios = await _context.Patios
                .Include(p => p.Administradores)
                .ToListAsync();

            var patiosDTO = patios.Select(p => new PatioDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Capacidade = p.Capacidade,
                Status = p.Status,
                QuantidadeAdministradores = p.Administradores?.Count ?? 0
            }).ToList();

            return patiosDTO;
        }
    }
}
