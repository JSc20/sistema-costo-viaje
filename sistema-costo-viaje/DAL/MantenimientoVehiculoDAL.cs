using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class MantenimientoVehiculoDAL
    {
        private static readonly List<MantenimientoVehiculo> _mantenimientos = new();
        private static int _nextId = 1;

        public List<MantenimientoVehiculo> ObtenerTodos()
        {
            return _mantenimientos.Select(Clone).ToList();
        }

        public MantenimientoVehiculo? ObtenerPorId(int id)
        {
            return Clone(_mantenimientos.FirstOrDefault(m => m.Id == id));
        }

        public List<MantenimientoVehiculo> ObtenerPorVehiculoId(int vehiculoId)
        {
            return _mantenimientos
                .Where(m => m.VehiculoId == vehiculoId)
                .Select(Clone)
                .ToList();
        }

        public MantenimientoVehiculo Crear(MantenimientoVehiculo mantenimiento)
        {
            var nuevoMantenimiento = Clone(mantenimiento);
            nuevoMantenimiento.Id = _nextId++;
            _mantenimientos.Add(nuevoMantenimiento);
            return Clone(nuevoMantenimiento);
        }

        public MantenimientoVehiculo? Actualizar(MantenimientoVehiculo mantenimiento)
        {
            var existente = _mantenimientos.FirstOrDefault(m => m.Id == mantenimiento.Id);
            if (existente == null)
                return null;

            existente.VehiculoId = mantenimiento.VehiculoId;
            existente.Descripcion = mantenimiento.Descripcion;
            existente.CostoTotal = mantenimiento.CostoTotal;
            existente.KmIntervalo = mantenimiento.KmIntervalo;
            existente.CostoPorKm = mantenimiento.CostoPorKm;

            return Clone(existente);
        }

        public bool Eliminar(int id)
        {
            var mantenimiento = _mantenimientos.FirstOrDefault(m => m.Id == id);
            if (mantenimiento == null)
                return false;

            return _mantenimientos.Remove(mantenimiento);
        }

        private static MantenimientoVehiculo Clone(MantenimientoVehiculo? mantenimiento)
        {
            if (mantenimiento == null)
                return null!;

            return new MantenimientoVehiculo
            {
                Id = mantenimiento.Id,
                VehiculoId = mantenimiento.VehiculoId,
                Descripcion = mantenimiento.Descripcion,
                CostoTotal = mantenimiento.CostoTotal,
                KmIntervalo = mantenimiento.KmIntervalo,
                CostoPorKm = mantenimiento.CostoPorKm
            };
        }
    }
}
