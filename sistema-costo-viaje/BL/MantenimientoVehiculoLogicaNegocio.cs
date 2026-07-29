using SistemaCostoViaje.DAL;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.BL
{
    public class MantenimientoVehiculoLogicaNegocio
    {
        private readonly MantenimientoVehiculoDAL _mantenimientoDAL;
        private readonly MantenimientoVehiculoValidador _validador;

        public MantenimientoVehiculoLogicaNegocio()
        {
            _mantenimientoDAL = new MantenimientoVehiculoDAL();
            _validador = new MantenimientoVehiculoValidador();
        }

        public List<MantenimientoVehiculo> ObtenerTodos()
        {
            return _mantenimientoDAL.ObtenerTodos();
        }

        public MantenimientoVehiculo? ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            return _mantenimientoDAL.ObtenerPorId(id);
        }

        public List<MantenimientoVehiculo> ObtenerPorVehiculoId(int vehiculoId)
        {
            if (vehiculoId <= 0)
                throw new ArgumentException("El ID del vehículo debe ser mayor que cero", nameof(vehiculoId));

            return _mantenimientoDAL.ObtenerPorVehiculoId(vehiculoId);
        }

        public MantenimientoVehiculo Crear(MantenimientoVehiculo mantenimiento)
        {
            if (mantenimiento == null)
                throw new ArgumentNullException(nameof(mantenimiento));

            if (!_validador.Validar(mantenimiento))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos de mantenimiento inválidos: {errores}");
            }

            return _mantenimientoDAL.Crear(mantenimiento);
        }

        public MantenimientoVehiculo Actualizar(MantenimientoVehiculo mantenimiento)
        {
            if (mantenimiento == null)
                throw new ArgumentNullException(nameof(mantenimiento));

            if (mantenimiento.Id <= 0)
                throw new ArgumentException("El ID del mantenimiento es inválido", nameof(mantenimiento.Id));

            if (!_validador.Validar(mantenimiento))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos de mantenimiento inválidos: {errores}");
            }

            var actualizado = _mantenimientoDAL.Actualizar(mantenimiento);
            if (actualizado == null)
                throw new InvalidOperationException("No se encontró el mantenimiento para actualizar");

            return actualizado;
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            return _mantenimientoDAL.Eliminar(id);
        }
    }
}
