# Logic Layer (LL) Implementation Plan

## Overview
Implement the business logic calculations from the financial formulas document in the respective BL classes, each in its own branch.

---

## Step 1: Entity Updates (`logic/entities` branch)

### Branch: `logic/entities` (from `ViaticoViaje` HEAD)

### 1.1 `EL/vehiculo.cs` — Add missing fields

```csharp
using System;
namespace SistemaCostoViaje.EL;
public class Vehiculo
{
    public int Id { get; set; }
    public required string Marca { get; set; }
    public required string Modelo { get; set; }
    public int Año { get; set; }
    public decimal CostoPorKm { get; set; }
    public decimal ValorActual { get; set; }       // ← NEW
    public decimal ValorFuturo { get; set; }        // ← NEW
    public int KmRestantesUso { get; set; }         // ← NEW (km restantes de uso)
    public int KmAnuales { get; set; }              // ← NEW (km recorridos al año)
    public decimal CostosFijosAnuales { get; set; } // ← NEW (seguros + gps + marchamo + dekra)
}
```

### 1.2 `EL/Viaje.cs` — Add missing fields

```csharp
using System;

namespace SistemaCostoViaje.EL
{
    public class Viaje
    {
        public int Id { get; set; }
        public required string Origen { get; set; }
        public required string Destino { get; set; }
        public decimal DistanciaKm { get; set; }
        public decimal CostoBase { get; set; }
        public DateTime FechaViaje { get; set; }
        public int IdConductor { get; set; }
        public ViajeEstado Estado { get; set; }
        public int VehiculoId { get; set; }          // ← NEW (FK)
        public int TecnicoId { get; set; }            // ← NEW (FK)
        public decimal HorasOrdinarias { get; set; }  // ← NEW
        public decimal HorasExtra { get; set; }       // ← NEW
        public decimal CostoFerry { get; set; }       // ← NEW
        public decimal CostoHospedaje { get; set; }   // ← NEW
        public decimal CostoInsumos { get; set; }     // ← NEW
    }
}
```

### 1.3 Update DAL Clone methods if needed

The DAL files use manual property copying. New fields must be included in the `Clone` and `Actualizar` methods.

**`VehiculoDAL.cs`** — Update Clone + Actualizar to include new fields:
- In `Clone()`: add `ValorActual`, `ValorFuturo`, `KmRestantesUso`, `KmAnuales`, `CostosFijosAnuales`
- In `Actualizar()`: same fields

**`ViajeDAL.cs`** — Update Clone + Actualizar:
- Add `VehiculoId`, `TecnicoId`, `HorasOrdinarias`, `HorasExtra`, `CostoFerry`, `CostoHospedaje`, `CostoInsumos`

### Commands:
```bash
git add -A
git commit -m "feat(entities): Add missing fields for cost calculations (depreciation, fixed costs, trip details)"
git push origin logic/entities
git checkout main
git merge logic/entities
git push origin main
```

---

## Step 2: Tecnico Logic (`Tecnico` branch)

### Branch: `Tecnico`

### 2.1 `BL/TecnicoLogicaNegocio.cs`

Fix the `CalcularCostoHoraOrdinaria` and `CalcularCostoHoraExtra` methods:

Changes:
1. Update `semanasMes` from `4` to `4.3333m` (average weeks per month)
2. Add method `CalcularCostoHoraOrdinaria(Tecnico tecnico)` that uses entity properties
3. Add method `CalcularCostoHoraExtra(Tecnico tecnico)` that chains from ordinaria
4. Update `Crear` and `Actualizar` to auto-calculate `costo_hora_ordinaria` and `costo_hora_extra`

