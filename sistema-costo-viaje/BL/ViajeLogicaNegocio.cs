using System;
using System.Collections.Generic;
using System.Linq;
using SistemaCostoViaje.DAL;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.BL
{
    public class ViajeLogicaNegocio
    {
        private readonly ViajeDAL _viajeDAL;
        private readonly ViajeValidador _validador;
        private readonly VehiculoLogicaNegocio _vehiculoBL;
        private readonly TecnicoLogicaNegocio _tecnicoBL;
        private readonly ViaticoViajeLogicaNegocio _viaticoBL;
        private readonly RendimientoVehiculoLogicaNegocio _rendimientoBL;

        public ViajeLogicaNegocio()
        {
            _viajeDAL = new ViajeDAL();
            _validador = new ViajeValidador();
            _vehiculoBL = new VehiculoLogicaNegocio();
            _tecnicoBL = new TecnicoLogicaNegocio();
            _viaticoBL = new ViaticoViajeLogicaNegocio();
            _rendimientoBL = new RendimientoVehiculoLogicaNegocio();
        }

        public List<Viaje> ObtenerTodos() => _viajeDAL.ObtenerTodos();

        public Viaje? ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));
            return _viajeDAL.ObtenerPorId(id);
        }

        public Viaje Crear(Viaje viaje)
        {
            if (viaje == null)
                throw new ArgumentNullException(nameof(viaje));

            if (!_validador.Validar(viaje))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del viaje inválidos: {errores}");
            }

            viaje.CostoBase = CalcularCostoViaje(viaje);
            viaje.Estado = ViajeEstado.Pendiente;

            return _viajeDAL.Crear(viaje);
        }

        public Viaje Actualizar(Viaje viaje)
        {
            if (viaje == null)
                throw new ArgumentNullException(nameof(viaje));

            if (viaje.Id <= 0)
                throw new ArgumentException("El ID del viaje es inválido", nameof(viaje.Id));

            if (!_validador.Validar(viaje))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del viaje inválidos: {errores}");
            }

            var actualizado = _viajeDAL.Actualizar(viaje);
            if (actualizado == null)
                throw new InvalidOperationException("No se encontró el viaje para actualizar");

            return actualizado;
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));
            return _viajeDAL.Eliminar(id);
        }

        public (bool Exitoso, string Mensaje, decimal CostoFinal) CrearViaje(Viaje viaje)
        {
            try
            {
                var creado = Crear(viaje);
                return (true, "Viaje creado exitosamente", creado.CostoBase);
            }
            catch (Exception ex)
            {
                return (false, $"Error al crear el viaje: {ex.Message}", 0);
            }
        }

        // Costo Total Viaje = Costo Vehículo + Costo Tiempo Técnico + Viáticos
        //                    + Peajes + Ferry + Hospedaje + Insumos
        private decimal CalcularCostoViaje(Viaje viaje)
        {
            // 1. Costo del Vehículo (Desgaste)
            decimal costoVehiculo = 0;
            var rendimientos = _rendimientoBL.ObtenerPorVehiculoId(viaje.VehiculoId);
            var rendimiento = rendimientos.FirstOrDefault();
            if (rendimiento != null)
            {
                costoVehiculo = _vehiculoBL.CalcularCostoVehiculoTotal(
                    viaje.VehiculoId,
                    rendimiento.tipo_combustible_id,
                    rendimiento.tipo_entorno,
                    viaje.DistanciaKm);
            }

            // 2. Costo Tiempo Técnico
            decimal costoTecnico = 0;
            var tecnico = _tecnicoBL.ObtenerPorId(viaje.TecnicoId);
            if (tecnico != null)
            {
                costoTecnico = _tecnicoBL.CalcularCostoTiempoTecnico(
                    tecnico, viaje.HorasOrdinarias, viaje.HorasExtra);
            }

            // 3. Viáticos (suma de alimentos)
            var viaticos = _viaticoBL.ObtenerPorViajeId(viaje.Id);
            decimal totalViaticos = viaticos.Sum(v => v.Monto);

            // 4. Peajes, Ferry, Hospedaje, Insumos
            decimal total = costoVehiculo + costoTecnico + totalViaticos +
                           viaje.CostoFerry + viaje.CostoHospedaje + viaje.CostoInsumos;

            return Math.Round(total, 2);
        }

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