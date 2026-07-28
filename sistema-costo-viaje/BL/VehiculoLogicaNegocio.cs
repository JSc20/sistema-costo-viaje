using System;
using System.Collections.Generic;
using SistemaCostoViaje.DAL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.BL
{
    /// <summary>
    /// Clase de lógica de negocio para Vehículos
    /// </summary>
    public class VehiculoLogicaNegocio
    {
        private readonly VehiculoDAL _vehiculoDAL;

        public VehiculoLogicaNegocio()
        {
            _vehiculoDAL = new VehiculoDAL();
        }

        /// <summary>
        /// Obtiene todos los vehículos
        /// </summary>
        /// <returns>Lista de vehículos</returns>
        public List<Vehiculo> ObtenerTodos()
        {
            return _vehiculoDAL.ObtenerTodos();
        }

        /// <summary>
        /// Obtiene un vehículo por ID
        /// </summary>
        /// <param name="id">ID del vehículo</param>
        /// <returns>Vehículo encontrado</returns>
        public Vehiculo? ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            return _vehiculoDAL.ObtenerPorId(id);
        }

        /// <summary>
        /// Crea un nuevo vehículo
        /// </summary>
        /// <param name="vehiculo">Datos del vehículo a crear</param>
        /// <returns>Vehículo creado</returns>
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

        /// <summary>
        /// Actualiza un vehículo existente
        /// </summary>
        /// <param name="vehiculo">Datos del vehículo a actualizar</param>
        /// <returns>Vehículo actualizado</returns>
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

            if (vehiculo.CostoPorKm <= 0)
                throw new ArgumentException("El costo por kilómetro debe ser mayor que cero", nameof(vehiculo.CostoPorKm));

            var actualizado = _vehiculoDAL.Actualizar(vehiculo);
            if (actualizado == null)
                throw new InvalidOperationException("No se encontró el vehículo para actualizar");

            return actualizado;
        }

        /// <summary>
        /// Elimina un vehículo
        /// </summary>
        /// <param name="id">ID del vehículo a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero", nameof(id));

            return _vehiculoDAL.Eliminar(id);
        }

        /// <summary>
        /// Calcula el costo operacional del vehículo
        /// </summary>
        /// <param name="vehiculoId">ID del vehículo</param>
        /// <returns>Costo operacional</returns>
        public decimal CalcularCostoOperacional(int vehiculoId)
        {
            // TODO: Sugerencia - Obtener datos del vehículo
            // TODO: Sugerencia - Calcular consumo de combustible
            // TODO: Sugerencia - Incluir mantenimiento y depreciación
            // TODO: Sugerencia - Implementar lógica de cálculo
            throw new NotImplementedException();
        }
    }
}