```csharp
using SistemaCostoViaje.DAL;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.BL
{
    public class TecnicoLogicaNegocio
    {
        private readonly TecnicoDAL _tecnicoDAL;
        private readonly TecnicoValidador _validador;
        private const decimal SEMANAS_PROMEDIO_MES = 4.3333m;

        public TecnicoLogicaNegocio()
        {
            _tecnicoDAL = new TecnicoDAL();
            _validador = new TecnicoValidador();
        }

        public List<Tecnico> ObtenerTodos() => _tecnicoDAL.ObtenerTodos();

        public Tecnico? ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));
            return _tecnicoDAL.ObtenerPorId(id);
        }

        public Tecnico Crear(Tecnico tecnico)
        {
            if (tecnico == null)
                throw new ArgumentNullException(nameof(tecnico));

            if (!_validador.Validar(tecnico))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del técnico inválidos: {errores}");
            }

            tecnico.costo_hora_ordinaria = CalcularCostoHoraOrdinaria(tecnico.salario_mensual, tecnico.horas_semanales);
            tecnico.costo_hora_extra = CalcularCostoHoraExtra(tecnico.costo_hora_ordinaria);

            return _tecnicoDAL.Crear(tecnico);
        }

        public Tecnico Actualizar(Tecnico tecnico)
        {
            if (tecnico == null)
                throw new ArgumentNullException(nameof(tecnico));

            if (tecnico.id <= 0)
                throw new ArgumentException("El ID del técnico es inválido", nameof(tecnico.id));

            if (!_validador.Validar(tecnico))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del técnico inválidos: {errores}");
            }

            tecnico.costo_hora_ordinaria = CalcularCostoHoraOrdinaria(tecnico.salario_mensual, tecnico.horas_semanales);
            tecnico.costo_hora_extra = CalcularCostoHoraExtra(tecnico.costo_hora_ordinaria);

            var actualizado = _tecnicoDAL.Actualizar(tecnico);
            if (actualizado == null)
                throw new InvalidOperationException("No se encontró el técnico para actualizar");

            return actualizado;
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));
            return _tecnicoDAL.Eliminar(id);
        }

        // Costo Hora Ordinaria = Salario Mensual / (Horas Semanales × 4.3333)
        public decimal CalcularCostoHoraOrdinaria(decimal salarioMensual, int horasSemanales)
        {
            if (salarioMensual < 0)
                throw new ArgumentException("El salario mensual no puede ser negativo", nameof(salarioMensual));

            if (horasSemanales <= 0 || horasSemanales > 168)
                throw new ArgumentException("Las horas semanales no son válidas", nameof(horasSemanales));

            decimal totalHorasMes = Math.Round(horasSemanales * SEMANAS_PROMEDIO_MES, 2);
            return Math.Round(salarioMensual / totalHorasMes, 2);
        }

        // Costo Hora Extra = Costo Hora Ordinaria × 1.5
        public decimal CalcularCostoHoraExtra(decimal costoHoraOrdinaria, decimal factorRecargo = 1.5m)
        {
            if (costoHoraOrdinaria < 0)
                throw new ArgumentException("El costo de hora ordinaria no puede ser negativo", nameof(costoHoraOrdinaria));

            if (factorRecargo <= 1)
                throw new ArgumentException("El factor de recargo debe ser mayor a 1", nameof(factorRecargo));

            return Math.Round(costoHoraOrdinaria * factorRecargo, 2);
        }

        // Calcula el costo de tiempo técnico para un viaje
        public decimal CalcularCostoTiempoTecnico(Tecnico tecnico, decimal horasOrdinarias, decimal horasExtra)
        {
            decimal costoOrdinario = horasOrdinarias * tecnico.costo_hora_ordinaria;
            decimal costoExtra = horasExtra * tecnico.costo_hora_extra;
            return Math.Round(costoOrdinario + costoExtra, 2);
        }
    }
}
```

### Commands:
```bash
git checkout -b Tecnico
# Apply changes...
git add -A
git commit -m "feat(Tecnico): Fix formula to use 4.3333 weeks/month, add CalcularCostoTiempoTecnico"
git push origin Tecnico
```

---

## Step 3: RendimientoVehiculo Logic (`RendimientoVehiculo` branch)

### Branch: `RendimientoVehiculo`

### 3.1 `BL/RendimientoVehiculoLogicaNegocio.cs`

Add method to calculate `costo_por_km` based on `TipoCombustible.CostoPorLitro` and `km_por_litro`:

