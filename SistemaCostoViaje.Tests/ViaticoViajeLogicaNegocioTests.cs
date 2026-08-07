using Xunit;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Tests
{
    public class ViaticoViajeLogicaNegocioTests
    {
        private ViaticoViaje CrearViaticoValido()
        {
            return new ViaticoViaje
            {
                ViajeId = 1,
                Tipo = "Almuerzo",
                Monto = 5000m
            };
        }

        [Fact]
        public void Crear_ViaticoValido_DeberiaPersistirYAsignarId()
        {
            var logica = new ViaticoViajeLogicaNegocio();

            var creado = logica.Crear(CrearViaticoValido());

            Assert.True(creado.Id > 0);
            Assert.Equal("Almuerzo", creado.Tipo);
        }

        [Fact]
        public void Crear_ViaticoNulo_DeberiaLanzarArgumentoNulo()
        {
            var logica = new ViaticoViajeLogicaNegocio();

            Assert.Throws<ArgumentNullException>(() => logica.Crear(null!));
        }

        [Fact]
        public void Crear_TipoInvalido_DeberiaLanzarArgumento()
        {
            var logica = new ViaticoViajeLogicaNegocio();
            var viatico = CrearViaticoValido();
            viatico.Tipo = "Snack";

            Assert.Throws<ArgumentException>(() => logica.Crear(viatico));
        }

        [Fact]
        public void Crear_MontoInvalido_DeberiaLanzarArgumento()
        {
            var logica = new ViaticoViajeLogicaNegocio();
            var viatico = CrearViaticoValido();
            viatico.Monto = 0;

            Assert.Throws<ArgumentException>(() => logica.Crear(viatico));
        }

        [Fact]
        public void ObtenerPorViajeId_DeberiaFiltrarPorViaje()
        {
            var logica = new ViaticoViajeLogicaNegocio();
            var v1 = CrearViaticoValido();
            v1.ViajeId = 10;
            var v2 = CrearViaticoValido();
            v2.ViajeId = 11;
            var c1 = logica.Crear(v1);
            var c2 = logica.Crear(v2);

            var resultados = logica.ObtenerPorViajeId(10);

            Assert.Contains(resultados, r => r.Id == c1.Id);
            Assert.DoesNotContain(resultados, r => r.Id == c2.Id);
        }

        [Fact]
        public void Actualizar_DeberiaActualizarLosDatos()
        {
            var logica = new ViaticoViajeLogicaNegocio();
            var creado = logica.Crear(CrearViaticoValido());
            creado.Monto = 6000m;

            var actualizado = logica.Actualizar(creado);

            Assert.Equal(6000m, actualizado.Monto);
        }

        [Fact]
        public void Eliminar_DeberiaEliminarElViatico()
        {
            var logica = new ViaticoViajeLogicaNegocio();
            var creado = logica.Crear(CrearViaticoValido());

            bool eliminado = logica.Eliminar(creado.Id);

            Assert.True(eliminado);
            Assert.Null(logica.ObtenerPorId(creado.Id));
        }
    }
}
