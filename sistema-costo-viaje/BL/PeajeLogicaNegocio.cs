using SistemaCostoViaje.DAL;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.BL
{
    public class PeajeLogicaNegocio
    {
        private readonly PeajeDAL _peajeDAL;
        private readonly PeajeValidador _validador;

        public PeajeLogicaNegocio()
        {
            _peajeDAL = new PeajeDAL();
            _validador = new PeajeValidador();
        }

        public List<Peaje> ObtenerTodos()
        {
            return _peajeDAL.ObtenerTodos();
        }

        public Peaje? ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            return _peajeDAL.ObtenerPorId(id);
        }

        public Peaje Crear(Peaje peaje)
        {
            if (peaje == null)
                throw new ArgumentNullException(nameof(peaje));

            if (!_validador.Validar(peaje))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del peaje inválidos: {errores}");
            }

            return _peajeDAL.Crear(peaje);
        }

        public Peaje Actualizar(Peaje peaje)
        {
            if (peaje == null)
                throw new ArgumentNullException(nameof(peaje));

            if (peaje.Id <= 0)
                throw new ArgumentException("El ID del peaje es inválido", nameof(peaje.Id));

            if (!_validador.Validar(peaje))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del peaje inválidos: {errores}");
            }

            var actualizado = _peajeDAL.Actualizar(peaje);
            if (actualizado == null)
                throw new InvalidOperationException("No se encontró el peaje para actualizar");

            return actualizado;
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            return _peajeDAL.Eliminar(id);
        }
    }
}
