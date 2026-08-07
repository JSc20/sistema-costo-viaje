using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class RendimientoVehiculoDAL
    {
        private const string Columnas =
            "id, vehiculo_id, tipo_combustible_id, tipo_entorno, km_por_litro, costo_por_km";

        public List<RendimientoVehiculo> ObtenerTodos()
        {
            var rendimientos = new List<RendimientoVehiculo>();
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM RendimientoVehiculos ORDER BY id");
            using var lector = comando.ExecuteReader();
            while (lector.Read())
                rendimientos.Add(Mapear(lector));
            return rendimientos;
        }

        public RendimientoVehiculo? ObtenerPorId(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM RendimientoVehiculos WHERE id = $id");
            comando.Parameters.AddWithValue("$id", id);
            using var lector = comando.ExecuteReader();
            return lector.Read() ? Mapear(lector) : null;
        }

        public List<RendimientoVehiculo> ObtenerPorVehiculoId(int vehiculoId)
        {
            var rendimientos = new List<RendimientoVehiculo>();
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM RendimientoVehiculos WHERE vehiculo_id = $vehiculoId ORDER BY id");
            comando.Parameters.AddWithValue("$vehiculoId", vehiculoId);
            using var lector = comando.ExecuteReader();
            while (lector.Read())
                rendimientos.Add(Mapear(lector));
            return rendimientos;
        }

        public RendimientoVehiculo Crear(RendimientoVehiculo rendimiento)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                INSERT INTO RendimientoVehiculos (vehiculo_id, tipo_combustible_id, tipo_entorno, km_por_litro, costo_por_km)
                VALUES ($vehiculoId, $tipoCombustibleId, $tipoEntorno, $kmPorLitro, $costoPorKm)
                """);
            AgregarParametros(comando, rendimiento);
            comando.ExecuteNonQuery();

            rendimiento.id = ObtenerUltimoId(conexion);
            return Clonar(rendimiento);
        }

        public RendimientoVehiculo? Actualizar(RendimientoVehiculo rendimiento)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                UPDATE RendimientoVehiculos
                SET vehiculo_id = $vehiculoId, tipo_combustible_id = $tipoCombustibleId, tipo_entorno = $tipoEntorno,
                    km_por_litro = $kmPorLitro, costo_por_km = $costoPorKm
                WHERE id = $id
                """);
            AgregarParametros(comando, rendimiento);
            comando.Parameters.AddWithValue("$id", rendimiento.id);

            return comando.ExecuteNonQuery() > 0 ? Clonar(rendimiento) : null;
        }

        public bool Eliminar(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, "DELETE FROM RendimientoVehiculos WHERE id = $id");
            comando.Parameters.AddWithValue("$id", id);
            return comando.ExecuteNonQuery() > 0;
        }

        private static int ObtenerUltimoId(SqliteConnection conexion)
        {
            using var comando = SqliteContext.CrearComando(conexion, "SELECT last_insert_rowid()");
            return Convert.ToInt32(comando.ExecuteScalar());
        }

        private static void AgregarParametros(SqliteCommand comando, RendimientoVehiculo rendimiento)
        {
            comando.Parameters.AddWithValue("$vehiculoId", rendimiento.vehiculo_id);
            comando.Parameters.AddWithValue("$tipoCombustibleId", rendimiento.tipo_combustible_id);
            comando.Parameters.AddWithValue("$tipoEntorno", (object?)rendimiento.tipo_entorno ?? DBNull.Value);
            comando.Parameters.AddWithValue("$kmPorLitro", rendimiento.km_por_litro);
            comando.Parameters.AddWithValue("$costoPorKm", rendimiento.costo_por_km);
        }

        private static RendimientoVehiculo Mapear(SqliteDataReader lector)
        {
            return new RendimientoVehiculo
            {
                id = lector.GetInt32(0),
                vehiculo_id = lector.GetInt32(1),
                tipo_combustible_id = lector.GetInt32(2),
                tipo_entorno = lector.IsDBNull(3) ? null : lector.GetString(3),
                km_por_litro = lector.GetDecimal(4),
                costo_por_km = lector.GetDecimal(5)
            };
        }

        private static RendimientoVehiculo Clonar(RendimientoVehiculo rendimiento)
        {
            return new RendimientoVehiculo
            {
                id = rendimiento.id,
                vehiculo_id = rendimiento.vehiculo_id,
                tipo_combustible_id = rendimiento.tipo_combustible_id,
                tipo_entorno = rendimiento.tipo_entorno,
                km_por_litro = rendimiento.km_por_litro,
                costo_por_km = rendimiento.costo_por_km
            };
        }
    }
}
