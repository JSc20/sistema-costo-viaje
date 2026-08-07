using Xunit;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.Tests
{
    public class ViajeValidadorTests
    {
        private Viaje CrearViajeValido()
        {
            return new Viaje
            {
                Origen = "San José",
                Destino = "Cartago",
                DistanciaKm = 30m,
                FechaViaje = DateTime.Today.AddDays(1),
                IdConductor = 1
            };
        }

        [Fact]
        public void Validar_ViajeValido_DeberiaRetornarTrue()
        {
            var validador = new ViajeValidador();

            bool resultado = validador.Validar(CrearViajeValido());

            Assert.True(resultado);
            Assert.Empty(validador.ObtenerErrores());
        }

        [Fact]
        public void Validar_ViajeNulo_DeberiaRetornarFalse()
        {
            var validador = new ViajeValidador();

            bool resultado = validador.Validar(null!);

            Assert.False(resultado);
        }

        [Fact]
        public void Validar_OrigenYDestinoIguales_DeberiaRetornarFalse()
        {
            var validador = new ViajeValidador();
            var viaje = CrearViajeValido();
            viaje.Destino = "San José";

            bool resultado = validador.Validar(viaje);

            Assert.False(resultado);
        }

        [Fact]
        public void Validar_DistanciaInvalida_DeberiaRetornarFalse()
        {
            var validador = new ViajeValidador();
            var viaje = CrearViajeValido();
            viaje.DistanciaKm = 0;

            bool resultado = validador.Validar(viaje);

            Assert.False(resultado);
        }

        [Fact]
        public void Validar_FechaPasada_DeberiaRetornarFalse()
        {
            var validador = new ViajeValidador();
            var viaje = CrearViajeValido();
            viaje.FechaViaje = DateTime.Today.AddDays(-1);

            bool resultado = validador.Validar(viaje);

            Assert.False(resultado);
        }

        [Fact]
        public void Validar_ConductorInvalido_DeberiaRetornarFalse()
        {
            var validador = new ViajeValidador();
            var viaje = CrearViajeValido();
            viaje.IdConductor = 0;

            bool resultado = validador.Validar(viaje);

            Assert.False(resultado);
        }

        [Fact]
        public void Validar_MultiplesErrores_DeberiaRegistrarlosTodos()
        {
            var validador = new ViajeValidador();
            var viaje = CrearViajeValido();
            viaje.Origen = "";
            viaje.Destino = "";
            viaje.DistanciaKm = -10m;
            viaje.IdConductor = 0;

            bool resultado = validador.Validar(viaje);

            Assert.False(resultado);
            Assert.NotEmpty(validador.ObtenerErrores());
        }
    }
}
