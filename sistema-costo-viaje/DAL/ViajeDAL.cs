using System.Collections.Generic;
using System.Linq;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class ViajeDAL
    {
        private static readonly List<Viaje> _viajes = new();
        private static int _nextId = 1;

        public List<Viaje> ObtenerTodos()
        {
            return _viajes.Select(Clone).ToList();
        }

        public Viaje? ObtenerPorId(int id)
        {
            return Clone(_viajes.FirstOrDefault(v => v.Id == id));
        }

        public Viaje Crear(Viaje viaje)
        {
            var nuevoViaje = Clone(viaje);
            nuevoViaje.Id = _nextId++;
            _viajes.Add(nuevoViaje);
            return Clone(nuevoViaje);
        }

        public Viaje? Actualizar(Viaje viaje)
        {
            var existente = _viajes.FirstOrDefault(v => v.Id == viaje.Id);
            if (existente == null)
                return null;

            existente.Origen = viaje.Origen;
            existente.Destino = viaje.Destino;
            existente.DistanciaKm = viaje.DistanciaKm;
            existente.CostoBase = viaje.CostoBase;
            existente.FechaViaje = viaje.FechaViaje;
            existente.IdConductor = viaje.IdConductor;
            existente.Estado = viaje.Estado;

            return Clone(existente);
        }

        public bool Eliminar(int id)
        {
            var viaje = _viajes.FirstOrDefault(v => v.Id == id);
            if (viaje == null)
                return false;

            return _viajes.Remove(viaje);
        }

        private static Viaje Clone(Viaje? viaje)
        {
            if (viaje == null)
                return null!;

            return new Viaje
            {
                Id = viaje.Id,
                Origen = viaje.Origen,
                Destino = viaje.Destino,
                DistanciaKm = viaje.DistanciaKm,
                CostoBase = viaje.CostoBase,
                FechaViaje = viaje.FechaViaje,
                IdConductor = viaje.IdConductor,
                Estado = viaje.Estado
            };
        }
    }
}
