using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.VL
{
    public class ViaticoViajeValidador
    {
        private readonly List<string> _errores;

        public ViaticoViajeValidador()
        {
            _errores = new List<string>();
        }

        public bool Validar(ViaticoViaje viatico)
        {
            _errores.Clear();

            if (viatico == null)
            {
                _errores.Add("El viático no puede ser nulo");
                return false;
            }

            if (string.IsNullOrWhiteSpace(viatico.Tipo))
                _errores.Add("El tipo de viático es requerido");
            else
            {
                var tipo = viatico.Tipo.Trim().ToLower();
                if (tipo != "desayuno" && tipo != "almuerzo" && tipo != "cena")
                    _errores.Add("El tipo de viático debe ser 'Desayuno', 'Almuerzo' o 'Cena'");
            }

            if (viatico.Monto <= 0)
                _errores.Add("El monto del viático debe ser mayor a 0");

            return _errores.Count == 0;
        }

        public List<string> ObtenerErrores()
        {
            return new List<string>(_errores);
        }
    }
}