```csharp
using SistemaCostoViaje.DAL;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.BL
{
    public class RendimientoVehiculoLogicaNegocio
    {
        private readonly RendimientoVehiculoDAL _rendimientoDAL;
        private readonly TipoCombustibleDAL _tipoCombustibleDAL;
        private readonly RendimientoVehiculoValidador _validador;

        public RendimientoVehiculoLogicaNegocio()
        {
            _rendimientoDAL = new RendimientoVehiculoDAL();
            _tipoCombustibleDAL = new TipoCombustibleDAL();
            _validador = new RendimientoVehiculoValidador();
        }

        public List<RendimientoVehiculo> ObtenerTodos() => _rendimientoDAL.ObtenerTodos();

        public RendimientoVehiculo? ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));
            return _rendimientoDAL.ObtenerPorId(id);
        }

        public List<RendimientoVehiculo> ObtenerPorVehiculoId(int vehiculoId)
        {
            if (vehiculoId <= 0)
                throw new ArgumentException("El ID del vehículo debe ser mayor que cero", nameof(vehiculoId));
            return _rendimientoDAL.ObtenerPorVehiculoId(vehiculoId);
        }

        public RendimientoVehiculo Crear(RendimientoVehiculo rendimiento)
        {
            if (rendimiento == null)
                throw new ArgumentNullException(nameof(rendimiento));

            if (!_validador.Validar(rendimiento))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del rendimiento de vehículo inválidos: {errores}");
            }

            var combustible = _tipoCombustibleDAL.ObtenerPorId(rendimiento.tipo_combustible_id);
            if (combustible == null)
                throw new InvalidOperationException("El tipo de combustible especificado no existe");

            rendimiento.costo_por_km = CalcularCostoPorKm(combustible.CostoPorLitro, rendimiento.km_por_litro);

            return _rendimientoDAL.Crear(rendimiento);
        }

        public RendimientoVehiculo Actualizar(RendimientoVehiculo rendimiento)
        {
            if (rendimiento == null)
                throw new ArgumentNullException(nameof(rendimiento));

            if (rendimiento.id <= 0)
                throw new ArgumentException("El ID del rendimiento es inválido", nameof(rendimiento.id));

            if (!_validador.Validar(rendimiento))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos del rendimiento de vehículo inválidos: {errores}");
            }

            var combustible = _tipoCombustibleDAL.ObtenerPorId(rendimiento.tipo_combustible_id);
            if (combustible == null)
                throw new InvalidOperationException("El tipo de combustible especificado no existe");

            rendimiento.costo_por_km = CalcularCostoPorKm(combustible.CostoPorLitro, rendimiento.km_por_litro);

            var actualizado = _rendimientoDAL.Actualizar(rendimiento);
            if (actualizado == null)
                throw new InvalidOperationException("No se encontró el rendimiento de vehículo para actualizar");

            return actualizado;
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));
            return _rendimientoDAL.Eliminar(id);
        }

        // Combustible por Km = Precio por Litro / Rendimiento (Km/L)
        public decimal CalcularCostoPorKm(decimal precioPorLitro, decimal kmPorLitro)
        {
            if (precioPorLitro < 0)
                throw new ArgumentException("El precio por litro no puede ser negativo", nameof(precioPorLitro));

            if (kmPorLitro <= 0)
                throw new ArgumentException("El rendimiento (km/L) debe ser mayor que cero", nameof(kmPorLitro));

            return Math.Round(precioPorLitro / kmPorLitro, 2);
        }
    }
}
```

### Commands:
```bash
git checkout -b RendimientoVehiculo
# Apply changes...
git add -A
git commit -m "feat(RendimientoVehiculo): Add CalcularCostoPorKm using TipoCombustible precio"
git push origin RendimientoVehiculo
```

---

## Step 4: MantenimientoVehiculo Logic (`MantenimientoVehiculo` branch)

### Branch: `MantenimientoVehiculo`

### 4.1 `BL/MantenimientoVehiculoLogicaNegocio.cs`

Add calculation for `CostoPorKm = CostoTotal / KmIntervalo`:

