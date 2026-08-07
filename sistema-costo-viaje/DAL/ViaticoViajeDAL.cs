using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class ViaticoViajeDAL
    {
        private const string Columnas = "Id, ViajeId, Tipo, Monto";

        public List<ViaticoViaje> ObtenerTodos()
        {
            var viaticos = new List<ViaticoViaje>();
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM ViaticoViajes ORDER BY Id");
            using var lector = comando.ExecuteReader();
            while (lector.Read())
                viaticos.Add(Mapear(lector));
            return viaticos;
        }

        public ViaticoViaje? ObtenerPorId(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM ViaticoViajes WHERE Id = $id");
            comando.Parameters.AddWithValue("$id", id);
            using var lector = comando.ExecuteReader();
            return lector.Read() ? Mapear(lector) : null;
        }

        public List<ViaticoViaje> ObtenerPorViajeId(int viajeId)
        {
            var viaticos = new List<ViaticoViaje>();
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM ViaticoViajes WHERE ViajeId = $viajeId ORDER BY Id");
            comando.Parameters.AddWithValue("$viajeId", viajeId);
            using var lector = comando.ExecuteReader();
            while (lector.Read())
                viaticos.Add(Mapear(lector));
            return viaticos;
        }

        public ViaticoViaje Crear(ViaticoViaje viatico)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                INSERT INTO ViaticoViajes (ViajeId, Tipo, Monto)
                VALUES ($viajeId, $tipo, $monto)
                """);
            AgregarParametros(comando, viatico);
            comando.ExecuteNonQuery();

            viatico.Id = ObtenerUltimoId(conexion);
            return Clonar(viatico);
        }

        public ViaticoViaje? Actualizar(ViaticoViaje viatico)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                UPDATE ViaticoViajes
                SET ViajeId = $viajeId, Tipo = $tipo, Monto = $monto
                WHERE Id = $id
                """);
            AgregarParametros(comando, viatico);
            comando.Parameters.AddWithValue("$id", viatico.Id);

            return comando.ExecuteNonQuery() > 0 ? Clonar(viatico) : null;
        }

        public bool Eliminar(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, "DELETE FROM ViaticoViajes WHERE Id = $id");
            comando.Parameters.AddWithValue("$id", id);
            return comando.ExecuteNonQuery() > 0;
        }

        private static int ObtenerUltimoId(SqliteConnection conexion)
        {
            using var comando = SqliteContext.CrearComando(conexion, "SELECT last_insert_rowid()");
            return Convert.ToInt32(comando.ExecuteScalar());
        }

        private static void AgregarParametros(SqliteCommand comando, ViaticoViaje viatico)
        {
            comando.Parameters.AddWithValue("$viajeId", viatico.ViajeId);
            comando.Parameters.AddWithValue("$tipo", viatico.Tipo);
            comando.Parameters.AddWithValue("$monto", viatico.Monto);
        }

        private static ViaticoViaje Mapear(SqliteDataReader lector)
        {
            return new ViaticoViaje
            {
                Id = lector.GetInt32(0),
                ViajeId = lector.GetInt32(1),
                Tipo = lector.GetString(2),
                Monto = lector.GetDecimal(3)
            };
        }

        private static ViaticoViaje Clonar(ViaticoViaje viatico)
        {
            return new ViaticoViaje
            {
                Id = viatico.Id,
                ViajeId = viatico.ViajeId,
                Tipo = viatico.Tipo,
                Monto = viatico.Monto
            };
        }
    }
}
