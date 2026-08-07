using Xunit;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Tests
{
    public class DestinoLogicaNegocioTests
    {
        private Destino CrearDestinoValido()
        {
            return new Destino
            {
                PeajeId = 1,
                Nombre = "Escazú",
                KmIdaVuelta = 25.5m
            };
        }

        [Fact]
        public void Crear_DestinoValido_DeberiaPersistirYAsignarId()
        {
            var logica = new DestinoLogicaNegocio();

            var creado = logica.Crear(CrearDestinoValido());

            Assert.True(creado.Id > 0);
            Assert.Equal("Escazú", creado.Nombre);
        }

        [Fact]
        public void Crear_DestinoNulo_DeberiaLanzarArgumentoNulo()
        {
            var logica = new DestinoLogicaNegocio();

            Assert.Throws<ArgumentNullException>(() => logica.Crear(null!));
        }

        [Fact]
        public void Crear_SinNombre_DeberiaLanzarArgumento()
        {
            var logica = new DestinoLogicaNegocio();
            var destino = CrearDestinoValido();
            destino.Nombre = "";

            Assert.Throws<ArgumentException>(() => logica.Crear(destino));
        }

        [Fact]
        public void Crear_KmInvalidos_DeberiaLanzarArgumento()
        {
            var logica = new DestinoLogicaNegocio();
            var destino = CrearDestinoValido();
            destino.KmIdaVuelta = 0;

            Assert.Throws<ArgumentException>(() => logica.Crear(destino));
        }

        [Fact]
        public void ObtenerPorId_DeberiaDevolverElDestino()
        {
            var logica = new DestinoLogicaNegocio();
            var creado = logica.Crear(CrearDestinoValido());

            var obtenido = logica.ObtenerPorId(creado.Id);

            Assert.NotNull(obtenido);
            Assert.Equal(creado.Id, obtenido!.Id);
        }

        [Fact]
        public void ObtenerPorId_IdInvalido_DeberiaLanzarArgumento()
        {
            var logica = new DestinoLogicaNegocio();

            Assert.Throws<ArgumentException>(() => logica.ObtenerPorId(-1));
        }

        [Fact]
        public void Actualizar_DeberiaActualizarLosDatos()
        {
            var logica = new DestinoLogicaNegocio();
            var creado = logica.Crear(CrearDestinoValido());
            creado.Nombre = "San Rafael";

            var actualizado = logica.Actualizar(creado);

            Assert.Equal("San Rafael", actualizado.Nombre);
        }

        [Fact]
        public void Eliminar_DeberiaEliminarElDestino()
        {
            var logica = new DestinoLogicaNegocio();
            var creado = logica.Crear(CrearDestinoValido());

            bool eliminado = logica.Eliminar(creado.Id);

            Assert.True(eliminado);
            Assert.Null(logica.ObtenerPorId(creado.Id));
        }
    }
}