```csharp
using SistemaCostoViaje.DAL;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.BL
{
    public class MantenimientoVehiculoLogicaNegocio
    {
        private readonly MantenimientoVehiculoDAL _mantenimientoDAL;
        private readonly MantenimientoVehiculoValidador _validador;

        public MantenimientoVehiculoLogicaNegocio()
        {
            _mantenimientoDAL = new MantenimientoVehiculoDAL();
            _validador = new MantenimientoVehiculoValidador();
        }

        public List<MantenimientoVehiculo> ObtenerTodos() => _mantenimientoDAL.ObtenerTodos();

        public MantenimientoVehiculo? ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));
            return _mantenimientoDAL.ObtenerPorId(id);
        }

        public List<MantenimientoVehiculo> ObtenerPorVehiculoId(int vehiculoId)
        {
            if (vehiculoId <= 0)
                throw new ArgumentException("El ID del vehículo debe ser mayor que cero", nameof(vehiculoId));
            return _mantenimientoDAL.ObtenerPorVehiculoId(vehiculoId);
        }

        public MantenimientoVehiculo Crear(MantenimientoVehiculo mantenimiento)
        {
            if (mantenimiento == null)
                throw new ArgumentNullException(nameof(mantenimiento));

            if (!_validador.Validar(mantenimiento))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos de mantenimiento inválidos: {errores}");
            }

            mantenimiento.CostoPorKm = CalcularCostoPorKm(mantenimiento.CostoTotal, mantenimiento.KmIntervalo);

            return _mantenimientoDAL.Crear(mantenimiento);
        }

        public MantenimientoVehiculo Actualizar(MantenimientoVehiculo mantenimiento)
        {
            if (mantenimiento == null)
                throw new ArgumentNullException(nameof(mantenimiento));

            if (mantenimiento.Id <= 0)
                throw new ArgumentException("El ID del mantenimiento es inválido", nameof(mantenimiento.Id));

            if (!_validador.Validar(mantenimiento))
            {
                var errores = string.Join("; ", _validador.ObtenerErrores());
                throw new ArgumentException($"Datos de mantenimiento inválidos: {errores}");
            }

            mantenimiento.CostoPorKm = CalcularCostoPorKm(mantenimiento.CostoTotal, mantenimiento.KmIntervalo);

            var actualizado = _mantenimientoDAL.Actualizar(mantenimiento);
            if (actualizado == null)
                throw new InvalidOperationException("No se encontró el mantenimiento para actualizar");

            return actualizado;
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));
            return _mantenimientoDAL.Eliminar(id);
        }

        // Costo Mantenimiento por Km = Costo del Mantenimiento / Km de Intervalo
        public decimal CalcularCostoPorKm(decimal costoTotal, int kmIntervalo)
        {
            if (costoTotal < 0)
                throw new ArgumentException("El costo total no puede ser negativo", nameof(costoTotal));

            if (kmIntervalo <= 0)
                throw new ArgumentException("El km de intervalo debe ser mayor que cero", nameof(kmIntervalo));

            return Math.Round(costoTotal / kmIntervalo, 2);
        }
    }
}
```

### Commands:
```bash
git checkout -b MantenimientoVehiculo
# Apply changes...
git add -A
git commit -m "feat(MantenimientoVehiculo): Add CalcularCostoPorKm = CostoTotal / KmIntervalo"
git push origin MantenimientoVehiculo
```

---

## Step 5: Vehiculo Logic — Full Operational Cost (`Vehiculo` branch)

### Branch: `Vehiculo`

### 5.1 `BL/VehiculoLogicaNegocio.cs`

Implement `CalcularCostoOperacional` with all 4 components:

```csharp
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
            if (vehiculo.Año <= 1900 || vehiculo.Año > DateTime.Now.Year + 1)
                throw new ArgumentException("El año del vehículo no es válido", nameof(vehiculo.Año));
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
        // Cálculo del Costo Real del Vehículo por Kilómetro
        // ========================================================

        /// <summary>
        /// Calcula el costo total por km del vehículo integrando los 4 componentes:
        /// Combustible + Mantenimiento + Depreciación + Costos Fijos
        /// </summary>
        public decimal CalcularCostoRealPorKm(int vehiculoId, int tipoCombustibleId, string? tipoEntorno)
        {
            var vehiculo = _vehiculoDAL.ObtenerPorId(vehiculoId);
            if (vehiculo == null)
                throw new InvalidOperationException("Vehículo no encontrado");

            // A. Costo Combustible por Km
            var rendimientos = _rendimientoBL.ObtenerPorVehiculoId(vehiculoId);
            var rendimiento = rendimientos.FirstOrDefault(r =>
                r.tipo_combustible_id == tipoCombustibleId &&
                (tipoEntorno == null || r.tipo_entorno == tipoEntorno));
            decimal costoCombustible = rendimiento?.costo_por_km ?? 0;

            // B. Costo Mantenimiento por Km
            var mantenimientos = _mantenimientoBL.ObtenerPorVehiculoId(vehiculoId);
            decimal costoMantenimiento = mantenimientos.Sum(m => m.CostoPorKm);

            // C. Depreciación por Km = (ValorActual - ValorFuturo) / KmRestantesUso
            decimal costoDepreciacion = 0;
            if (vehiculo.KmRestantesUso > 0)
            {
                costoDepreciacion = Math.Round(
                    (vehiculo.ValorActual - vehiculo.ValorFuturo) / vehiculo.KmRestantesUso, 2);
            }

            // D. Costos Fijos por Km = Suma Costos Fijos Anuales / Km Anuales
            decimal costoFijo = 0;
            if (vehiculo.KmAnuales > 0)
            {
                costoFijo = Math.Round(vehiculo.CostosFijosAnuales / vehiculo.KmAnuales, 2);
            }

            // Costo Real Vehículo por Km = Combustible + Mantenimiento + Depreciación + Costo Fijo
            return Math.Round(costoCombustible + costoMantenimiento + costoDepreciacion + costoFijo, 2);
        }

        /// <summary>
        /// Calcula el costo total del vehículo para una distancia específica
        /// </summary>
        public decimal CalcularCostoVehiculoTotal(int vehiculoId, int tipoCombustibleId,
            string? tipoEntorno, decimal kmTotales)
        {
            decimal costoPorKm = CalcularCostoRealPorKm(vehiculoId, tipoCombustibleId, tipoEntorno);
            return Math.Round(kmTotales * costoPorKm, 2);
        }
    }
}
```

