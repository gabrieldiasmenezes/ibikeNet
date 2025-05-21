using ibikeNet.components;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ibikeNet.Model
{
    [Table("patio")]
    public class Patio
    {
        [Key]
        [Column("id_patio")]
        public long Id { get; set; }

        [Required]
        [Column("nm_patio")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public int Capacidade { get; set; }

        [Required]
        public StatusPatio Status { get; set; } = StatusPatio.DISPONIVEL;

        // Relacionamento 1:N com Administradores
        public List<Administrador>? Administradores { get; set; }

        // Também pode adicionar se quiser mostrar motos do pátio:
        // public List<Moto>? Motos { get; set; }
    }
}
