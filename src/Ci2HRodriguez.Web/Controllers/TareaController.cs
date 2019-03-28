using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ci2HRodriguez.Aplicacion.Dtos;
using Ci2HRodriguez.Aplicacion.EntidadesDePersistencia;
using Ci2HRodriguez.Aplicacion.IServicios;
using Ci2HRodriguez.Servicios.Auxiliares;
using Ci2HRodriguez.Web.Models.Tarea;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ci2HRodriguez.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        /// <summary>
        /// Servicio de tareas
        /// </summary>
        private readonly ITareaServicio _TareaServicio;

        /// <summary>
        /// Gestor de usuarios
        /// </summary>
        private UserManager<Usuario> _UserManager;

        public TareaController(UserManager<Usuario> userManager, ITareaServicio tareaServicio)
        {
            _UserManager = userManager;
            _TareaServicio = tareaServicio;
        }

        [HttpGet("consultar/{tareasFinalizadas?}/{todasLasTareas}")]
        public async Task<ActionResult<IEnumerable<TareaDto>>> ConsultarTareas(bool? tareasFinalizadas, bool todasLasTareas = Constantes.NoConsultarTodasLasTareas)
        {
            var idDelUsuarioAutenticado = _UserManager.GetUserId(HttpContext.User);
            return await _TareaServicio.ObtenerListadoDeTareasAsync(idDelUsuarioAutenticado, todasLasTareas, tareasFinalizadas);
        }

        [HttpPost("crear")]
        public async Task<ActionResult<TareaDto>> CrearTarea([FromBody] RegistrarTareaModel modelo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var idDelUsuarioAutenticado = _UserManager.GetUserId(HttpContext.User);
            return await _TareaServicio.AgregarTareaAsync(idDelUsuarioAutenticado, modelo.Descripcion, modelo.FechaDeVencimiento.Value);
        }

        [HttpPut("actualizar")]
        public async Task<ActionResult<TareaDto>> ActualizarTarea([FromBody] ActualizarTareaModel modelo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var idDelUsuarioAutenticado = _UserManager.GetUserId(HttpContext.User);
            return await _TareaServicio.ActualizarTareaAsync(modelo.IdTarea.Value, 
                                                             idDelUsuarioAutenticado, 
                                                             modelo.Descripcion, 
                                                             modelo.FechaDeVencimiento.Value,
                                                             modelo.TareaTerminada);
        }

        [HttpDelete("borrar/{id}")]
        public async Task Borrar(string id)
        {
            var idDelUsuarioAutenticado = _UserManager.GetUserId(HttpContext.User);
            await _TareaServicio.BorrarTareaAsync(new Guid(id), idDelUsuarioAutenticado);
        }
    }
}