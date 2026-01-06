using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaVotoAPI.Modelos;

namespace SistemaVotoAPI
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<SistemaVotoAPI.Modelos.Candidato> Candidato { get; set; } = default!;
        public DbSet<SistemaVotoAPI.Modelos.Eleccion> Eleccion { get; set; } = default!;
        public DbSet<SistemaVotoAPI.Modelos.HistorialParticipacion> HistorialParticipacion { get; set; } = default!;
        public DbSet<SistemaVotoAPI.Modelos.Lista> Lista { get; set; } = default!;
        public DbSet<SistemaVotoAPI.Modelos.VotoAnonimo> VotoAnonimo { get; set; } = default!;
    }
}
