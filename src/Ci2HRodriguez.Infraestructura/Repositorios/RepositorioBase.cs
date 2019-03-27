using Ci2HRodriguez.Aplicacion.IRepositorios;
using Ci2HRodriguez.Infraestructura.Datos.ContextoDeDatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ci2HRodriguez.Infraestructura.Repositorios
{
    /// <summary>
    /// Patron repositorio de acceso a los datos
    /// </summary>
    /// <typeparam name="T">Entidad a acceder</typeparam>
    public class RepositorioBase<T> : IRepositorioAsync<T> where T : class
    {
        /// <summary>
        /// DbContext del sistema
        /// </summary>
        protected readonly Ci2HRodriguezDbContext _ContextoDeDatos;

        /// <summary>
        /// Inicializa el repositorio de la entidad T con el DbContext pasado como parametro
        /// </summary>
        /// <param name="contextoDeDatos"></param>
        public RepositorioBase(Ci2HRodriguezDbContext contextoDeDatos)
        {
            _ContextoDeDatos = contextoDeDatos;
        }

        public async Task ActualizarAsync(T entidad)
        {
            _ContextoDeDatos.Set<T>().Update(entidad);
            await _ContextoDeDatos.SaveChangesAsync();
        }

        public async Task<T> AgregarAsync(T entidad)
        {
            await _ContextoDeDatos.Set<T>().AddAsync(entidad);
            await _ContextoDeDatos.SaveChangesAsync();
            return entidad;
        }

        public async Task EliminarAsync(T entidad)
        {
            _ContextoDeDatos.Remove(entidad);
            await _ContextoDeDatos.SaveChangesAsync();
        }

        public async Task<T> ObtenerEntidadPorIdAsync(Guid id)
        {
            var entidadAConsultar = await _ContextoDeDatos.Set<T>().FindAsync(id);
            return entidadAConsultar;
        }

        public async Task<T> ObtenerEntidadPorIdAsync(string id)
        {
            var entidadAConsultar = await _ContextoDeDatos.Set<T>().FindAsync(id);
            return entidadAConsultar;
        }

        public async Task<IReadOnlyList<T>> ListarTodoAsync()
        {
            return await _ContextoDeDatos.Set<T>().AsNoTracking().ToListAsync();
        }        
    }
}
