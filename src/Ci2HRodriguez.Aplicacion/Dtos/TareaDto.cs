using System;
using System.Collections.Generic;

namespace Ci2HRodriguez.Aplicacion.Dtos
{
    public class TareaDto
    {
        public Guid IdTarea { get; private set; }

        public string Descripcion { get; private set; }

        public DateTime FechaDeCreacion { get; private set; }

        public bool EstadoFinalizacion { get; private set; }

        public DateTime FechaDeVencimiento { get; private set; }

        /// <summary>
        /// Id del usuario asociado a la tarea
        /// </summary>
        public string IdFkUsuario { get; private set; }

        public TareaDto()
        {

        }

        /// <summary>
        /// Provee una tarea que va a ser agregada
        /// </summary>
        /// <param name="idDelUsuario">ID del usuario autenticado</param>
        /// <param name="descripcionDeLaTarea">Descripcion de la tarea a agregar</param>
        /// <param name="fechaDeVencimiento">Fecha de vencimiento de la tarea</param>
        public TareaDto(string idDelUsuario, string descripcionDeLaTarea, DateTime fechaDeVencimiento)
        {
            IdTarea = Guid.NewGuid();
            Descripcion = descripcionDeLaTarea;
            FechaDeCreacion = DateTime.Now;
            EstadoFinalizacion = false;
            FechaDeVencimiento = fechaDeVencimiento;
            IdFkUsuario = idDelUsuario;
        }
    }
}
