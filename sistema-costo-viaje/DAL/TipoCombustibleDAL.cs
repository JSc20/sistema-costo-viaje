using System.Collections.Generic;
using System.Linq;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class TipoCombustibleDAL
    {
        private static readonly List<TpoCombustible> _tiposCombustible = new();
        private static int _nextId = 1;

        public List<TpoCombustible> ObtenerTodos()
        {
            return _tiposCombustible.Select(Clone).ToList();
        }

        public TpoCombustible? ObtenerPorId(int id)
        {
            return Clone(_tiposCombustible.FirstOrDefault(t => t.Id == id));
        }

        public TpoCombustible Crear(TpoCombustible tipoCombustible  )
        {
            var nuevoTipoCombustible = Clone(tipoCombustible);
            nuevoTipoCombustible.Id = _nextId++;
            _tiposCombustible.Add(nuevoTipoCombustible);
            return Clone(nuevoTipoCombustible);
        }

        public TpoCombustible? Actualizar(TpoCombustible tipoCombustible)
        {
            var existente = _tiposCombustible.FirstOrDefault(t => t.Id == tipoCombustible.Id);
            if (existente == null)
                return null;

            existente.Nombre = tipoCombustible.Nombre;
            existente.CostoPorLitro = tipoCombustible.CostoPorLitro;

            return Clone(existente);
        }

        public bool Eliminar(int id)
        {
            var tipoCombustible = _tiposCombustible.FirstOrDefault(t => t.Id == id);
            if (tipoCombustible == null)
                return false;

            return _tiposCombustible.Remove(tipoCombustible);
        }

        private static TpoCombustible Clone(TpoCombustible? tipoCombustible)
        {
            if (tipoCombustible == null)
                return null!;

            return new TpoCombustible
            {
                Id = tipoCombustible.Id,
                Nombre = tipoCombustible.Nombre,
                CostoPorLitro = tipoCombustible.CostoPorLitro
            };
        }
    }
}
