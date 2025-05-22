using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ibikeNet.components;

namespace ibikeNet.Model
{
    [Table("administrador")]
    public class Administrador // : IdentityUser ?
    {
        [Key]
        [Column("Cpf", TypeName = "char(11)")]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Column("nm_adm")]
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        [Column("Password", TypeName = "varchar(100)")]
        public string Password { get; set; }

        [Required]
        [Column("Status")]
        public StatusAdministrador Status { get; set; }

        // Relacionamento com Patio
        public long PatioId { get; set; }
        public Patio? Patio { get; set; }
    }


}