using Estacionamiento.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Estacionamiento
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Estacionamientos> Estacionamientos { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<Ingreso> Ingreso { get; set; }
        public DbSet<Lugar> Lugar { get; set; }
    }
}

