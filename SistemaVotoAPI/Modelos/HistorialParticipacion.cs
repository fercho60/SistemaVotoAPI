namespace SistemaVotoAPI.Modelos
{
    public class HistorialParticipacion
    {
        public int Id { get; set; }
        public int EleccionId { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime FechaVoto { get; set; } = DateTime.UtcNow;
    }

}
