using SistemaCostoViaje.DAL;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.BL
{
    public class ViaticoViajeLogicaNegocio
    {
        private readonly ViaticoViajeDAL _viaticoDAL;
        private readonly ViaticoViajeValidador _validador;

        public ViaticoViajeLogicaNegocio()
        {
            _viaticoDAL = new ViaticoViajeDAL();
            _validador = new ViaticoViajeValidador();
        }

        public List<ViaticoViaje> ObtenerTodos() => _viaticoDAL.ObtenerTodos();

        public ViaticoViaje? ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));
            return _viaticoDAL.ObtenerPorId(id);
        }

        public List<ViaticoViaje> ObtenerPorViajeId(int viajeId)
        {
            if (viajeId <= 0)
                throw new ArgumentException("El ID del viaje debe ser mayor que cero", nameof(viajeId));
            return _viaticoDAL.ObtenerPorViajeId(viajeId);
        }

        public ViaticoViaje Crear(ViaticoViaje viatico)
        {
            if (viatico == null)
                throw new ArgumentNullException(nameof(viatico));

            if (!_validador.Validar(viatico))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del viático inválidos: {errores}");
            }

            return _viaticoDAL.Crear(viatico);
        }

        public ViaticoViaje Actualizar(ViaticoViaje viatico)
        {
            if (viatico == null)
                throw new ArgumentNullException(nameof(viatico));

            if (viatico.Id <= 0)
                throw new ArgumentException("El ID del viático es inválido", nameof(viatico.Id));

            if (!_validador.Validar(viatico))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del viático inválidos: {errores}");
            }

            var actualizado = _viaticoDAL.Actualizar(viatico);
            if (actualizado == null)
                throw new InvalidOperationException("No se encontró el viático para actualizar");

            return actualizado;
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));
            return _viaticoDAL.Eliminar(id);
        }

        public decimal CalcularTotalViaticosPorViaje(int viajeId)
        {
            if (viajeId <= 0)
                throw new ArgumentException("El ID del viaje debe ser mayor que cero", nameof(viajeId));

            var viaticos = _viaticoDAL.ObtenerPorViajeId(viajeId);
            return Math.Round(viaticos.Sum(v => v.Monto), 2);
        }
    }
}
