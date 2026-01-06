namespace SistemaVotoAPI.Modelos
{
    public class Eleccion
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = "CONFIGURACION";
        public string TipoEleccion { get; set; } = "PLANCHA";

        // Relación: Una elección tiene muchas listas (Propiedad de navegación)
        public List<Lista>? Listas { get; set; }
    }
}
