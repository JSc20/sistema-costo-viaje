using Xunit;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Tests
{
    public class ViajeLogicaNegocioTests
    {
        [Fact]
        public void CrearViaje_DeberiaRetornarExitosoYCosto()
        {
            var logica = new ViajeLogicaNegocio();
            var viaje = new Viaje(); // Se asume que existe un constructor por defecto
            var resultado = logica.CrearViaje(viaje);
            Assert.True(resultado.Exitoso);
            Assert.True(resultado.CostoFinal > 0);
        }
    }
}
