using System;
using System.Collections.Generic;

namespace SistemaCostoViaje.Models
{
    /// <summary>
    /// Entidad: Viaje
    /// Representa un viaje con información de origen, destino y costo
    /// </summary>
    public class Viaje
    {
        public int Id { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public decimal DistanciaKm { get; set; }
        public decimal CostoBase { get; set; }
        public DateTime FechaViaje { get; set; }
        public int IdConductor { get; set; }
        public ViajeEstado Estado { get; set; }
    }

    public enum ViajeEstado
    {
        Pendiente = 1,
        EnCurso = 2,
        Completado = 3,
        Cancelado = 4
    }

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

    /// <summary>
    /// Capa de Reglas de Negocio (BL): ViajeLógicaNegocio
    /// Responsable de aplicar las reglas de negocio y cálculos
    /// </summary>
    public class ViajeLógicaNegocio
    {
        private readonly ViajeValidador _validador;

        // Constantes de reglas de negocio
        private const decimal PRECIO_POR_KM = 2.5m;
        private const decimal RECARGO_HORA_PICO = 1.25m; // 25% de recargo
        private const decimal DESCUENTO_VIAJE_LARGO = 0.90m; // 10% descuento para viajes > 50 km
        private const decimal DISTANCIA_VIAJE_LARGO = 50m;

        public ViajeLógicaNegocio()
        {
            _validador = new ViajeValidador();
        }

        /// <summary>
        /// Procesa la creación de un nuevo viaje con validación y cálculos
        /// </summary>
        public (bool Exitoso, string Mensaje, decimal CostoFinal) CrearViaje(Viaje viaje)
        {
            if (!_validador.Validar(viaje))
            {
                var errores = string.Join(", ", _validador.ObtenerErrores());
                return (false, $"Validación fallida: {errores}", 0);
            }

            try
            {
                decimal costoFinal = CalcularCostoViaje(viaje);
                viaje.CostoBase = costoFinal;
                viaje.Estado = ViajeEstado.Pendiente;

                return (true, "Viaje creado exitosamente", costoFinal);
            }
            catch (Exception ex)
            {
                return (false, $"Error al crear el viaje: {ex.Message}", 0);
            }
        }

        /// <summary>
        /// Calcula el costo total del viaje aplicando todas las reglas de negocio
        /// </summary>
        private decimal CalcularCostoViaje(Viaje viaje)
        {
            decimal costo = viaje.DistanciaKm * PRECIO_POR_KM;

            // Aplicar recargo en hora pico (7-9 AM y 5-7 PM)
            if (EsHoraPico(viaje.FechaViaje))
            {
                costo *= RECARGO_HORA_PICO;
            }

            // Aplicar descuento para viajes largos
            if (viaje.DistanciaKm > DISTANCIA_VIAJE_LARGO)
            {
                costo *= DESCUENTO_VIAJE_LARGO;
            }

            return Math.Round(costo, 2);
        }

        /// <summary>
        /// Verifica si la hora del viaje corresponde a hora pico
        /// </summary>
        private bool EsHoraPico(DateTime fecha)
        {
            int hora = fecha.Hour;
            return (hora >= 7 && hora < 9) || (hora >= 17 && hora < 19);
        }

        /// <summary>
        /// Actualiza el estado del viaje
        /// </summary>
        public bool ActualizarEstado(Viaje viaje, ViajeEstado nuevoEstado)
        {
            if (viaje == null)
                return false;

            var transicionesValidas = new Dictionary<ViajeEstado, List<ViajeEstado>>
            {
                { ViajeEstado.Pendiente, new List<ViajeEstado> { ViajeEstado.EnCurso, ViajeEstado.Cancelado } },
                { ViajeEstado.EnCurso, new List<ViajeEstado> { ViajeEstado.Completado, ViajeEstado.Cancelado } },
                { ViajeEstado.Completado, new List<ViajeEstado>() },
                { ViajeEstado.Cancelado, new List<ViajeEstado>() }
            };

            if (transicionesValidas.ContainsKey(viaje.Estado) && 
                transicionesValidas[viaje.Estado].Contains(nuevoEstado))
            {
                viaje.Estado = nuevoEstado;
                return true;
            }

            return false;
        }
    }
}
