using Ci2HRodriguez.Aplicacion.EntidadesDePersistencia;
using Ci2HRodriguez.Aplicacion.IRepositorios;
using Ci2HRodriguez.Infraestructura.Datos.ContextoDeDatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ci2HRodriguez.Infraestructura.Repositorios
{
    /// <summary>
    /// Repositorio de las tareas
    /// </summary>
    public class TareaRepositorio : RepositorioBase<Tarea>, ITareaRepositorio
    {
        public TareaRepositorio(Ci2HRodriguezDbContext contextoDeDatos) : base(contextoDeDatos)
        {

        }

        public async Task<IReadOnlyList<Tarea>> ListarTareasDelUsuarioAsync(string idDelUsuario)
        {
            IQueryable<Tarea> consultaDeLasTareas = _ContextoDeDatos.Tareas;

            if (!string.IsNullOrWhiteSpace(idDelUsuario))
            {
                consultaDeLasTareas = consultaDeLasTareas.Where(tarea => tarea.IdFkUsuario == idDelUsuario);
            }

            return await consultaDeLasTareas.AsNoTracking().ToListAsync();
        }
    }
}
