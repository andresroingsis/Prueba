using AutoMapper;
using Ci2HRodriguez.Aplicacion.Dtos;
using Ci2HRodriguez.Aplicacion.EntidadesDePersistencia;
using Ci2HRodriguez.Aplicacion.IRepositorios;
using Ci2HRodriguez.Aplicacion.IServicios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ci2HRodriguez.Servicios.Servicios
{
    /// <summary>
    /// Servicio de las tareas
    /// </summary>
    public class TareaServicio : ITareaServicio
    {
        /// <summary>
        /// Repositorio de tareas
        /// </summary>
        private readonly ITareaRepositorio _TareaRepositorio;

        /// <summary>
        /// Constante de automapper disponible para gestionar el mapeo de entidades
        /// </summary>
        private readonly IMapper _Mapper;

        /// <summary>
        /// Inicializa una instancia de la clase con el repositorio pasado como parametro
        /// </summary>
        /// <param name="_TareaRepositorio">Repositorio de tareas</param>
        public TareaServicio(ITareaRepositorio tareaRepositorio, IMapper mapper)
        {
            _TareaRepositorio = tareaRepositorio;
            _Mapper = mapper;
        }

        public async Task<TareaDto> ActualizarTareaAsync(Guid idDeLaTarea,
                                                         string idDelUsuarioAutenticado,
                                                         string descripcionDeLaTarea,
                                                         DateTime fechaDeVencimiento,
                                                         bool EsTareaFinalizada)
        {
            var tareaAModificar = await _TareaRepositorio.ObtenerTareaPorIdAsync(idDeLaTarea);

            if (tareaAModificar.IdFkUsuario != idDelUsuarioAutenticado)
            {
                throw new Exception("El usuario no tiene permitido modificar la tarea.");
            }

            tareaAModificar.ActualizarTarea(descripcionDeLaTarea, fechaDeVencimiento, EsTareaFinalizada);
            return _Mapper.Map<TareaDto>(await _TareaRepositorio.ActualizarTareaAsync(tareaAModificar));
        }

        public async Task<TareaDto> AgregarTareaAsync(string idDelUsuario, string descripcionDeLaTarea, DateTime fechaDeVencimiento)
        {
            var tareaDto = new TareaDto(idDelUsuario, descripcionDeLaTarea, fechaDeVencimiento);
            return _Mapper.Map<TareaDto>(await _TareaRepositorio.AgregarTareaAsync(_Mapper.Map<Tarea>(tareaDto)));
        }

        public async Task BorrarTareaAsync(Guid idDeLaTarea, string idDelUsuarioAutenticado)
        {
            var tareaAEliminar = await _TareaRepositorio.ObtenerTareaPorIdAsync(idDeLaTarea);

            if (tareaAEliminar.IdFkUsuario != idDelUsuarioAutenticado)
            {
                throw new Exception("El usuario no tiene permitido borrar la tarea.");
            }

            await _TareaRepositorio.BorrarTareaAsync(tareaAEliminar.IdTarea);
        }

        public async Task<string> ObtenerIdDelUsuarioAsociadoALaTareaAsync(Guid idDeLaTarea)
        {
            var tareaAConsultar = await _TareaRepositorio.ObtenerTareaPorIdAsync(idDeLaTarea);
            return tareaAConsultar.IdFkUsuario;
        }

        public async Task<List<TareaDto>> ObtenerListadoDeTareasAsync(string idDelUsuario, bool todasLasTareas, bool? tareasFinalizadas)
        {
            return _Mapper.Map<List<TareaDto>>(await _TareaRepositorio.ListarTareasConParametrosAsync(idDelUsuario, todasLasTareas, tareasFinalizadas));
        }
    }
}
