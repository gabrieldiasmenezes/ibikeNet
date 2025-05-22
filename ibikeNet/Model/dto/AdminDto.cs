using System.ComponentModel.DataAnnotations;
using ibikeNet.components;

namespace ibikeNet.dto
{
    public class AdministradorResultDto
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public StatusAdministrador Status { get; set; }
        public long PatioId { get; set; }
    }
    public class AdministradorCreateDto
    {
        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }

        [Required]
        public StatusAdministrador Status { get; set; }

        [Required]
        public long PatioId { get; set; }
    }
    public class AdministradorUpdateDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public StatusAdministrador Status { get; set; }

        [Required]
        public long PatioId { get; set; }
    }
}