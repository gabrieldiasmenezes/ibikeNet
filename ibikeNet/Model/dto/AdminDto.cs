using ibikeNet.components;

namespace ibikeNet.Model.DTO
{
    public class AdminDto
    {
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public StatusAdministrador Status { get; set; }
        public int PatioId { get; set; }
    }
}
