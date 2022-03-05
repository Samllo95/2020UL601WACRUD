using Microsoft.EntityFrameworkCore;
using _2020UL601WACRUD.Models;

namespace _2020UL601WACRUD
{
    public class EquiposContext:DbContext
    {
        public EquiposContext(DbContextOptions<EquiposContext> options) : base(options)
        {

        }

        public DbSet<Equipos> equipos { get; set; }
        public DbSet<EstadosEquipos> estadosEquipos { get; set; }
        public DbSet<Marcas> marcas { get; set; }
        public DbSet<TipoEquipo> tipoEquipo { get; set; }

    }
}
