using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaVotoAPI.Modelos;

    public class SistemaVotoAPIContext : DbContext
    {
        public SistemaVotoAPIContext (DbContextOptions<SistemaVotoAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaVotoAPI.Modelos.Candidato> Candidato { get; set; } = default!;
    }
