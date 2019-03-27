using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Ci2HRodriguez.Aplicacion.EntidadesDePersistencia
{
    /// <summary>
    /// Representa un usuario del sistema
    /// </summary>
    public class Usuario : IdentityUser
    {
        public string NombreCompleto { get; set; }

        /// <summary>
        /// Coleccion de tareas asociadas al usuario
        /// </summary>
        public virtual ICollection<Tarea> ColeccionDeTareas { get; set; }
    }
}
