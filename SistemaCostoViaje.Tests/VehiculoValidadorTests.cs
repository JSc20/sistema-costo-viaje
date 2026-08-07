using Xunit;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.Tests
{
    public class VehiculoValidadorTests
    {
        [Theory]
        [InlineData("ABC123")]
        [InlineData("  abc123  ")]
        [InlineData("1234")]
        public void ValidarPlaca_PlacaValida_DeberiaRetornarTrue(string placa)
        {
            Assert.True(VehiculoValidador.ValidarPlaca(placa));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("AB")]
        [InlineData("ABCDEFGHIJ")]
        public void ValidarPlaca_PlacaInvalida_DeberiaRetornarFalse(string placa)
        {
            Assert.False(VehiculoValidador.ValidarPlaca(placa));
        }

        [Fact]
        public void ValidarMarca_MarcaValida_DeberiaRetornarTrue()
        {
            Assert.True(VehiculoValidador.ValidarMarca("Toyota"));
        }

        [Fact]
        public void ValidarMarca_MarcaCorta_DeberiaRetornarFalse()
        {
            Assert.False(VehiculoValidador.ValidarMarca("T"));
        }

        [Fact]
        public void ValidarModelo_ModeloValido_DeberiaRetornarTrue()
        {
            Assert.True(VehiculoValidador.ValidarModelo("Corolla"));
        }

        [Fact]
        public void ValidarModelo_ModeloVacio_DeberiaRetornarFalse()
        {
            Assert.False(VehiculoValidador.ValidarModelo(""));
        }

        [Fact]
        public void ValidarAnio_AnioValido_DeberiaRetornarTrue()
        {
            Assert.True(VehiculoValidador.ValidarAnio(DateTime.Now.Year - 2));
        }

        [Theory]
        [InlineData(1899)]
        [InlineData(0)]
        [InlineData(-5)]
        public void ValidarAnio_AnioInvalido_DeberiaRetornarFalse(int anio)
        {
            Assert.False(VehiculoValidador.ValidarAnio(anio));
        }

        [Fact]
        public void ValidarAnio_AnioFuturoLejano_DeberiaRetornarFalse()
        {
            Assert.False(VehiculoValidador.ValidarAnio(DateTime.Now.Year + 10));
        }

        [Fact]
        public void ValidarColor_ColorValido_DeberiaRetornarTrue()
        {
            Assert.True(VehiculoValidador.ValidarColor("Rojo"));
        }

        [Theory]
        [InlineData("automovil")]
        [InlineData("CAMION")]
        [InlineData("Moto")]
        [InlineData("Bus")]
        public void ValidarTipo_TipoValido_DeberiaRetornarTrue(string tipo)
        {
            Assert.True(VehiculoValidador.ValidarTipo(tipo));
        }

        [Fact]
        public void ValidarTipo_TipoInvalido_DeberiaRetornarFalse()
        {
            Assert.False(VehiculoValidador.ValidarTipo("Bicicleta"));
        }

        [Theory]
        [InlineData(4)]
        [InlineData(200)]
        public void ValidarCapacidad_CapacidadValida_DeberiaRetornarTrue(int capacidad)
        {
            Assert.True(VehiculoValidador.ValidarCapacidad(capacidad));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(201)]
        [InlineData(-1)]
        public void ValidarCapacidad_CapacidadInvalida_DeberiaRetornarFalse(int capacidad)
        {
            Assert.False(VehiculoValidador.ValidarCapacidad(capacidad));
        }

        [Fact]
        public void ValidarVehiculo_DatosValidos_DeberiaRetornarTrue()
        {
            bool resultado = VehiculoValidador.ValidarVehiculo(
                "ABC123", "Toyota", "Corolla", 2020, "Rojo", "automovil", 5);

            Assert.True(resultado);
        }

        [Fact]
        public void ValidarVehiculo_DatosInvalidos_DeberiaRetornarFalse()
        {
            bool resultado = VehiculoValidador.ValidarVehiculo(
                "AB", "", "Corolla", 1800, "R", "avion", 0);

            Assert.False(resultado);
        }
    }
}
