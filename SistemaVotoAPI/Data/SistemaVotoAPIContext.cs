using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaVotoModelos;

    public class SistemaVotoAPIContext : DbContext
    {
        public SistemaVotoAPIContext (DbContextOptions<SistemaVotoAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaVotoModelos.Candidato> Candidato { get; set; } = default!;

public DbSet<SistemaVotoModelos.Eleccion> Eleccion { get; set; } = default!;

public DbSet<SistemaVotoModelos.HistorialParticipacion> HistorialParticipacion { get; set; } = default!;

public DbSet<SistemaVotoModelos.Lista> Lista { get; set; } = default!;

public DbSet<SistemaVotoModelos.Usuario> Usuario { get; set; } = default!;

public DbSet<SistemaVotoModelos.VotoAnonimo> VotoAnonimo { get; set; } = default!;
    }
