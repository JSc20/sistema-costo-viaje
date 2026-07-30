using System.Collections.Generic;
using System.Linq;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class DestinoDAL
    {
        private static readonly List<Destino> _destinos = new();
        private static int _nextId = 1;

        public List<Destino> ObtenerTodos()
        {
            return _destinos.Select(Clone).ToList();
        }

        public Destino? ObtenerPorId(int id)
        {
            return Clone(_destinos.FirstOrDefault(d => d.Id == id));
        }

        public Destino Crear(Destino destino)
        {
            var nuevoDestino = Clone(destino);
            nuevoDestino.Id = _nextId++;
            _destinos.Add(nuevoDestino);
            return Clone(nuevoDestino);
        }

        public Destino? Actualizar(Destino destino)
        {
            var existente = _destinos.FirstOrDefault(d => d.Id == destino.Id);
            if (existente == null)
                return null;

            existente.PeajeId = destino.PeajeId;
            existente.Nombre = destino.Nombre;
            existente.KmIdaVuelta = destino.KmIdaVuelta;

            return Clone(existente);
        }

        public bool Eliminar(int id)
        {
            var destino = _destinos.FirstOrDefault(d => d.Id == id);
            if (destino == null)
                return false;

            return _destinos.Remove(destino);
        }

        private static Destino Clone(Destino? destino)
        {
            if (destino == null)
                return null!;

            return new Destino
            {
                Id = destino.Id,
                PeajeId = destino.PeajeId,
                Nombre = destino.Nombre,
                KmIdaVuelta = destino.KmIdaVuelta
            };
        }
    }
}
