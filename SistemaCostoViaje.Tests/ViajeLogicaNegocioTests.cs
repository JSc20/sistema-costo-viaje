using Xunit;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Tests
{
    public class ViajeLogicaNegocioTests
    {
        private Viaje CrearViajeValido()
        {
            return new Viaje
            {
                Origen = "San José",
                Destino = "Cartago",
                DistanciaKm = 30m,
                FechaViaje = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0).AddDays(1),
                IdConductor = 1,
                VehiculoId = 1,
                TecnicoId = 1
            };
        }

        [Fact]
        public void CrearViaje_ViajeValido_DeberiaRetornarExitoso()
        {
            var logica = new ViajeLogicaNegocio();
            var viaje = CrearViajeValido();

            var resultado = logica.CrearViaje(viaje);

            Assert.True(resultado.Exitoso);
            Assert.True(resultado.CostoFinal > 0);
            Assert.Equal(ViajeEstado.Pendiente, viaje.Estado);
        }

        [Fact]
        public void CrearViaje_SinHoraPico_DeberiaCalcularCostoBase()
        {
            var logica = new ViajeLogicaNegocio();
            var viaje = CrearViajeValido();
            viaje.DistanciaKm = 10m;

            var resultado = logica.CrearViaje(viaje);

            // 10 km * 2.5 = 25.00
            Assert.True(resultado.Exitoso);
            Assert.Equal(25.00m, resultado.CostoFinal);
        }

        [Fact]
        public void CrearViaje_HoraPico_DeberiaAplicarRecargo25()
        {
            var logica = new ViajeLogicaNegocio();
            var viaje = CrearViajeValido();
            viaje.DistanciaKm = 10m;
            viaje.FechaViaje = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0).AddDays(1);

            var resultado = logica.CrearViaje(viaje);

            // 10 km * 2.5 * 1.25 = 31.25
            Assert.True(resultado.Exitoso);
            Assert.Equal(31.25m, resultado.CostoFinal);
        }

        [Fact]
        public void CrearViaje_ViajeLargo_DeberiaAplicarDescuento10()
        {
            var logica = new ViajeLogicaNegocio();
            var viaje = CrearViajeValido();
            viaje.DistanciaKm = 100m;

            var resultado = logica.CrearViaje(viaje);

            // 100 km * 2.5 * 0.90 = 225.00
            Assert.True(resultado.Exitoso);
            Assert.Equal(225.00m, resultado.CostoFinal);
        }

        [Fact]
        public void CrearViaje_ViajeInvalido_DeberiaRetornarFallo()
        {
            var logica = new ViajeLogicaNegocio();
            var viaje = CrearViajeValido();
            viaje.Origen = "";

            var resultado = logica.CrearViaje(viaje);

            Assert.False(resultado.Exitoso);
            Assert.Equal(0m, resultado.CostoFinal);
            Assert.Contains("Validación fallida", resultado.Mensaje);
        }

        [Fact]
        public void ActualizarEstado_PendienteAEnCurso_DeberiaRetornarTrue()
        {
            var logica = new ViajeLogicaNegocio();
            var viaje = CrearViajeValido();
            viaje.Estado = ViajeEstado.Pendiente;

            bool resultado = logica.ActualizarEstado(viaje, ViajeEstado.EnCurso);

            Assert.True(resultado);
            Assert.Equal(ViajeEstado.EnCurso, viaje.Estado);
        }

        [Fact]
        public void ActualizarEstado_TransicionInvalida_DeberiaRetornarFalse()
        {
            var logica = new ViajeLogicaNegocio();
            var viaje = CrearViajeValido();
            viaje.Estado = ViajeEstado.Pendiente;

            bool resultado = logica.ActualizarEstado(viaje, ViajeEstado.Completado);

            Assert.False(resultado);
            Assert.Equal(ViajeEstado.Pendiente, viaje.Estado);
        }

        [Fact]
        public void ActualizarEstado_Completado_DeberiaSerEstadoFinal()
        {
            var logica = new ViajeLogicaNegocio();
            var viaje = CrearViajeValido();
            viaje.Estado = ViajeEstado.Completado;

            bool resultado = logica.ActualizarEstado(viaje, ViajeEstado.Cancelado);

            Assert.False(resultado);
        }

        [Fact]
        public void ActualizarEstado_ViajeNulo_DeberiaRetornarFalse()
        {
            var logica = new ViajeLogicaNegocio();

            bool resultado = logica.ActualizarEstado(null!, ViajeEstado.EnCurso);

            Assert.False(resultado);
        }

        [Fact]
        public void Crear_DeberiaPersistirYAsignarId()
        {
            var logica = new ViajeLogicaNegocio();
            var viaje = CrearViajeValido();

            var creado = logica.Crear(viaje);

            Assert.True(creado.Id > 0);
            Assert.Equal(ViajeEstado.Pendiente, creado.Estado);
            Assert.Equal(viaje.CostoBase, creado.CostoBase);
        }

        [Fact]
        public void ObtenerPorId_DeberiaDevolverElViaje()
        {
            var logica = new ViajeLogicaNegocio();
            var creado = logica.Crear(CrearViajeValido());

            var obtenido = logica.ObtenerPorId(creado.Id);

            Assert.NotNull(obtenido);
            Assert.Equal(creado.Id, obtenido!.Id);
        }

        [Fact]
        public void ObtenerPorId_IdInvalido_DeberiaLanzarArgumento()
        {
            var logica = new ViajeLogicaNegocio();

            Assert.Throws<ArgumentException>(() => logica.ObtenerPorId(0));
        }

        [Fact]
        public void Actualizar_DeberiaActualizarLosDatos()
        {
            var logica = new ViajeLogicaNegocio();
            var creado = logica.Crear(CrearViajeValido());
            creado.Destino = "Alajuela";

            var actualizado = logica.Actualizar(creado);

            Assert.Equal("Alajuela", actualizado.Destino);
        }

        [Fact]
        public void Actualizar_ViajeInexistente_DeberiaLanzarExcepcion()
        {
            var logica = new ViajeLogicaNegocio();
            var viaje = CrearViajeValido();
            viaje.Id = 999999;

            Assert.Throws<InvalidOperationException>(() => logica.Actualizar(viaje));
        }

        [Fact]
        public void Eliminar_DeberiaEliminarElViaje()
        {
            var logica = new ViajeLogicaNegocio();
            var creado = logica.Crear(CrearViajeValido());

            bool eliminado = logica.Eliminar(creado.Id);

            Assert.True(eliminado);
            Assert.Null(logica.ObtenerPorId(creado.Id));
        }

        [Fact]
        public void Eliminar_IdInvalido_DeberiaLanzarArgumento()
        {
            var logica = new ViajeLogicaNegocio();

            Assert.Throws<ArgumentException>(() => logica.Eliminar(-1));
        }
    }
}
