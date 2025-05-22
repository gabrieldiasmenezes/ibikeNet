using ibikeNet.dto;

namespace ibikeNet.Services
{
    public interface IAdministradorService
    {
        Task<IEnumerable<AdministradorResultDto>> GetAllAsync();
        Task<AdministradorResultDto> GetByIdAsync(string cpf);
        Task<AdministradorResultDto> CreateAsync(AdministradorCreateDto dto);
        Task UpdateAsync(string cpf, AdministradorUpdateDto dto);
        Task DeleteAsync(string cpf);
    }
}