using Ci2HRodriguez.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ci2HRodriguez.Aplicacion.IServicios
{
    /// <summary>
    /// Define los metodos a implementar en el servicio de tareas
    /// </summary>
    public interface ITareaServicio
    {
        Task<string> ObtenerIdDelUsuarioAsociadoALaTareaAsync(Guid idDeLaTarea);

        Task<TareaDto> AgregarTareaAsync(string idDelUsuario, string descripcionDeLaTarea, DateTime fechaDeVencimiento);

        Task<TareaDto> ActualizarTareaAsync(Guid idDeLaTarea,
                                            string idDelUsuarioAutenticado,
                                            string descripcionDeLaTarea,
                                            DateTime fechaDeVencimiento,
                                            bool EsTareaFinalizada);

        Task BorrarTareaAsync(Guid idDeLaTarea, string idDelUsuarioAutenticado);

        Task<List<TareaDto>> ObtenerListadoDeTareasAsync(string idDelUsuario, bool todasLasTareas, bool? tareasFinalizadas);
    }
}
