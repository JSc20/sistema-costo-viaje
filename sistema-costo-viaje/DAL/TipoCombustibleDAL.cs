using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class TipoCombustibleDAL
    {
        private const string Columnas = "Id, Nombre, CostoPorLitro";

        public List<TipoCombustible> ObtenerTodos()
        {
            var tipos = new List<TipoCombustible>();
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM TiposCombustible ORDER BY Id");
            using var lector = comando.ExecuteReader();
            while (lector.Read())
                tipos.Add(Mapear(lector));
            return tipos;
        }

        public TipoCombustible? ObtenerPorId(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM TiposCombustible WHERE Id = $id");
            comando.Parameters.AddWithValue("$id", id);
            using var lector = comando.ExecuteReader();
            return lector.Read() ? Mapear(lector) : null;
        }

        public TipoCombustible Crear(TipoCombustible tipoCombustible)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                INSERT INTO TiposCombustible (Nombre, CostoPorLitro)
                VALUES ($nombre, $costoPorLitro)
                """);
            AgregarParametros(comando, tipoCombustible);
            comando.ExecuteNonQuery();

            tipoCombustible.Id = ObtenerUltimoId(conexion);
            return Clonar(tipoCombustible);
        }

        public TipoCombustible? Actualizar(TipoCombustible tipoCombustible)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                UPDATE TiposCombustible
                SET Nombre = $nombre, CostoPorLitro = $costoPorLitro
                WHERE Id = $id
                """);
            AgregarParametros(comando, tipoCombustible);
            comando.Parameters.AddWithValue("$id", tipoCombustible.Id);

            return comando.ExecuteNonQuery() > 0 ? Clonar(tipoCombustible) : null;
        }

        public bool Eliminar(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, "DELETE FROM TiposCombustible WHERE Id = $id");
            comando.Parameters.AddWithValue("$id", id);
            return comando.ExecuteNonQuery() > 0;
        }

        private static int ObtenerUltimoId(SqliteConnection conexion)
        {
            using var comando = SqliteContext.CrearComando(conexion, "SELECT last_insert_rowid()");
            return Convert.ToInt32(comando.ExecuteScalar());
        }

        private static void AgregarParametros(SqliteCommand comando, TipoCombustible tipoCombustible)
        {
            comando.Parameters.AddWithValue("$nombre", tipoCombustible.Nombre);
            comando.Parameters.AddWithValue("$costoPorLitro", tipoCombustible.CostoPorLitro);
        }

        private static TipoCombustible Mapear(SqliteDataReader lector)
        {
            return new TipoCombustible
            {
                Id = lector.GetInt32(0),
                Nombre = lector.GetString(1),
                CostoPorLitro = lector.GetDecimal(2)
            };
        }

        private static TipoCombustible Clonar(TipoCombustible tipoCombustible)
        {
            return new TipoCombustible
            {
                Id = tipoCombustible.Id,
                Nombre = tipoCombustible.Nombre,
                CostoPorLitro = tipoCombustible.CostoPorLitro
            };
        }
    }
}
