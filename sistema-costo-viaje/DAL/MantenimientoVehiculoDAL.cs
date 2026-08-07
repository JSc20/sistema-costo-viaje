using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class MantenimientoVehiculoDAL
    {
        private const string Columnas =
            "Id, VehiculoId, Descripcion, CostoTotal, KmIntervalo, CostoPorKm";

        public List<MantenimientoVehiculo> ObtenerTodos()
        {
            var mantenimientos = new List<MantenimientoVehiculo>();
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM MantenimientoVehiculos ORDER BY Id");
            using var lector = comando.ExecuteReader();
            while (lector.Read())
                mantenimientos.Add(Mapear(lector));
            return mantenimientos;
        }

        public MantenimientoVehiculo? ObtenerPorId(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM MantenimientoVehiculos WHERE Id = $id");
            comando.Parameters.AddWithValue("$id", id);
            using var lector = comando.ExecuteReader();
            return lector.Read() ? Mapear(lector) : null;
        }

        public List<MantenimientoVehiculo> ObtenerPorVehiculoId(int vehiculoId)
        {
            var mantenimientos = new List<MantenimientoVehiculo>();
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM MantenimientoVehiculos WHERE VehiculoId = $vehiculoId ORDER BY Id");
            comando.Parameters.AddWithValue("$vehiculoId", vehiculoId);
            using var lector = comando.ExecuteReader();
            while (lector.Read())
                mantenimientos.Add(Mapear(lector));
            return mantenimientos;
        }

        public MantenimientoVehiculo Crear(MantenimientoVehiculo mantenimiento)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                INSERT INTO MantenimientoVehiculos (VehiculoId, Descripcion, CostoTotal, KmIntervalo, CostoPorKm)
                VALUES ($vehiculoId, $descripcion, $costoTotal, $kmIntervalo, $costoPorKm)
                """);
            AgregarParametros(comando, mantenimiento);
            comando.ExecuteNonQuery();

            mantenimiento.Id = ObtenerUltimoId(conexion);
            return Clonar(mantenimiento);
        }

        public MantenimientoVehiculo? Actualizar(MantenimientoVehiculo mantenimiento)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                UPDATE MantenimientoVehiculos
                SET VehiculoId = $vehiculoId, Descripcion = $descripcion, CostoTotal = $costoTotal,
                    KmIntervalo = $kmIntervalo, CostoPorKm = $costoPorKm
                WHERE Id = $id
                """);
            AgregarParametros(comando, mantenimiento);
            comando.Parameters.AddWithValue("$id", mantenimiento.Id);

            return comando.ExecuteNonQuery() > 0 ? Clonar(mantenimiento) : null;
        }

        public bool Eliminar(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, "DELETE FROM MantenimientoVehiculos WHERE Id = $id");
            comando.Parameters.AddWithValue("$id", id);
            return comando.ExecuteNonQuery() > 0;
        }

        private static int ObtenerUltimoId(SqliteConnection conexion)
        {
            using var comando = SqliteContext.CrearComando(conexion, "SELECT last_insert_rowid()");
            return Convert.ToInt32(comando.ExecuteScalar());
        }

        private static void AgregarParametros(SqliteCommand comando, MantenimientoVehiculo mantenimiento)
        {
            comando.Parameters.AddWithValue("$vehiculoId", mantenimiento.VehiculoId);
            comando.Parameters.AddWithValue("$descripcion", mantenimiento.Descripcion);
            comando.Parameters.AddWithValue("$costoTotal", mantenimiento.CostoTotal);
            comando.Parameters.AddWithValue("$kmIntervalo", mantenimiento.KmIntervalo);
            comando.Parameters.AddWithValue("$costoPorKm", mantenimiento.CostoPorKm);
        }

        private static MantenimientoVehiculo Mapear(SqliteDataReader lector)
        {
            return new MantenimientoVehiculo
            {
                Id = lector.GetInt32(0),
                VehiculoId = lector.GetInt32(1),
                Descripcion = lector.GetString(2),
                CostoTotal = lector.GetDecimal(3),
                KmIntervalo = lector.GetInt32(4),
                CostoPorKm = lector.GetDecimal(5)
            };
        }

        private static MantenimientoVehiculo Clonar(MantenimientoVehiculo mantenimiento)
        {
            return new MantenimientoVehiculo
            {
                Id = mantenimiento.Id,
                VehiculoId = mantenimiento.VehiculoId,
                Descripcion = mantenimiento.Descripcion,
                CostoTotal = mantenimiento.CostoTotal,
                KmIntervalo = mantenimiento.KmIntervalo,
                CostoPorKm = mantenimiento.CostoPorKm
            };
        }
    }
}
