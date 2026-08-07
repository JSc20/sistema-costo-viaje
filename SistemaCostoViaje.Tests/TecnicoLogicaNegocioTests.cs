using Xunit;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Tests
{
    public class TecnicoLogicaNegocioTests
    {
        private Tecnico CrearTecnicoValido()
        {
            return new Tecnico
            {
                nombre = "Carlos Mora",
                salario_mensual = 3000m,
                horas_semanales = 40,
                costo_hora_ordinaria = 18.75m,
                costo_hora_extra = 28.13m
            };
        }

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

        [Fact]
        public void CalcularCostoHoraOrdinaria_SalarioNegativo_DeberiaLanzarArgumento()
        {
            var logica = new TecnicoLogicaNegocio();

            Assert.Throws<ArgumentException>(() => logica.CalcularCostoHoraOrdinaria(-100m, 40));
        }

        [Fact]
        public void CalcularCostoHoraOrdinaria_HorasIncorrectas_DeberiaLanzarArgumento()
        {
            var logica = new TecnicoLogicaNegocio();

            Assert.Throws<ArgumentException>(() => logica.CalcularCostoHoraOrdinaria(3000m, 0));
            Assert.Throws<ArgumentException>(() => logica.CalcularCostoHoraOrdinaria(3000m, 200));
        }

        [Fact]
        public void CalcularCostoHoraExtra_FactorInvalido_DeberiaLanzarArgumento()
        {
            var logica = new TecnicoLogicaNegocio();

            Assert.Throws<ArgumentException>(() => logica.CalcularCostoHoraExtra(20m, 1m));
            Assert.Throws<ArgumentException>(() => logica.CalcularCostoHoraExtra(-5m));
        }

        [Fact]
        public void Crear_TecnicoValido_DeberiaPersistirYAsignarId()
        {
            var logica = new TecnicoLogicaNegocio();

            var creado = logica.Crear(CrearTecnicoValido());

            Assert.True(creado.id > 0);
            Assert.Equal("Carlos Mora", creado.nombre);
        }

        [Fact]
        public void Crear_TecnicoNulo_DeberiaLanzarArgumentoNulo()
        {
            var logica = new TecnicoLogicaNegocio();

            Assert.Throws<ArgumentNullException>(() => logica.Crear(null!));
        }

        [Fact]
        public void Crear_TecnicoSinNombre_DeberiaLanzarArgumento()
        {
            var logica = new TecnicoLogicaNegocio();
            var tecnico = CrearTecnicoValido();
            tecnico.nombre = "";

            Assert.Throws<ArgumentException>(() => logica.Crear(tecnico));
        }

        [Fact]
        public void Crear_TecnicoConHorasInvalidas_DeberiaLanzarArgumento()
        {
            var logica = new TecnicoLogicaNegocio();
            var tecnico = CrearTecnicoValido();
            tecnico.horas_semanales = -5;

            Assert.Throws<ArgumentException>(() => logica.Crear(tecnico));
        }

        [Fact]
        public void ObtenerPorId_DeberiaDevolverElTecnico()
        {
            var logica = new TecnicoLogicaNegocio();
            var creado = logica.Crear(CrearTecnicoValido());

            var obtenido = logica.ObtenerPorId(creado.id);

            Assert.NotNull(obtenido);
            Assert.Equal(creado.id, obtenido!.id);
        }

        [Fact]
        public void ObtenerPorId_IdInvalido_DeberiaLanzarArgumento()
        {
            var logica = new TecnicoLogicaNegocio();

            Assert.Throws<ArgumentException>(() => logica.ObtenerPorId(0));
        }

        [Fact]
        public void Actualizar_DeberiaActualizarLosDatos()
        {
            var logica = new TecnicoLogicaNegocio();
            var creado = logica.Crear(CrearTecnicoValido());
            creado.nombre = "Ana Pérez";

            var actualizado = logica.Actualizar(creado);

            Assert.Equal("Ana Pérez", actualizado.nombre);
        }

        [Fact]
        public void Eliminar_DeberiaEliminarElTecnico()
        {
            var logica = new TecnicoLogicaNegocio();
            var creado = logica.Crear(CrearTecnicoValido());

            bool eliminado = logica.Eliminar(creado.id);

            Assert.True(eliminado);
            Assert.Null(logica.ObtenerPorId(creado.id));
        }
    }
}
