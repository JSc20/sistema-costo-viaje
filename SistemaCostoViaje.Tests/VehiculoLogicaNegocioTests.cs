using Xunit;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Tests
{
    public class VehiculoLogicaNegocioTests
    {
        private Vehiculo CrearVehiculoValido()
        {
            return new Vehiculo
            {
                Marca = "Toyota",
                Modelo = "Corolla",
                Año = DateTime.Now.Year - 2,
                CostoPorKm = 0.80m,
                ValorActual = 8000000m,
                ValorFuturo = 3000000m,
                KmRestantesUso = 100000,
                KmAnuales = 15000,
                CostosFijosAnuales = 400000m
            };
        }

        [Fact]
        public void ObtenerTodos_DeberiaRetornarListaConDatosSemilla()
        {
            var logica = new VehiculoLogicaNegocio();

            var vehiculos = logica.ObtenerTodos();

            Assert.NotEmpty(vehiculos);
        }

        [Fact]
        public void Crear_VehiculoValido_DeberiaPersistirYAsignarId()
        {
            var logica = new VehiculoLogicaNegocio();

            var creado = logica.Crear(CrearVehiculoValido());

            Assert.True(creado.Id > 0);
            Assert.Equal("Toyota", creado.Marca);
        }

        [Fact]
        public void Crear_VehiculoNulo_DeberiaLanzarArgumentoNulo()
        {
            var logica = new VehiculoLogicaNegocio();

            Assert.Throws<ArgumentNullException>(() => logica.Crear(null!));
        }

        [Fact]
        public void Crear_VehiculoSinMarca_DeberiaLanzarArgumento()
        {
            var logica = new VehiculoLogicaNegocio();
            var vehiculo = CrearVehiculoValido();
            vehiculo.Marca = "";

            Assert.Throws<ArgumentException>(() => logica.Crear(vehiculo));
        }

        [Fact]
        public void Crear_VehiculoSinModelo_DeberiaLanzarArgumento()
        {
            var logica = new VehiculoLogicaNegocio();
            var vehiculo = CrearVehiculoValido();
            vehiculo.Modelo = "";

            Assert.Throws<ArgumentException>(() => logica.Crear(vehiculo));
        }

        [Fact]
        public void Crear_VehiculoConAnioInvalido_DeberiaLanzarArgumento()
        {
            var logica = new VehiculoLogicaNegocio();
            var vehiculo = CrearVehiculoValido();
            vehiculo.Año = 1800;

            Assert.Throws<ArgumentException>(() => logica.Crear(vehiculo));
        }

        [Fact]
        public void Crear_VehiculoConCostoPorKmInvalido_DeberiaLanzarArgumento()
        {
            var logica = new VehiculoLogicaNegocio();
            var vehiculo = CrearVehiculoValido();
            vehiculo.CostoPorKm = 0;

            Assert.Throws<ArgumentException>(() => logica.Crear(vehiculo));
        }

        [Fact]
        public void ObtenerPorId_IdValido_DeberiaDevolverVehiculo()
        {
            var logica = new VehiculoLogicaNegocio();

            var vehiculo = logica.ObtenerPorId(1);

            Assert.NotNull(vehiculo);
            Assert.Equal(1, vehiculo!.Id);
        }

        [Fact]
        public void ObtenerPorId_IdInvalido_DeberiaLanzarArgumento()
        {
            var logica = new VehiculoLogicaNegocio();

            Assert.Throws<ArgumentException>(() => logica.ObtenerPorId(0));
        }

        [Fact]
        public void Actualizar_VehiculoValido_DeberiaActualizarLosDatos()
        {
            var logica = new VehiculoLogicaNegocio();
            var creado = logica.Crear(CrearVehiculoValido());
            creado.Modelo = "Camry";

            var actualizado = logica.Actualizar(creado);

            Assert.Equal("Camry", actualizado.Modelo);
        }

        [Fact]
        public void Actualizar_VehiculoSinMarca_DeberiaLanzarArgumento()
        {
            var logica = new VehiculoLogicaNegocio();
            var creado = logica.Crear(CrearVehiculoValido());
            creado.Marca = "";

            Assert.Throws<ArgumentException>(() => logica.Actualizar(creado));
        }

        [Fact]
        public void Actualizar_VehiculoInexistente_DeberiaLanzarExcepcion()
        {
            var logica = new VehiculoLogicaNegocio();
            var vehiculo = CrearVehiculoValido();
            vehiculo.Id = 999999;

            Assert.Throws<InvalidOperationException>(() => logica.Actualizar(vehiculo));
        }

        [Fact]
        public void Eliminar_IdValido_DeberiaEliminar()
        {
            var logica = new VehiculoLogicaNegocio();
            var creado = logica.Crear(CrearVehiculoValido());

            bool eliminado = logica.Eliminar(creado.Id);

            Assert.True(eliminado);
            Assert.Null(logica.ObtenerPorId(creado.Id));
        }

        [Fact]
        public void Eliminar_IdInvalido_DeberiaLanzarArgumento()
        {
            var logica = new VehiculoLogicaNegocio();

            Assert.Throws<ArgumentException>(() => logica.Eliminar(-1));
        }

        [Fact]
        public void Eliminar_IdInexistente_DeberiaRetornarFalso()
        {
            var logica = new VehiculoLogicaNegocio();

            bool eliminado = logica.Eliminar(999999);

            Assert.False(eliminado);
        }

        [Fact]
        public void Eliminar_VehiculoConDatosRelacionados_DeberiaEliminarTambienRendimientosYMantenimientos()
        {
            var logicaVehiculo = new VehiculoLogicaNegocio();
            var logicaRendimiento = new RendimientoVehiculoLogicaNegocio();
            var logicaMantenimiento = new MantenimientoVehiculoLogicaNegocio();

            var creado = logicaVehiculo.Crear(CrearVehiculoValido());
            logicaRendimiento.Crear(new RendimientoVehiculo
            {
                vehiculo_id = creado.Id,
                tipo_combustible_id = 1,
                tipo_entorno = "Urbano",
                km_por_litro = 12.5m,
                costo_por_km = 0.10m
            });
            logicaMantenimiento.Crear(new MantenimientoVehiculo
            {
                VehiculoId = creado.Id,
                Descripcion = "Cambio de aceite",
                CostoTotal = 10000m,
                KmIntervalo = 5000
            });

            bool eliminado = logicaVehiculo.Eliminar(creado.Id);

            Assert.True(eliminado);
            Assert.Null(logicaVehiculo.ObtenerPorId(creado.Id));
            Assert.Empty(logicaRendimiento.ObtenerPorVehiculoId(creado.Id));
            Assert.Empty(logicaMantenimiento.ObtenerPorVehiculoId(creado.Id));
        }

        [Fact]
        public void DepreciacionPorKm_DeberiaCalcularConDatosValidos()
        {
            var vehiculo = CrearVehiculoValido();

            Assert.Equal(50m, vehiculo.DepreciacionPorKm);
        }

        [Fact]
        public void DepreciacionPorKm_KmRestantesUsoCero_DeberiaDevolverCero()
        {
            var vehiculo = CrearVehiculoValido();
            vehiculo.KmRestantesUso = 0;

            Assert.Equal(0m, vehiculo.DepreciacionPorKm);
        }

        [Fact]
        public void CostoFijoPorKm_DeberiaCalcularConDatosValidos()
        {
            var vehiculo = CrearVehiculoValido();

            Assert.Equal(26.67m, Math.Round(vehiculo.CostoFijoPorKm, 2));
        }

        [Fact]
        public void CostoFijoPorKm_KmAnualesCero_DeberiaDevolverCero()
        {
            var vehiculo = CrearVehiculoValido();
            vehiculo.KmAnuales = 0;

            Assert.Equal(0m, vehiculo.CostoFijoPorKm);
        }

        [Fact]
        public void CalcularCostoOperacional_VehiculoSemilla_DeberiaDevolverCostoPorKm()
        {
            var logica = new VehiculoLogicaNegocio();

            decimal costo = logica.CalcularCostoOperacional(1);

            Assert.Equal(77.47m, costo);
        }

        [Fact]
        public void CalcularCostoOperacional_VehiculoInexistente_DeberiaLanzarExcepcion()
        {
            var logica = new VehiculoLogicaNegocio();

            Assert.Throws<InvalidOperationException>(() => logica.CalcularCostoOperacional(999999));
        }

        [Fact]
        public void CalcularCostoOperacional_IdInvalido_DeberiaLanzarArgumento()
        {
            var logica = new VehiculoLogicaNegocio();

            Assert.Throws<ArgumentException>(() => logica.CalcularCostoOperacional(0));
        }
    }
}
