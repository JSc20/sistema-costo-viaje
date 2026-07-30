using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.VL
{
    public class PeajeValidador
    {
        private readonly List<string> _errores;

        public PeajeValidador()
        {
            _errores = new List<string>();
        }

        public bool Validar(Peaje peaje)
        {
            _errores.Clear();

            if (peaje == null)
            {
                _errores.Add("El peaje no puede ser nulo");
                return false;
            }

            if (string.IsNullOrWhiteSpace(peaje.Nombre))
                _errores.Add("El nombre del peaje es requerido");

            if (peaje.Costo < 0)
                _errores.Add("El costo del peaje no puede ser negativo");

            return _errores.Count == 0;
        }

        public List<string> ObtenerErrores()
        {
            return new List<string>(_errores);
        }
    }
}
