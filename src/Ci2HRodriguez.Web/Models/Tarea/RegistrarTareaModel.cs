using System;
using System.ComponentModel.DataAnnotations;

namespace Ci2HRodriguez.Web.Models.Tarea
{
    /// <summary>
    /// Modelo de tarea que va a crear el usuario
    /// </summary>
    public class RegistrarTareaModel
    {
        [Required(ErrorMessage = "Debe ingresar una descripción a la tarea.")]
        [StringLength(200, ErrorMessage = "La descripción de la tarea no puede tener más de 200 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha de vencimiento de la tarea.")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaDeVencimiento { get; set; }
    }
}
