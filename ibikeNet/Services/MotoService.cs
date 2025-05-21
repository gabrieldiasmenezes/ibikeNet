using ibikeNet.Data;
using ibikeNet.Model;
using ibikeNet.Dtos;
using Microsoft.EntityFrameworkCore;

public class MotoService
{
    private readonly AppDbContext _context;

    public MotoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<MotoReadDto>> GetAllAsync()
    {
        var motos = await _context.Motos.Include(m => m.Patio).ToListAsync();
        return motos.Select(m => ToReadDto(m)).ToList();
    }

    public async Task<MotoReadDto?> GetByPlacaAsync(string placa)
    {
        var moto = await _context.Motos.Include(m => m.Patio)
                                       .FirstOrDefaultAsync(m => m.Placa == placa);
        return moto == null ? null : ToReadDto(moto);
    }

    public async Task<MotoReadDto> CreateAsync(MotoCreateDto dto)
    {
        var moto = new Moto
        {
            Placa = dto.Placa,
            Modelo = dto.Modelo,
            Status = dto.Status,
            KmAtual = dto.KmAtual,
            DataUltimoCheck = dto.DataUltimoCheck,
            PatioId = dto.PatioId
        };

        _context.Motos.Add(moto);
        await _context.SaveChangesAsync();

        return ToReadDto(moto);
    }

    public async Task<bool> UpdateAsync(string placa, MotoUpdateDto dto)
    {
        var moto = await _context.Motos.FirstOrDefaultAsync(m => m.Placa == placa);
        if (moto == null) return false;

        moto.Modelo = dto.Modelo;
        moto.Status = dto.Status;
        moto.KmAtual = dto.KmAtual;
        moto.DataUltimoCheck = dto.DataUltimoCheck;
        moto.PatioId = dto.PatioId;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string placa)
    {
        var moto = await _context.Motos.FirstOrDefaultAsync(m => m.Placa == placa);
        if (moto == null) return false;

        _context.Motos.Remove(moto);
        await _context.SaveChangesAsync();
        return true;
    }

    private MotoReadDto ToReadDto(Moto moto)
    {
        return new MotoReadDto
        {
            Placa = moto.Placa,
            Modelo = moto.Modelo,
            Status = moto.Status,
            KmAtual = moto.KmAtual,
            DataUltimoCheck = moto.DataUltimoCheck,
            PatioId = moto.PatioId,
            PatioNome = moto.Patio?.Nome
        };
    }
}
