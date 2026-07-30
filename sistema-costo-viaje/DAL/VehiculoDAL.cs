using System.Collections.Generic;
using System.Linq;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class VehiculoDAL
    {
        private static readonly List<Vehiculo> _vehiculos = new()
        {
            new Vehiculo { Id = 1, Marca = "Toyota", Modelo = "Corolla", Año = 2020, CostoPorKm = 0.80m, ValorActual = 8000000, ValorFuturo = 3000000, KmRestantesUso = 100000, KmAnuales = 15000, CostosFijosAnuales = 400000 },
            new Vehiculo { Id = 2, Marca = "Ford", Modelo = "Ranger", Año = 2019, CostoPorKm = 1.10m, ValorActual = 12000000, ValorFuturo = 5000000, KmRestantesUso = 120000, KmAnuales = 20000, CostosFijosAnuales = 500000 },
            new Vehiculo { Id = 3, Marca = "Chevrolet", Modelo = "Spark", Año = 2022, CostoPorKm = 0.70m, ValorActual = 6000000, ValorFuturo = 2000000, KmRestantesUso = 90000, KmAnuales = 12000, CostosFijosAnuales = 350000 }
        };

        private static int _nextId = _vehiculos.Max(v => v.Id) + 1;

        public List<Vehiculo> ObtenerTodos()
        {
            return _vehiculos.Select(Clone).ToList();
        }

        public Vehiculo? ObtenerPorId(int id)
        {
            return Clone(_vehiculos.FirstOrDefault(v => v.Id == id));
        }

        public Vehiculo Crear(Vehiculo vehiculo)
        {
            var nuevoVehiculo = Clone(vehiculo);
            nuevoVehiculo.Id = _nextId++;
            _vehiculos.Add(nuevoVehiculo);
            return Clone(nuevoVehiculo);
        }

        public Vehiculo? Actualizar(Vehiculo vehiculo)
        {
            var existente = _vehiculos.FirstOrDefault(v => v.Id == vehiculo.Id);
            if (existente == null)
                return null;

            existente.Marca = vehiculo.Marca;
            existente.Modelo = vehiculo.Modelo;
            existente.Año = vehiculo.Año;
            existente.CostoPorKm = vehiculo.CostoPorKm;
            existente.ValorActual = vehiculo.ValorActual;
            existente.ValorFuturo = vehiculo.ValorFuturo;
            existente.KmRestantesUso = vehiculo.KmRestantesUso;
            existente.KmAnuales = vehiculo.KmAnuales;
            existente.CostosFijosAnuales = vehiculo.CostosFijosAnuales;

            return Clone(existente);
        }

        public bool Eliminar(int id)
        {
            var vehiculo = _vehiculos.FirstOrDefault(v => v.Id == id);
            if (vehiculo == null)
                return false;

            return _vehiculos.Remove(vehiculo);
        }

        private static Vehiculo Clone(Vehiculo? vehiculo)
        {
            if (vehiculo == null)
                return null!;

            return new Vehiculo
            {
                Id = vehiculo.Id,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Año = vehiculo.Año,
                CostoPorKm = vehiculo.CostoPorKm,
                ValorActual = vehiculo.ValorActual,
                ValorFuturo = vehiculo.ValorFuturo,
                KmRestantesUso = vehiculo.KmRestantesUso,
                KmAnuales = vehiculo.KmAnuales,
                CostosFijosAnuales = vehiculo.CostosFijosAnuales
            };
        }
    }
}
