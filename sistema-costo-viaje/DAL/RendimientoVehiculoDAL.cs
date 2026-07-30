using System.Collections.Generic;
using System.Linq;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class RendimientoVehiculoDAL
    {
        private static readonly List<RendimientoVehiculo> _rendimientos = new();
        private static int _nextId = 1;

        public List<RendimientoVehiculo> ObtenerTodos()
        {
            return _rendimientos.Select(Clone).ToList();
        }

        public RendimientoVehiculo? ObtenerPorId(int id)
        {
            return Clone(_rendimientos.FirstOrDefault(r => r.id == id));
        }

        public List<RendimientoVehiculo> ObtenerPorVehiculoId(int vehiculoId)
        {
            return _rendimientos
                .Where(r => r.vehiculo_id == vehiculoId)
                .Select(Clone)
                .ToList();
        }

        public RendimientoVehiculo Crear(RendimientoVehiculo rendimiento)
        {
            var nuevoRendimiento = Clone(rendimiento);
            nuevoRendimiento.id = _nextId++;
            _rendimientos.Add(nuevoRendimiento);
            return Clone(nuevoRendimiento);
        }

        public RendimientoVehiculo? Actualizar(RendimientoVehiculo rendimiento)
        {
            var existente = _rendimientos.FirstOrDefault(r => r.id == rendimiento.id);
            if (existente == null)
                return null;

            existente.vehiculo_id = rendimiento.vehiculo_id;
            existente.tipo_combustible_id = rendimiento.tipo_combustible_id;
            existente.tipo_entorno = rendimiento.tipo_entorno;
            existente.km_por_litro = rendimiento.km_por_litro;
            existente.costo_por_km = rendimiento.costo_por_km;

            return Clone(existente);
        }

        public bool Eliminar(int id)
        {
            var rendimiento = _rendimientos.FirstOrDefault(r => r.id == id);
            if (rendimiento == null)
                return false;

            return _rendimientos.Remove(rendimiento);
        }

        private static RendimientoVehiculo Clone(RendimientoVehiculo? rendimiento)
        {
            if (rendimiento == null)
                return null!;

            return new RendimientoVehiculo
            {
                id = rendimiento.id,
                vehiculo_id = rendimiento.vehiculo_id,
                tipo_combustible_id = rendimiento.tipo_combustible_id,
                tipo_entorno = rendimiento.tipo_entorno,
                km_por_litro = rendimiento.km_por_litro,
                costo_por_km = rendimiento.costo_por_km
            };
        }
    }
}
