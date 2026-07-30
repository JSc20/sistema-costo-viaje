using System.Collections.Generic;
using System.Linq;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class PeajeDAL
    {
        private static readonly List<Peaje> _peajes = new();
        private static int _nextId = 1;

        public List<Peaje> ObtenerTodos()
        {
            return _peajes.Select(Clone).ToList();
        }

        public Peaje? ObtenerPorId(int id)
        {
            return Clone(_peajes.FirstOrDefault(p => p.Id == id));
        }

        public Peaje Crear(Peaje peaje)
        {
            var nuevoPeaje = Clone(peaje);
            nuevoPeaje.Id = _nextId++;
            _peajes.Add(nuevoPeaje);
            return Clone(nuevoPeaje);
        }

        public Peaje? Actualizar(Peaje peaje)
        {
            var existente = _peajes.FirstOrDefault(p => p.Id == peaje.Id);
            if (existente == null)
                return null;

            existente.Nombre = peaje.Nombre;
            existente.Costo = peaje.Costo;

            return Clone(existente);
        }

        public bool Eliminar(int id)
        {
            var peaje = _peajes.FirstOrDefault(p => p.Id == id);
            if (peaje == null)
                return false;

            return _peajes.Remove(peaje);
        }

        private static Peaje Clone(Peaje? peaje)
        {
            if (peaje == null)
                return null!;

            return new Peaje
            {
                Id = peaje.Id,
                Nombre = peaje.Nombre,
                Costo = peaje.Costo
            };
        }
    }
}
