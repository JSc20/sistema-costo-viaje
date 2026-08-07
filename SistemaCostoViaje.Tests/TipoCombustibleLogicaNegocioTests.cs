using Xunit;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Tests
{
    public class TipoCombustibleLogicaNegocioTests
    {
        private TipoCombustible CrearTipoCombustibleValido()
        {
            return new TipoCombustible
            {
                Nombre = "Gasolina Regular",
                CostoPorLitro = 1.20m
            };
        }

        [Fact]
        public void Crear_TipoCombustibleValido_DeberiaPersistirYAsignarId()
        {
            var logica = new TipoCombustibleLogicaNegocio();

            var creado = logica.Crear(CrearTipoCombustibleValido());

            Assert.True(creado.Id > 0);
            Assert.Equal("Gasolina Regular", creado.Nombre);
        }

        [Fact]
        public void Crear_TipoCombustibleNulo_DeberiaLanzarArgumentoNulo()
        {
            var logica = new TipoCombustibleLogicaNegocio();

            Assert.Throws<ArgumentNullException>(() => logica.Crear(null!));
        }

        [Fact]
        public void Crear_SinNombre_DeberiaLanzarArgumento()
        {
            var logica = new TipoCombustibleLogicaNegocio();
            var tipo = CrearTipoCombustibleValido();
            tipo.Nombre = "";

            Assert.Throws<ArgumentException>(() => logica.Crear(tipo));
        }

        [Fact]
        public void Crear_CostoPorLitroInvalido_DeberiaLanzarArgumento()
        {
            var logica = new TipoCombustibleLogicaNegocio();
            var tipo = CrearTipoCombustibleValido();
            tipo.CostoPorLitro = 0;

            Assert.Throws<ArgumentException>(() => logica.Crear(tipo));
        }

        [Fact]
        public void ObtenerPorId_DeberiaDevolverElTipo()
        {
            var logica = new TipoCombustibleLogicaNegocio();
            var creado = logica.Crear(CrearTipoCombustibleValido());

            var obtenido = logica.ObtenerPorId(creado.Id);

            Assert.NotNull(obtenido);
            Assert.Equal(creado.Id, obtenido!.Id);
        }

        [Fact]
        public void Actualizar_DeberiaActualizarLosDatos()
        {
            var logica = new TipoCombustibleLogicaNegocio();
            var creado = logica.Crear(CrearTipoCombustibleValido());
            creado.CostoPorLitro = 1.35m;

            var actualizado = logica.Actualizar(creado);

            Assert.Equal(1.35m, actualizado.CostoPorLitro);
        }

        [Fact]
        public void Eliminar_DeberiaEliminarElTipo()
        {
            var logica = new TipoCombustibleLogicaNegocio();
            var creado = logica.Crear(CrearTipoCombustibleValido());

            bool eliminado = logica.Eliminar(creado.Id);

            Assert.True(eliminado);
            Assert.Null(logica.ObtenerPorId(creado.Id));
        }
    }
}
