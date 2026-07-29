using System.Collections.Generic;
using System.Linq;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class TipoCombustibleDAL
    {
        private static readonly List<TipoCombustible> _tiposCombustible = new();
        private static int _nextId = 1;

        public List<TipoCombustible> ObtenerTodos()
        {
            return _tiposCombustible.Select(Clone).ToList();
        }

        public TipoCombustible? ObtenerPorId(int id)
        {
            return Clone(_tiposCombustible.FirstOrDefault(t => t.Id == id));
        }

        public TipoCombustible Crear(TipoCombustible tipoCombustible  )
        {
            var nuevoTipoCombustible = Clone(tipoCombustible);
            nuevoTipoCombustible.Id = _nextId++;
            _tiposCombustible.Add(nuevoTipoCombustible);
            return Clone(nuevoTipoCombustible);
        }

        public TipoCombustible? Actualizar(TipoCombustible tipoCombustible)
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

        private static TipoCombustible Clone(TipoCombustible? tipoCombustible)
        {
            if (tipoCombustible == null)
                return null!;

            return new TipoCombustible
            {
                Id = tipoCombustible.Id,
                Nombre = tipoCombustible.Nombre,
                CostoPorLitro = tipoCombustible.CostoPorLitro
            };
        }
    }
}
