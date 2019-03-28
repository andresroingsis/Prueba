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

        public async Task<Tarea> ActualizarTareaAsync(Tarea tareaAModificar)
        {
            await ActualizarAsync(tareaAModificar);
            return await ObtenerEntidadPorIdAsync(tareaAModificar.IdTarea);
        }

        public async Task<Tarea> AgregarTareaAsync(Tarea tareaARegistrar)
        {
            return await AgregarAsync(tareaARegistrar);
        }

        public async Task BorrarTareaAsync(Guid idDeLaTarea)
        {
            var tareaABorrar = await ObtenerEntidadPorIdAsync(idDeLaTarea);
            await EliminarAsync(tareaABorrar);
        }

        public async Task<IReadOnlyList<Tarea>> ListarTareasConParametrosAsync(string idDelUsuario, bool todasLasTareas, bool? tareasFinalizadas)
        {
            IQueryable<Tarea> consultaDeLasTareas = _ContextoDeDatos.Tareas;

            if (!todasLasTareas)
            {
                consultaDeLasTareas = consultaDeLasTareas.Where(tarea => tarea.IdFkUsuario == idDelUsuario);
            }

            if (tareasFinalizadas != null)
            {
                consultaDeLasTareas = consultaDeLasTareas.Where(tarea => tarea.EstadoFinalizacion == tareasFinalizadas);
            }

            return await consultaDeLasTareas.AsNoTracking().ToListAsync();
        }

        public async Task<Tarea> ObtenerTareaPorIdAsync(Guid idDeLaTarea)
        {
            return await ObtenerEntidadPorIdAsync(idDeLaTarea);
        }
    }
}
