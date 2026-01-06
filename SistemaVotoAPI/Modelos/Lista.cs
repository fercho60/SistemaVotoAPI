using System.Text.Json.Serialization;

namespace SistemaVotoAPI.Modelos
{
    public class Lista
    {
        public int Id { get; set; }
        public int EleccionId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Siglas { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;

        [JsonIgnore] // Evita ciclos infinitos al convertir a JSON
        public Eleccion? Eleccion { get; set; }
        public List<Candidato>? Candidatos { get; set; }
    }
}
