using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MantenimientoComputadores.Dominio.Entidades;
using MantCompu.App.Dominio;

namespace MantenimientoComputadores.Persistencia.AppRepositorios
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Administrador> Administradors { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<TipoServicio> TipoServicios { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Cita> Citas { get; set; }
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
