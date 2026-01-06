namespace SistemaVotoAPI.Modelos
{
    public class VotoAnonimo
    {
        public Guid Id { get; set; }
        public int EleccionId { get; set; }
        public int? ListaId { get; set; }
        public int? CandidatoId { get; set; }
        public DateTime FechaVoto { get; set; } = DateTime.UtcNow;
        public string FirmaDigital { get; set; } = string.Empty;
    }
}
