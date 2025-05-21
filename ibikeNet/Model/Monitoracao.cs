using ibikeNet.components;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ibikeNet.Model
{
    [Table("monitoracao")]
    public class Monitoracao
    {
        [Key]
        [Column("id_monitoracao")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("tipo_evento")]
        public TipoEvento TipoEvento { get; set; }

        [Required]
        [Column("data_hora")]
        public DateTime DataHora { get; set; }

        [Required]
        [ForeignKey("Moto")]
        [Column("placa_moto")]
        public string MotoPlaca { get; set; } = string.Empty;

        public Moto? Moto { get; set; }
    }
}
