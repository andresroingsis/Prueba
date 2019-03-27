using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ci2HRodriguez.Aplicacion.IRepositorios
{
    public interface IRepositorioAsync<T> where T : class
    {
        Task<IReadOnlyList<T>> ListarTodoAsync();

        Task<T> AgregarAsync(T entidad);

        Task ActualizarAsync(T entidad);

        Task EliminarAsync(T entidad);

        Task<T> ObtenerEntidadPorIdAsync(Guid id);

        Task<T> ObtenerEntidadPorIdAsync(string id);
    }
}
