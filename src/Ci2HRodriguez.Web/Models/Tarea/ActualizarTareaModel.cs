using System;
using System.ComponentModel.DataAnnotations;

namespace Ci2HRodriguez.Web.Models.Tarea
{
    public class ActualizarTareaModel : RegistrarTareaModel
    {
        [Required(ErrorMessage = "La tarea no tiene un ID válido.")]
        public Guid? IdTarea { get; set; }

        public bool TareaTerminada { get; set; }
    }
}
