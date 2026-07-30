using SistemaCostoViaje.DAL;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.BL
{
    public class TipoCombustibleLogicaNegocio
    {
        private readonly TipoCombustibleDAL _tipoCombustibleDAL;
        private readonly TipoCombustibleValidador _validador;

        public TipoCombustibleLogicaNegocio()
        {
            _tipoCombustibleDAL = new TipoCombustibleDAL();
            _validador = new TipoCombustibleValidador();
        }

        public List<TipoCombustible> ObtenerTodos()
        {
            return _tipoCombustibleDAL.ObtenerTodos();
        }

        public TipoCombustible? ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            return _tipoCombustibleDAL.ObtenerPorId(id);
        }

        public TipoCombustible Crear(TipoCombustible tipoCombustible)
        {
            if (tipoCombustible == null)
                throw new ArgumentNullException(nameof(tipoCombustible));

            if (!_validador.Validar(tipoCombustible))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del tipo de combustible inválidos: {errores}");
            }

            return _tipoCombustibleDAL.Crear(tipoCombustible);
        }

        public TipoCombustible Actualizar(TipoCombustible tipoCombustible)
        {
            if (tipoCombustible == null)
                throw new ArgumentNullException(nameof(tipoCombustible));

            if (tipoCombustible.Id <= 0)
                throw new ArgumentException("El ID del tipo de combustible es inválido", nameof(tipoCombustible.Id));

            if (!_validador.Validar(tipoCombustible))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del tipo de combustible inválidos: {errores}");
            }

            var actualizado = _tipoCombustibleDAL.Actualizar(tipoCombustible);
            if (actualizado == null)
                throw new InvalidOperationException("No se encontró el tipo de combustible para actualizar");

            return actualizado;
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            return _tipoCombustibleDAL.Eliminar(id);
        }
    }
}
