using ibikeNet.components;

namespace ibikeNet.Dtos
{
    public class MotoCreateDto
    {
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public StatusMoto Status { get; set; }
        public double KmAtual { get; set; }
        public DateTime DataUltimoCheck { get; set; }
        public int PatioId { get; set; }
    }

    public class MotoReadDto
    {
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public StatusMoto Status { get; set; }
        public double KmAtual { get; set; }
        public DateTime DataUltimoCheck { get; set; }
        public int PatioId { get; set; }
        public string? PatioNome { get; set; }
    }

    public class MotoUpdateDto
    {
        public string Modelo { get; set; } = string.Empty;
        public StatusMoto Status { get; set; }
        public double KmAtual { get; set; }
        public DateTime DataUltimoCheck { get; set; }
        public int PatioId { get; set; }
    }
}
