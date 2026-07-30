using SistemaCostoViaje.DAL;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.BL
{
    public class TecnicoLogicaNegocio
    {
        private readonly TecnicoDAL _tecnicoDAL;
        private readonly TecnicoValidador _validador;

        public TecnicoLogicaNegocio()
        {
            _tecnicoDAL = new TecnicoDAL();
            _validador = new TecnicoValidador();
        }

        public List<Tecnico> ObtenerTodos()
        {
            return _tecnicoDAL.ObtenerTodos();
        }

        public Tecnico? ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            return _tecnicoDAL.ObtenerPorId(id);
        }

        public Tecnico Crear(Tecnico tecnico)
        {
            if (tecnico == null)
                throw new ArgumentNullException(nameof(tecnico));

            if (!_validador.Validar(tecnico))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del técnico inválidos: {errores}");
            }

            return _tecnicoDAL.Crear(tecnico);
        }

        public Tecnico Actualizar(Tecnico tecnico)
        {
            if (tecnico == null)
                throw new ArgumentNullException(nameof(tecnico));

            if (tecnico.id <= 0)
                throw new ArgumentException("El ID del técnico es inválido", nameof(tecnico.id));

            if (!_validador.Validar(tecnico))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del técnico inválidos: {errores}");
            }

            var actualizado = _tecnicoDAL.Actualizar(tecnico);
            if (actualizado == null)
                throw new InvalidOperationException("No se encontró el técnico para actualizar");

            return actualizado;
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            return _tecnicoDAL.Eliminar(id);
        }

        public decimal CalcularCostoHoraOrdinaria(decimal salarioMensual, int horasSemanales)
        {
            if (salarioMensual < 0)
                throw new ArgumentException("El salario mensual no puede ser negativo", nameof(salarioMensual));

            if (horasSemanales <= 0 || horasSemanales > 168)
                throw new ArgumentException("Las horas semanales no son válidas", nameof(horasSemanales));

            const int semanasMes = 4;
            decimal totalHorasMes = horasSemanales * semanasMes;
            return Math.Round(salarioMensual / totalHorasMes, 2);
        }

        public decimal CalcularCostoHoraExtra(decimal costoHoraOrdinaria, decimal factorRecargo = 1.5m)
        {
            if (costoHoraOrdinaria < 0)
                throw new ArgumentException("El costo de hora ordinaria no puede ser negativo", nameof(costoHoraOrdinaria));

            if (factorRecargo <= 1)
                throw new ArgumentException("El factor de recargo debe ser mayor a 1", nameof(factorRecargo));

            return Math.Round(costoHoraOrdinaria * factorRecargo, 2);
        }
    }
}
