using ibikeNet.components;

namespace ibikeNet.Model.DTO
{
    public class PatioDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Capacidade { get; set; }
        public StatusPatio Status { get; set; }
        public int QuantidadeAdministradores { get; set; }
    }
}
