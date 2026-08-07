using Xunit;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Tests
{
    public class PeajeLogicaNegocioTests
    {
        private Peaje CrearPeajeValido()
        {
            return new Peaje
            {
                Nombre = "San Rafael",
                Costo = 1000m
            };
        }

        [Fact]
        public void Crear_PeajeValido_DeberiaPersistirYAsignarId()
        {
            var logica = new PeajeLogicaNegocio();

            var creado = logica.Crear(CrearPeajeValido());

            Assert.True(creado.Id > 0);
            Assert.Equal("San Rafael", creado.Nombre);
        }

        [Fact]
        public void Crear_PeajeNulo_DeberiaLanzarArgumentoNulo()
        {
            var logica = new PeajeLogicaNegocio();

            Assert.Throws<ArgumentNullException>(() => logica.Crear(null!));
        }

        [Fact]
        public void Crear_SinNombre_DeberiaLanzarArgumento()
        {
            var logica = new PeajeLogicaNegocio();
            var peaje = CrearPeajeValido();
            peaje.Nombre = " ";

            Assert.Throws<ArgumentException>(() => logica.Crear(peaje));
        }

        [Fact]
        public void Crear_CostoNegativo_DeberiaLanzarArgumento()
        {
            var logica = new PeajeLogicaNegocio();
            var peaje = CrearPeajeValido();
            peaje.Costo = -100m;

            Assert.Throws<ArgumentException>(() => logica.Crear(peaje));
        }

        [Fact]
        public void ObtenerPorId_DeberiaDevolverElPeaje()
        {
            var logica = new PeajeLogicaNegocio();
            var creado = logica.Crear(CrearPeajeValido());

            var obtenido = logica.ObtenerPorId(creado.Id);

            Assert.NotNull(obtenido);
            Assert.Equal(creado.Id, obtenido!.Id);
        }

        [Fact]
        public void Actualizar_DeberiaActualizarLosDatos()
        {
            var logica = new PeajeLogicaNegocio();
            var creado = logica.Crear(CrearPeajeValido());
            creado.Costo = 1500m;

            var actualizado = logica.Actualizar(creado);

            Assert.Equal(1500m, actualizado.Costo);
        }

        [Fact]
        public void Eliminar_DeberiaEliminarElPeaje()
        {
            var logica = new PeajeLogicaNegocio();
            var creado = logica.Crear(CrearPeajeValido());

            bool eliminado = logica.Eliminar(creado.Id);

            Assert.True(eliminado);
            Assert.Null(logica.ObtenerPorId(creado.Id));
        }

        [Fact]
        public void Eliminar_IdInvalido_DeberiaLanzarArgumento()
        {
            var logica = new PeajeLogicaNegocio();

            Assert.Throws<ArgumentException>(() => logica.Eliminar(0));
        }
    }
}
