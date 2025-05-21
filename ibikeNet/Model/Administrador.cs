using ibikeNet.components;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ibikeNet.Model
{
    [Table("administrador")]
    public class Administrador
    {
        [Key]
        [StringLength(11)]
        public string Cpf { get; set; } = string.Empty;

        [Required]
        [Column("nm_adm")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(5)]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public StatusAdministrador Status { get; set; }

        // Relação muitos-para-um: muitos admins para um pátio
        [Required]
        public int PatioId { get; set; }
        public Patio? Patio { get; set; }
    }
}
