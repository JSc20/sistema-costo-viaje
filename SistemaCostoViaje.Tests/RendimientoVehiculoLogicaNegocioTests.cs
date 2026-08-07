using Xunit;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Tests
{
    public class RendimientoVehiculoLogicaNegocioTests
    {
        private RendimientoVehiculo CrearRendimientoValido()
        {
            return new RendimientoVehiculo
            {
                vehiculo_id = 1,
                tipo_combustible_id = 1,
                tipo_entorno = "Urbano",
                km_por_litro = 12.5m,
                costo_por_km = 0.10m
            };
        }

        [Fact]
        public void Crear_RendimientoValido_DeberiaPersistirYAsignarId()
        {
            var logica = new RendimientoVehiculoLogicaNegocio();

            var creado = logica.Crear(CrearRendimientoValido());

            Assert.True(creado.id > 0);
            Assert.Equal(12.5m, creado.km_por_litro);
        }

        [Fact]
        public void Crear_RendimientoNulo_DeberiaLanzarArgumentoNulo()
        {
            var logica = new RendimientoVehiculoLogicaNegocio();

            Assert.Throws<ArgumentNullException>(() => logica.Crear(null!));
        }

        [Fact]
        public void Crear_VehiculoIdInvalido_DeberiaLanzarArgumento()
        {
            var logica = new RendimientoVehiculoLogicaNegocio();
            var rendimiento = CrearRendimientoValido();
            rendimiento.vehiculo_id = 0;

            Assert.Throws<ArgumentException>(() => logica.Crear(rendimiento));
        }

        [Fact]
        public void Crear_EntornoInvalido_DeberiaLanzarArgumento()
        {
            var logica = new RendimientoVehiculoLogicaNegocio();
            var rendimiento = CrearRendimientoValido();
            rendimiento.tipo_entorno = "Autopista";

            Assert.Throws<ArgumentException>(() => logica.Crear(rendimiento));
        }

        [Fact]
        public void Crear_KmPorLitroInvalido_DeberiaLanzarArgumento()
        {
            var logica = new RendimientoVehiculoLogicaNegocio();
            var rendimiento = CrearRendimientoValido();
            rendimiento.km_por_litro = 0;

            Assert.Throws<ArgumentException>(() => logica.Crear(rendimiento));
        }

        [Fact]
        public void ObtenerPorVehiculoId_DeberiaFiltrarPorVehiculo()
        {
            var logica = new RendimientoVehiculoLogicaNegocio();
            var r1 = CrearRendimientoValido();
            r1.vehiculo_id = 20;
            var r2 = CrearRendimientoValido();
            r2.vehiculo_id = 21;
            var c1 = logica.Crear(r1);
            var c2 = logica.Crear(r2);

            var resultados = logica.ObtenerPorVehiculoId(20);

            Assert.Contains(resultados, r => r.id == c1.id);
            Assert.DoesNotContain(resultados, r => r.id == c2.id);
        }

        [Fact]
        public void Actualizar_DeberiaActualizarLosDatos()
        {
            var logica = new RendimientoVehiculoLogicaNegocio();
            var creado = logica.Crear(CrearRendimientoValido());
            creado.km_por_litro = 14m;

            var actualizado = logica.Actualizar(creado);

            Assert.Equal(14m, actualizado.km_por_litro);
        }

        [Fact]
        public void Eliminar_DeberiaEliminarElRendimiento()
        {
            var logica = new RendimientoVehiculoLogicaNegocio();
            var creado = logica.Crear(CrearRendimientoValido());

            bool eliminado = logica.Eliminar(creado.id);

            Assert.True(eliminado);
            Assert.Null(logica.ObtenerPorId(creado.id));
        }
    }
}
