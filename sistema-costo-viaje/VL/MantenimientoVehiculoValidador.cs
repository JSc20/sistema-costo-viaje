using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.VL
{
    public class MantenimientoVehiculoValidador
    {
        private readonly List<string> _errores;

        public MantenimientoVehiculoValidador()
        {
            _errores = new List<string>();
        }

        public bool Validar(MantenimientoVehiculo mantenimiento)
        {
            _errores.Clear();

            if (mantenimiento == null)
            {
                _errores.Add("El mantenimiento del vehículo no puede ser nulo");
                return false;
            }

            if (mantenimiento.VehiculoId <= 0)
                _errores.Add("El ID del vehículo es inválido");

            if (string.IsNullOrWhiteSpace(mantenimiento.Descripcion))
                _errores.Add("La descripción del mantenimiento es requerida");

            if (mantenimiento.CostoTotal < 0)
                _errores.Add("El costo total no puede ser negativo");

            if (mantenimiento.KmIntervalo <= 0)
                _errores.Add("El intervalo de kilómetros debe ser mayor a 0");

            if (mantenimiento.CostoPorKm < 0)
                _errores.Add("El costo por kilómetro no puede ser negativo");

            return _errores.Count == 0;
        }

        public List<string> ObtenerErrores()
        {
            return new List<string>(_errores);
        }
    }
}
