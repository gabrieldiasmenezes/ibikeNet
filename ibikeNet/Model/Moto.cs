using ibikeNet.components;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ibikeNet.Model
{
    [Table("moto")]
    public class Moto
    {
        [Key]
        [StringLength(10)]
        public string Placa { get; set; } = string.Empty;

        [Required]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        public StatusMoto Status { get; set; }

        [Required]
        [Column("km_atual")]
        public double KmAtual { get; set; }

        [Required]
        [Column("data_ultimo_check")]
        public DateTime DataUltimoCheck { get; set; }

        // Relação muitos-para-um com Patio
        public int PatioId { get; set; }
        public Patio? Patio { get; set; }
    }
}
