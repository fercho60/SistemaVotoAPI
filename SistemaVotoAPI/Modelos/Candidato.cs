using System.Text.Json.Serialization;

namespace SistemaVotoAPI.Modelos
{
    public class Candidato
    {
        public int Id { get; set; }
        public int ListaId { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string FotoUrl { get; set; } = string.Empty;

        [JsonIgnore]
        public Lista? Lista { get; set; }
    }
}
