using System.Collections.Generic;
using System.Linq;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class ViaticoViajeDAL
    {
        private static readonly List<ViaticoViaje> _viaticos = new();
        private static int _nextId = 1;

        public List<ViaticoViaje> ObtenerTodos()
        {
            return _viaticos.Select(Clone).ToList();
        }

        public ViaticoViaje? ObtenerPorId(int id)
        {
            return Clone(_viaticos.FirstOrDefault(v => v.Id == id));
        }

        public List<ViaticoViaje> ObtenerPorViajeId(int viajeId)
        {
            return _viaticos
                .Where(v => v.ViajeId == viajeId)
                .Select(Clone)
                .ToList();
        }

        public ViaticoViaje Crear(ViaticoViaje viatico)
        {
            var nuevoViatico = Clone(viatico);
            nuevoViatico.Id = _nextId++;
            _viaticos.Add(nuevoViatico);
            return Clone(nuevoViatico);
        }

        public ViaticoViaje? Actualizar(ViaticoViaje viatico)
        {
            var existente = _viaticos.FirstOrDefault(v => v.Id == viatico.Id);
            if (existente == null)
                return null;

            existente.ViajeId = viatico.ViajeId;
            existente.Tipo = viatico.Tipo;
            existente.Monto = viatico.Monto;

            return Clone(existente);
        }

        public bool Eliminar(int id)
        {
            var viatico = _viaticos.FirstOrDefault(v => v.Id == id);
            if (viatico == null)
                return false;

            return _viaticos.Remove(viatico);
        }

        private static ViaticoViaje Clone(ViaticoViaje? viatico)
        {
            if (viatico == null)
                return null!;

            return new ViaticoViaje
            {
                Id = viatico.Id,
                ViajeId = viatico.ViajeId,
                Tipo = viatico.Tipo,
                Monto = viatico.Monto
            };
        }
    }
}
