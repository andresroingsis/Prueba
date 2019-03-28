using AutoMapper;
using Ci2HRodriguez.Aplicacion.Dtos;
using Ci2HRodriguez.Aplicacion.EntidadesDePersistencia;
using Ci2HRodriguez.Aplicacion.IRepositorios;
using Ci2HRodriguez.Servicios.Servicios;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Ci2HRodriguez.Test.Servicios
{
    /// <summary>
    /// Implementa las pruebas unitarias al servicio de tareas
    /// </summary>
    public class LaTarea
    {
        /// <summary>
        /// Mock del repositorio de tareas
        /// </summary>
        private Mock<ITareaRepositorio> _TareaRepositorio;

        private Mock<IMapper> _Mapper;

        /// <summary>
        /// Servicio de tareas por realizar pruebas unitarias
        /// </summary>
        private TareaServicio _TareaServicio;

        public LaTarea()
        {
            _TareaRepositorio = new Mock<ITareaRepositorio>();
            _Mapper = new Mock<IMapper>();
            _Mapper.Setup(m => m.Map<TareaDto>(It.IsAny<Tarea>())).Returns(new TareaDto());
            _Mapper.Setup(m => m.Map<Tarea>(It.IsAny<TareaDto>())).Returns(new Tarea());
            _TareaServicio = new TareaServicio(_TareaRepositorio.Object, _Mapper.Object);
        }

        [Fact]
        public async void DevuelveUnListadoDeTareasDadoCiertosParametros()
        {
            // Arange
            var listadoDeTareas = new List<Tarea>();
            _TareaRepositorio.Setup(c => c.ListarTareasConParametrosAsync(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>())).ReturnsAsync(listadoDeTareas);

            // Act
            var resultado = await _TareaServicio.ObtenerListadoDeTareasAsync(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>());

            // Assert
            _TareaRepositorio.Verify(c => c.ListarTareasConParametrosAsync(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()), Times.Once);
        }

        [Fact]
        public async void DevuelveUnaTareaAgregada()
        {
            // Arange
            var tarea = new Tarea();
            _TareaRepositorio.Setup(c => c.AgregarTareaAsync(It.IsAny<Tarea>())).ReturnsAsync(tarea);

            // Act
            var resultado = await _TareaServicio.AgregarTareaAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>());

            // Assert
            Assert.NotNull(resultado);
            _TareaRepositorio.Verify(c => c.AgregarTareaAsync(It.IsAny<Tarea>()), Times.Once);
        }
    }
}
