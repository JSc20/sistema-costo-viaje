using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.VL
{
    /// <summary>
    /// Capa de Validación (VL): TipoCombustibleValidador
    /// Responsable de validar la integridad de los datos de entrada
    /// </summary>
    public class TipoCombustibleValidador
    {
        private readonly List<string> _errores;

        public TipoCombustibleValidador()
        {
            _errores = new List<string>();
        }

        public bool Validar(TipoCombustible tipoCombustible)
        {
            _errores.Clear();

            if (tipoCombustible == null)
            {
                _errores.Add("El tipo de combustible no puede ser nulo");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tipoCombustible.Nombre))
                _errores.Add("El nombre es requerido");

            if (tipoCombustible.CostoPorLitro <= 0)
                _errores.Add("El costo por litro debe ser mayor a 0");

            return _errores.Count == 0;
        }

        public List<string> ObtenerErrores()
        {
            return new List<string>(_errores);
        }
    }
}
