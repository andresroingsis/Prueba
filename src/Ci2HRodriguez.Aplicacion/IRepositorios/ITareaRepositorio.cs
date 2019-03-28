using Ci2HRodriguez.Aplicacion.EntidadesDePersistencia;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ci2HRodriguez.Aplicacion.IRepositorios
{
    /// <summary>
    /// Define los metodos del repositorio de las tareas
    /// </summary>
    public interface ITareaRepositorio
    {
        Task<IReadOnlyList<Tarea>> ListarTareasConParametrosAsync(string idDelUsuario, bool todasLasTareas, bool? tareasFinalizadas);

        Task<Tarea> AgregarTareaAsync(Tarea tareaARegistrar);

        Task<Tarea> ActualizarTareaAsync(Tarea tareaAModificar);

        Task<Tarea> ObtenerTareaPorIdAsync(Guid idDeLaTarea);

        Task BorrarTareaAsync(Guid idDeLaTarea);
    }
}
