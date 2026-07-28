using System.Collections.Generic;
using System.Linq;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class VehiculoDAL
    {
        private static readonly List<Vehiculo> _vehiculos = new()
        {
            new Vehiculo { Id = 1, Marca = "Toyota", Modelo = "Corolla", Año = 2020, CostoPorKm = 0.80m },
            new Vehiculo { Id = 2, Marca = "Ford", Modelo = "Ranger", Año = 2019, CostoPorKm = 1.10m },
            new Vehiculo { Id = 3, Marca = "Chevrolet", Modelo = "Spark", Año = 2022, CostoPorKm = 0.70m }
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
                CostoPorKm = vehiculo.CostoPorKm
            };
        }
    }
}
