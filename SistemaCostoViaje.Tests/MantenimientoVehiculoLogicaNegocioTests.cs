using Xunit;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Tests
{
    public class MantenimientoVehiculoLogicaNegocioTests
    {
        private MantenimientoVehiculo CrearMantenimientoValido()
        {
            return new MantenimientoVehiculo
            {
                VehiculoId = 1,
                Descripcion = "Cambio de aceite",
                CostoTotal = 10000m,
                KmIntervalo = 5000
            };
        }

        [Fact]
        public void CalcularCostoPorKm_DeberiaCalcularCorrectamente()
        {
            var logica = new MantenimientoVehiculoLogicaNegocio();

            decimal costo = logica.CalcularCostoPorKm(10000m, 5000);

            // 10000 / 5000 = 2.00
            Assert.Equal(2.00m, costo);
        }

        [Fact]
        public void CalcularCostoPorKm_CostoNegativo_DeberiaLanzarArgumento()
        {
            var logica = new MantenimientoVehiculoLogicaNegocio();

            Assert.Throws<ArgumentException>(() => logica.CalcularCostoPorKm(-100m, 5000));
        }

        [Fact]
        public void CalcularCostoPorKm_IntervaloInvalido_DeberiaLanzarArgumento()
        {
            var logica = new MantenimientoVehiculoLogicaNegocio();

            Assert.Throws<ArgumentException>(() => logica.CalcularCostoPorKm(10000m, 0));
        }

        [Fact]
        public void Crear_MantenimientoValido_DeberiaCalcularCostoPorKm()
        {
            var logica = new MantenimientoVehiculoLogicaNegocio();

            var creado = logica.Crear(CrearMantenimientoValido());

            Assert.True(creado.Id > 0);
            Assert.Equal(2.00m, creado.CostoPorKm);
        }

        [Fact]
        public void Crear_MantenimientoNulo_DeberiaLanzarArgumentoNulo()
        {
            var logica = new MantenimientoVehiculoLogicaNegocio();

            Assert.Throws<ArgumentNullException>(() => logica.Crear(null!));
        }

        [Fact]
        public void Crear_SinDescripcion_DeberiaLanzarArgumento()
        {
            var logica = new MantenimientoVehiculoLogicaNegocio();
            var mantenimiento = CrearMantenimientoValido();
            mantenimiento.Descripcion = "";

            Assert.Throws<ArgumentException>(() => logica.Crear(mantenimiento));
        }

        [Fact]
        public void Crear_VehiculoIdInvalido_DeberiaLanzarArgumento()
        {
            var logica = new MantenimientoVehiculoLogicaNegocio();
            var mantenimiento = CrearMantenimientoValido();
            mantenimiento.VehiculoId = 0;

            Assert.Throws<ArgumentException>(() => logica.Crear(mantenimiento));
        }

        [Fact]
        public void ObtenerPorVehiculoId_DeberiaFiltrarPorVehiculo()
        {
            var logica = new MantenimientoVehiculoLogicaNegocio();
            var m1 = CrearMantenimientoValido();
            m1.VehiculoId = 10;
            var m2 = CrearMantenimientoValido();
            m2.VehiculoId = 11;
            var c1 = logica.Crear(m1);
            var c2 = logica.Crear(m2);

            var resultados = logica.ObtenerPorVehiculoId(10);

            Assert.Contains(resultados, r => r.Id == c1.Id);
            Assert.DoesNotContain(resultados, r => r.Id == c2.Id);
        }

        [Fact]
        public void Eliminar_IdInvalido_DeberiaLanzarArgumento()
        {
            var logica = new MantenimientoVehiculoLogicaNegocio();

            Assert.Throws<ArgumentException>(() => logica.Eliminar(0));
        }
    }
}
