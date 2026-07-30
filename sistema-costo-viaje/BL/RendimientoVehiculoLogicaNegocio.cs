using SistemaCostoViaje.DAL;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.BL
{
    public class RendimientoVehiculoLogicaNegocio
    {
        private readonly RendimientoVehiculoDAL _rendimientoDAL;
        private readonly RendimientoVehiculoValidador _validador;

        public RendimientoVehiculoLogicaNegocio()
        {
            _rendimientoDAL = new RendimientoVehiculoDAL();
            _validador = new RendimientoVehiculoValidador();
        }

        public List<RendimientoVehiculo> ObtenerTodos()
        {
            return _rendimientoDAL.ObtenerTodos();
        }

        public RendimientoVehiculo? ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            return _rendimientoDAL.ObtenerPorId(id);
        }

        public List<RendimientoVehiculo> ObtenerPorVehiculoId(int vehiculoId)
        {
            if (vehiculoId <= 0)
                throw new ArgumentException("El ID del vehículo debe ser mayor que cero", nameof(vehiculoId));

            return _rendimientoDAL.ObtenerPorVehiculoId(vehiculoId);
        }

        public RendimientoVehiculo Crear(RendimientoVehiculo rendimiento)
        {
            if (rendimiento == null)
                throw new ArgumentNullException(nameof(rendimiento));

            if (!_validador.Validar(rendimiento))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del rendimiento de vehículo inválidos: {errores}");
            }

            return _rendimientoDAL.Crear(rendimiento);
        }

        public RendimientoVehiculo Actualizar(RendimientoVehiculo rendimiento)
        {
            if (rendimiento == null)
                throw new ArgumentNullException(nameof(rendimiento));

            if (rendimiento.id <= 0)
                throw new ArgumentException("El ID del rendimiento es inválido", nameof(rendimiento.id));

            if (!_validador.Validar(rendimiento))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del rendimiento de vehículo inválidos: {errores}");
            }

            var actualizado = _rendimientoDAL.Actualizar(rendimiento);
            if (actualizado == null)
                throw new InvalidOperationException("No se encontró el rendimiento de vehículo para actualizar");

            return actualizado;
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            return _rendimientoDAL.Eliminar(id);
        }
    }
}
