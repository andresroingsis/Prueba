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

        /// <summary>
        /// Mock de autoMapper
        /// </summary>
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

        [Fact]
        public async void DevuelveUnaTareaActualizada()
        {
            // Arange
            var tarea = new Tarea();
            _TareaRepositorio.Setup(c => c.ActualizarTareaAsync(It.IsAny<Tarea>())).ReturnsAsync(tarea);

            // Act
            var resultado = await _TareaServicio.ActualizarTareaAsync(It.Is<Guid>(guid => guid != Guid.Empty),
                                                                      It.IsAny<string>(), 
                                                                      It.IsAny<string>(), 
                                                                      It.IsAny<DateTime>(),
                                                                      It.IsAny<bool>());

            // Assert
            Assert.NotNull(resultado);
            _TareaRepositorio.Verify(c => c.ActualizarTareaAsync(It.IsAny<Tarea>()), Times.Once);
        }

        [Fact]
        public async void BorraRegistroDadoElIdDeLaTarea()
        {
            // Arange
            _TareaRepositorio.Setup(c => c.ObtenerTareaPorIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Tarea());
            _TareaRepositorio.Setup(c => c.BorrarTareaAsync(It.Is<Guid>(guid => guid != Guid.Empty)));

            // Act
            await _TareaServicio.BorrarTareaAsync(Guid.NewGuid(), It.IsAny<string>());

            // Assert
            _TareaRepositorio.Verify(c => c.BorrarTareaAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async void DevuelveExcepcionDadoQueElUsuarioNoEsResponsableDeLaTarea()
        {
            // Arrange
            _TareaRepositorio.Setup(c => c.ObtenerTareaPorIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Tarea());
            _TareaRepositorio.Setup(c => c.BorrarTareaAsync(It.Is<Guid>(p => p != Guid.Empty))).Throws<ArgumentNullException>();

            // Act && Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await _TareaServicio.BorrarTareaAsync(Guid.NewGuid(), Guid.NewGuid().ToString()));
        }
    }
}
