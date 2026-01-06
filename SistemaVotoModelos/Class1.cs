using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaVotoModelos
{
    // 1. USUARIOS
    [Table("usuarios")]
    public class Usuario
    {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; // Aquí guardaremos la contraseña encriptada
        public int RolId { get; set; } // 1: Admin, 2: Votante
        public bool Estado { get; set; } = true;
    }

    // 2. ELECCIONES
    [Table("elecciones")]
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

    // 3. LISTAS / PARTIDOS (¡NUEVO!)
    [Table("listas")]
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

    // 4. CANDIDATOS (¡NUEVO!)
    [Table("candidatos")]
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

    // 5. HISTORIAL (Control de participación)
    [Table("historial_participacion")]
    public class HistorialParticipacion
    {
        public int Id { get; set; }
        public int EleccionId { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime FechaVoto { get; set; } = DateTime.UtcNow;
    }

    // 6. VOTO ANÓNIMO (La urna)
    [Table("votos_anonimos")]
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
