using System;
using System.ComponentModel.DataAnnotations;

namespace Ci2HRodriguez.Aplicacion.EntidadesDePersistencia
{
    /// <summary>
    /// Representa una tarea en el sistema
    /// </summary>
    public class Tarea
    {
        [Key]
        public Guid IdTarea { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaDeCreacion { get; set; }

        public bool EstadoFinalizacion { get; set; }

        public DateTime FechaDeVencimiento { get; set; }

        /// <summary>
        /// Usuario responsable de la tarea
        /// </summary>
        public string IdFkUsuario { get; set; }
        public Usuario UsuarioAsociado { get; set; }

        public void ActualizarTarea(string descripcionDeLaTarea, DateTime fechaDeVencimiento, bool EsTareaFinalizada)
        {
            Descripcion = descripcionDeLaTarea;
            EstadoFinalizacion = EsTareaFinalizada;
            FechaDeVencimiento = fechaDeVencimiento;
        }
    }
}
