using System;
using System.Collections.Generic;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.BL
{
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