### Note to fix duplicate validation in `Crear`:
Remove the duplicate `vehiculo.Año` check from the `Crear` method (lines 32-33 in the code above).

### Commands:
```bash
git checkout -b Vehiculo
# Apply changes...
git add -A
git commit -m "feat(Vehiculo): Implement CalcularCostoOperacional with fuel + maintenance + depreciation + fixed costs"
git push origin Vehiculo
```

---

## Step 6: Viaje Logic — Total Trip Cost (`Viaje` branch)

### Branch: `Viaje`

### 6.1 `BL/ViajeLogicaNegocio.cs`

Replace the fake `PRECIO_POR_KM = 2.5` with the real integration formula:

The new `CalcularCostoViaje` should:
1. Get vehicle, technician, and per-diem data from their respective BL classes
2. Calculate using all the component costs
3. Add tolls, ferry, lodging, and supplies

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.VL;

namespace SistemaCostoViaje.BL
{
    public class ViajeLogicaNegocio
    {
        private readonly ViajeValidador _validador;
        private readonly VehiculoLogicaNegocio _vehiculoBL;
        private readonly TecnicoLogicaNegocio _tecnicoBL;
        private readonly ViaticoViajeLogicaNegocio _viaticoBL;
        private readonly RendimientoVehiculoLogicaNegocio _rendimientoBL;
        private readonly PeajeLogicaNegocio _peajeBL;

        public ViajeLogicaNegocio()
        {
            _validador = new ViajeValidador();
            _vehiculoBL = new VehiculoLogicaNegocio();
            _tecnicoBL = new TecnicoLogicaNegocio();
            _viaticoBL = new ViaticoViajeLogicaNegocio();
            _rendimientoBL = new RendimientoVehiculoLogicaNegocio();
            _peajeBL = new PeajeLogicaNegocio();
        }

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

