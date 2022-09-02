using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MantenimientoComputadores.Dominio.Entidades;

namespace MantenimientoComputadores.Persistencia.AppRepositorios
{
    public class AppContext : DbContext
    {
        public DbSet<Prueba> pruebas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source=.;Initial Catalog=MantenimientoComputadores; Integrated Security=True");
            }
        }
        
    }
}
