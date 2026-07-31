using Xunit;
using SistemaCostoViaje.BL;

namespace SistemaCostoViaje.Tests
{
    public class TecnicoLogicaNegocioTests
    {
        [Fact]
        public void CalcularCostoHoraOrdinaria_DeberiaCalcularCorrectamente()
        {
            var logica = new TecnicoLogicaNegocio();
            decimal salarioMensual = 3000m;
            int horasSemanales = 40;
            decimal costo = logica.CalcularCostoHoraOrdinaria(salarioMensual, horasSemanales);
            // 3000 / (4 semanas * 40 horas) = 18.75
            Assert.Equal(18.75m, costo);
        }

        [Fact]
        public void CalcularCostoHoraExtra_DeberiaAplicarFactorRecargo()
        {
            var logica = new TecnicoLogicaNegocio();
            decimal costoHoraOrdinaria = 20m;
            decimal factorRecargo = 1.5m;
            decimal costoExtra = logica.CalcularCostoHoraExtra(costoHoraOrdinaria, factorRecargo);
            Assert.Equal(30m, costoExtra);
        }
    }
}
