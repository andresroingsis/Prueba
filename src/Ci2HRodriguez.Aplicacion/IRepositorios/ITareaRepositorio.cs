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
        Task<IReadOnlyList<Tarea>> ListarTareasDelUsuarioAsync(string idDelUsuario);
    }
}
