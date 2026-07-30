using SistemaCostoViaje.DAL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.BL
{
    public class VehiculoLogicaNegocio
    {
        private readonly VehiculoDAL _vehiculoDAL;
        private readonly RendimientoVehiculoLogicaNegocio _rendimientoBL;
        private readonly MantenimientoVehiculoLogicaNegocio _mantenimientoBL;

        public VehiculoLogicaNegocio()
        {
            _vehiculoDAL = new VehiculoDAL();
            _rendimientoBL = new RendimientoVehiculoLogicaNegocio();
            _mantenimientoBL = new MantenimientoVehiculoLogicaNegocio();
        }

        public List<Vehiculo> ObtenerTodos() => _vehiculoDAL.ObtenerTodos();

        public Vehiculo? ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));
            return _vehiculoDAL.ObtenerPorId(id);
        }

        public Vehiculo Crear(Vehiculo vehiculo)
        {
            if (vehiculo == null)
                throw new ArgumentNullException(nameof(vehiculo));

            if (string.IsNullOrWhiteSpace(vehiculo.Marca))
                throw new ArgumentException("La marca es requerida", nameof(vehiculo.Marca));

            if (string.IsNullOrWhiteSpace(vehiculo.Modelo))
                throw new ArgumentException("El modelo es requerido", nameof(vehiculo.Modelo));

            if (vehiculo.Año <= 1900 || vehiculo.Año > DateTime.Now.Year + 1)
                throw new ArgumentException("El año del vehículo no es válido", nameof(vehiculo.Año));

            if (vehiculo.CostoPorKm <= 0)
                throw new ArgumentException("El costo por kilómetro debe ser mayor que cero", nameof(vehiculo.CostoPorKm));

            return _vehiculoDAL.Crear(vehiculo);
        }

        public Vehiculo Actualizar(Vehiculo vehiculo)
        {
            if (vehiculo == null)
                throw new ArgumentNullException(nameof(vehiculo));

            if (vehiculo.Id <= 0)
                throw new ArgumentException("El ID del vehículo es inválido", nameof(vehiculo.Id));

            if (string.IsNullOrWhiteSpace(vehiculo.Marca))
                throw new ArgumentException("La marca es requerida", nameof(vehiculo.Marca));

            if (string.IsNullOrWhiteSpace(vehiculo.Modelo))
                throw new ArgumentException("El modelo es requerido", nameof(vehiculo.Modelo));

            if (vehiculo.Año <= 1900 || vehiculo.Año > DateTime.Now.Year + 1)
                throw new ArgumentException("El año del vehículo no es válido", nameof(vehiculo.Año));

            if (vehiculo.CostoPorKm <= 0)
                throw new ArgumentException("El costo por kilómetro debe ser mayor que cero", nameof(vehiculo.CostoPorKm));

            var actualizado = _vehiculoDAL.Actualizar(vehiculo);
            if (actualizado == null)
                throw new InvalidOperationException("No se encontró el vehículo para actualizar");

            return actualizado;
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));
            return _vehiculoDAL.Eliminar(id);
        }

        // ========================================================
        // Costo Real del Vehículo por Kilómetro
        // ========================================================

        // Costo Real por Km = Combustible + Mantenimiento + Depreciación + Costos Fijos
        public decimal CalcularCostoRealPorKm(int vehiculoId, int tipoCombustibleId, string? tipoEntorno)
        {
            var vehiculo = _vehiculoDAL.ObtenerPorId(vehiculoId);
            if (vehiculo == null)
                throw new InvalidOperationException("Vehículo no encontrado");

            // A. Combustible por Km = Precio por Litro / Rendimiento (Km/L)
            var rendimientos = _rendimientoBL.ObtenerPorVehiculoId(vehiculoId);
            var rendimiento = rendimientos.FirstOrDefault(r =>
                r.tipo_combustible_id == tipoCombustibleId &&
                (tipoEntorno == null || r.tipo_entorno == tipoEntorno));
            decimal costoCombustible = rendimiento?.costo_por_km ?? 0;

            // B. Mantenimiento por Km = Suma de (Costo / Intervalo)
            var mantenimientos = _mantenimientoBL.ObtenerPorVehiculoId(vehiculoId);
            decimal costoMantenimiento = mantenimientos.Sum(m => m.CostoPorKm);

            // C. Depreciación por Km = (ValorActual - ValorFuturo) / KmRestantesUso
            decimal costoDepreciacion = 0;
            if (vehiculo.KmRestantesUso > 0)
            {
                costoDepreciacion = Math.Round(
                    (vehiculo.ValorActual - vehiculo.ValorFuturo) / vehiculo.KmRestantesUso, 2);
            }

            // D. Costos Fijos por Km = CostosFijosAnuales / KmAnuales
            decimal costoFijo = 0;
            if (vehiculo.KmAnuales > 0)
            {
                costoFijo = Math.Round(vehiculo.CostosFijosAnuales / vehiculo.KmAnuales, 2);
            }

            return Math.Round(costoCombustible + costoMantenimiento + costoDepreciacion + costoFijo, 2);
        }

        // Costo Vehículo Total = Km Totales * Costo Real por Km
        public decimal CalcularCostoVehiculoTotal(int vehiculoId, int tipoCombustibleId,
            string? tipoEntorno, decimal kmTotales)
        {
            decimal costoPorKm = CalcularCostoRealPorKm(vehiculoId, tipoCombustibleId, tipoEntorno);
            return Math.Round(kmTotales * costoPorKm, 2);
        }

        // Mantener compatibilidad con código existente
        public decimal CalcularCostoOperacional(int vehiculoId)
        {
            return CalcularCostoRealPorKm(vehiculoId, 1, null);
        }
    }
}
