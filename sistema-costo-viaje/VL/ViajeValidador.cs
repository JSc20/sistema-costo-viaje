using System;
using System.Collections.Generic;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.VL
{
    /// <summary>
    /// Capa de Validación (VL): ViajeValidador
    /// Responsable de validar la integridad de los datos de entrada
    /// </summary>
    public class ViajeValidador
    {
        private readonly List<string> _errores;

        public ViajeValidador()
        {
            _errores = new List<string>();
        }

        public bool Validar(Viaje viaje)
        {
            _errores.Clear();

            if (viaje == null)
            {
                _errores.Add("El viaje no puede ser nulo");
                return false;
            }

            if (string.IsNullOrWhiteSpace(viaje.Origen))
                _errores.Add("El origen es requerido");

            if (string.IsNullOrWhiteSpace(viaje.Destino))
                _errores.Add("El destino es requerido");

            if (viaje.DistanciaKm <= 0)
                _errores.Add("La distancia debe ser mayor a 0 km");

            if (viaje.CostoBase < 0)
                _errores.Add("El costo base no puede ser negativo");

            if (viaje.FechaViaje < DateTime.Now.Date)
                _errores.Add("La fecha del viaje no puede ser anterior a hoy");

            if (viaje.IdConductor <= 0)
                _errores.Add("El Id del conductor es inválido");

            if (viaje.Origen.Equals(viaje.Destino, StringComparison.OrdinalIgnoreCase))
                _errores.Add("El origen y destino no pueden ser iguales");

            return _errores.Count == 0;
        }

        public List<string> ObtenerErrores()
        {
            return new List<string>(_errores);
        }
    }
}