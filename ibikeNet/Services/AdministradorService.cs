using ibikeNet.Data;
using ibikeNet.dto;
using ibikeNet.Model;
using Microsoft.EntityFrameworkCore;

namespace ibikeNet.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly AppDbContext _context;

        public AdministradorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdministradorResultDto>> GetAllAsync()
        {
            return await _context.Administradores
                .Select(a => new AdministradorResultDto
                {
                    Cpf = a.Cpf,
                    Nome = a.Nome,
                    Email = a.Email,
                    Status = a.Status,
                    PatioId = a.PatioId
                })
                .ToListAsync();
        }

        public async Task<AdministradorResultDto> GetByIdAsync(string cpf)
        {
            var administrador = await _context.Administradores
                .Where(a => a.Cpf == cpf)
                .Select(a => new AdministradorResultDto
                {
                    Cpf = a.Cpf,
                    Nome = a.Nome,
                    Email = a.Email,
                    Status = a.Status,
                    PatioId = a.PatioId
                })
                .FirstOrDefaultAsync();

            return administrador;
        }

        public async Task<AdministradorResultDto> CreateAsync(AdministradorCreateDto dto)
        {
            var administrador = new Administrador
            {
                Cpf = dto.Cpf,
                Nome = dto.Nome,
                Email = dto.Email,
                Password = dto.Password, // ⚠️ Lembre-se de usar hash se for integrar com Identity
                Status = dto.Status,
                PatioId = dto.PatioId
            };

            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();

            return new AdministradorResultDto
            {
                Cpf = administrador.Cpf,
                Nome = administrador.Nome,
                Email = administrador.Email,
                Status = administrador.Status,
                PatioId = administrador.PatioId
            };
        }

        public async Task UpdateAsync(string cpf, AdministradorUpdateDto dto)
        {
            var administrador = await _context.Administradores.FindAsync(cpf);
            if (administrador == null) throw new KeyNotFoundException("Administrador não encontrado");

            administrador.Nome = dto.Nome;
            administrador.Email = dto.Email;
            administrador.Status = dto.Status;
            administrador.PatioId = dto.PatioId;

            _context.Administradores.Update(administrador);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string cpf)
        {
            var administrador = await _context.Administradores.FindAsync(cpf);
            if (administrador == null) throw new KeyNotFoundException("Administrador não encontrado");

            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();
        }
    }

}