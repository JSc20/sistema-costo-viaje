using SistemaCostoViaje.DAL;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.BL
{
    public class DestinoLogicaNegocio
    {
        private readonly DestinoDAL _destinoDAL;
        private readonly DestinoValidador _validador;

        public DestinoLogicaNegocio()
        {
            _destinoDAL = new DestinoDAL();
            _validador = new DestinoValidador();
        }

        public List<Destino> ObtenerTodos()
        {
            return _destinoDAL.ObtenerTodos();
        }

        public Destino? ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            return _destinoDAL.ObtenerPorId(id);
        }

        public Destino Crear(Destino destino)
        {
            if (destino == null)
                throw new ArgumentNullException(nameof(destino));

            if (!_validador.Validar(destino))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del destino inválidos: {errores}");
            }

            return _destinoDAL.Crear(destino);
        }

        public Destino Actualizar(Destino destino)
        {
            if (destino == null)
                throw new ArgumentNullException(nameof(destino));

            if (destino.Id <= 0)
                throw new ArgumentException("El ID del destino es inválido", nameof(destino.Id));

            if (!_validador.Validar(destino))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del destino inválidos: {errores}");
            }

            var actualizado = _destinoDAL.Actualizar(destino);
            if (actualizado == null)
                throw new InvalidOperationException("No se encontró el destino para actualizar");

            return actualizado;
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            return _destinoDAL.Eliminar(id);
        }
    }
}
