using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.VL
{
    public class DestinoValidador
    {
        private readonly List<string> _errores;

        public DestinoValidador()
        {
            _errores = new List<string>();
        }

        public bool Validar(Destino destino)
        {
            _errores.Clear();

            if (destino == null)
            {
                _errores.Add("El destino no puede ser nulo");
                return false;
            }

            if (string.IsNullOrWhiteSpace(destino.Nombre))
                _errores.Add("El nombre del destino es requerido");

            if (destino.KmIdaVuelta <= 0)
                _errores.Add("Los kilómetros ida y vuelta deben ser mayor a 0");

            return _errores.Count == 0;
        }

        public List<string> ObtenerErrores()
        {
            return new List<string>(_errores);
        }
    }
}
