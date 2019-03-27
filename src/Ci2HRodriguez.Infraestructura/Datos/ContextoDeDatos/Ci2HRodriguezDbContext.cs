using Ci2HRodriguez.Aplicacion.EntidadesDePersistencia;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Ci2HRodriguez.Infraestructura.Datos.ContextoDeDatos
{
    /// <summary>
    /// Representa el contexto de datos de la aplicacion
    /// </summary>
    public class Ci2HRodriguezDbContext : IdentityDbContext<Usuario>
    {
        public virtual DbSet<Tarea> Tareas { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public Ci2HRodriguezDbContext(DbContextOptions<Ci2HRodriguezDbContext> opciones) : base(opciones)
        {

        }

        protected override void OnModelCreating(ModelBuilder constructorDelModelo)
        {
            base.OnModelCreating(constructorDelModelo);

            constructorDelModelo.Entity<Usuario>().HasMany(usuario => usuario.ColeccionDeTareas)
                                                  .WithOne(tarea => tarea.UsuarioAsociado)
                                                  .HasForeignKey(tarea => tarea.IdFkUsuario)
                                                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