        // Costo Total Viaje = Costo Vehículo + Costo Tiempo Técnico + Viáticos + Peajes + Ferry + Hospedaje + Insumos
        private decimal CalcularCostoViaje(Viaje viaje)
        {
            // 1. Costo del Vehículo
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
            decimal totalPeajes = 0;
            // Peajes are linked via Destino; using direct cost for now
            // (will be fully wired when Destino/Presenter is connected)

            // Suma total
            decimal total = costoVehiculo + costoTecnico + totalViaticos +
                           totalPeajes + viaje.CostoFerry + viaje.CostoHospedaje + viaje.CostoInsumos;

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
```

### Commands:
```bash
git checkout -b Viaje
# Apply changes...
git add -A
git commit -m "feat(Viaje): Replace fake pricing with real cost integration formula"
git push origin Viaje
```

---

## Step 7: ViaticoViaje Logic (`ViaticoViaje` branch)

### Branch: `ViaticoViaje`

### 7.1 `BL/ViaticoViajeLogicaNegocio.cs`

Add a summary method to calculate total per-diems per trip:

```csharp
public decimal CalcularTotalViaticosPorViaje(int viajeId)
{
    if (viajeId <= 0)
        throw new ArgumentException("El ID del viaje debe ser mayor que cero", nameof(viajeId));

    var viaticos = _viaticoDAL.ObtenerPorViajeId(viajeId);
    return Math.Round(viaticos.Sum(v => v.Monto), 2);
}
```

Add to the class (alongside existing `ObtenerPorViajeId`).

### Commands:
```bash
git checkout ViaticoViaje
# Apply changes...
git add -A
git commit -m "feat(ViaticoViaje): Add CalcularTotalViaticosPorViaje"
git push origin ViaticoViaje
```

---

## Step 8: DAL Updates (all branches)

Each DAL's `Clone` method must include new entity fields:

### `VehiculoDAL.cs` — Add to Clone:

```csharp
private static Vehiculo Clone(Vehiculo? v)
{
    if (v == null) return null!;
    return new Vehiculo
    {
        Id = v.Id,
        Marca = v.Marca,
        Modelo = v.Modelo,
        Año = v.Año,
        CostoPorKm = v.CostoPorKm,
        ValorActual = v.ValorActual,
        ValorFuturo = v.ValorFuturo,
        KmRestantesUso = v.KmRestantesUso,
        KmAnuales = v.KmAnuales,
        CostosFijosAnuales = v.CostosFijosAnuales,
    };
}
```

### `ViajeDAL.cs` — Add to Clone:

```csharp
private static Viaje Clone(Viaje? v)
{
    if (v == null) return null!;
    return new Viaje
    {
        Id = v.Id,
        Origen = v.Origen,
        Destino = v.Destino,
        DistanciaKm = v.DistanciaKm,
        CostoBase = v.CostoBase,
        FechaViaje = v.FechaViaje,
        IdConductor = v.IdConductor,
        Estado = v.Estado,
        VehiculoId = v.VehiculoId,
        TecnicoId = v.TecnicoId,
        HorasOrdinarias = v.HorasOrdinarias,
        HorasExtra = v.HorasExtra,
        CostoFerry = v.CostoFerry,
        CostoHospedaje = v.CostoHospedaje,
        CostoInsumos = v.CostoInsumos,
    };
}
```

### `ViajeDAL.cs` — Update Actualizar:

```csharp
public Viaje? Actualizar(Viaje viaje)
{
    var index = _coleccion.FindIndex(v => v.Id == viaje.Id);
    if (index < 0) return null;
    _coleccion[index].CostoBase = viaje.CostoBase;
    _coleccion[index].Estado = viaje.Estado;
    _coleccion[index].Origen = viaje.Origen;
    _coleccion[index].Destino = viaje.Destino;
    _coleccion[index].DistanciaKm = viaje.DistanciaKm;
    _coleccion[index].FechaViaje = viaje.FechaViaje;
    _coleccion[index].IdConductor = viaje.IdConductor;
    _coleccion[index].VehiculoId = viaje.VehiculoId;
    _coleccion[index].TecnicoId = viaje.TecnicoId;
    _coleccion[index].HorasOrdinarias = viaje.HorasOrdinarias;
    _coleccion[index].HorasExtra = viaje.HorasExtra;
    _coleccion[index].CostoFerry = viaje.CostoFerry;
    _coleccion[index].CostoHospedaje = viaje.CostoHospedaje;
    _coleccion[index].CostoInsumos = viaje.CostoInsumos;
    return Clone(_coleccion[index]);
}
```

---

## Execution Order

```
logic/entities (entity updates)
  → merged to main
    → Tecnico (Tecnico BL)
    → RendimientoVehiculo (Rendimiento BL)
    → MantenimientoVehiculo (Mantenimiento BL)
    → Vehiculo (Vehiculo BL + depends on Rendimiento + Mantenimiento)
    → Viaje (Viaje BL + depends on Vehiculo + Tecnico + Viatico)
    → ViaticoViaje (Viatico BL)
```

### Push all branches:
```bash
git push origin logic/entities
git push origin main
git push origin Tecnico
git push origin RendimientoVehiculo
git push origin MantenimientoVehiculo
git push origin Vehiculo
git push origin Viaje
git push origin ViaticoViaje
```

---

## Verification

After all changes, run:
```bash
dotnet build
```

This verifies all code compiles correctly.
