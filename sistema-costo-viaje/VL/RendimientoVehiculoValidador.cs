using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.VL
{
    public class RendimientoVehiculoValidador
    {
        private readonly List<string> _errores;

        public RendimientoVehiculoValidador()
        {
            _errores = new List<string>();
        }

        public bool Validar(RendimientoVehiculo rendimiento)
        {
            _errores.Clear();

            if (rendimiento == null)
            {
                _errores.Add("El rendimiento del vehículo no puede ser nulo");
                return false;
            }

            if (rendimiento.vehiculo_id <= 0)
                _errores.Add("El ID del vehículo es inválido");

            if (rendimiento.tipo_combustible_id <= 0)
                _errores.Add("El ID del tipo de combustible es inválido");

            if (string.IsNullOrWhiteSpace(rendimiento.tipo_entorno))
                _errores.Add("El tipo de entorno es requerido");
            else
            {
                string entorno = rendimiento.tipo_entorno.Trim().ToLower();
                if (entorno != "urbano" && entorno != "carretera" && entorno != "mixto")
                    _errores.Add("El tipo de entorno debe ser 'Urbano', 'Carretera' o 'Mixto'");
            }

            if (rendimiento.km_por_litro <= 0)
                _errores.Add("Los kilómetros por litro deben ser mayor a 0");

            if (rendimiento.costo_por_km < 0)
                _errores.Add("El costo por kilómetro no puede ser negativo");

            return _errores.Count == 0;
        }

        public List<string> ObtenerErrores()
        {
            return new List<string>(_errores);
        }
    }
}
