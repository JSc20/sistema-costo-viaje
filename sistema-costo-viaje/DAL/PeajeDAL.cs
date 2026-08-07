using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class PeajeDAL
    {
        private const string Columnas = "Id, Nombre, Costo";

        public List<Peaje> ObtenerTodos()
        {
            var peajes = new List<Peaje>();
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM Peajes ORDER BY Id");
            using var lector = comando.ExecuteReader();
            while (lector.Read())
                peajes.Add(Mapear(lector));
            return peajes;
        }

        public Peaje? ObtenerPorId(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM Peajes WHERE Id = $id");
            comando.Parameters.AddWithValue("$id", id);
            using var lector = comando.ExecuteReader();
            return lector.Read() ? Mapear(lector) : null;
        }

        public Peaje Crear(Peaje peaje)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                INSERT INTO Peajes (Nombre, Costo)
                VALUES ($nombre, $costo)
                """);
            AgregarParametros(comando, peaje);
            comando.ExecuteNonQuery();

            peaje.Id = ObtenerUltimoId(conexion);
            return Clonar(peaje);
        }

        public Peaje? Actualizar(Peaje peaje)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                UPDATE Peajes
                SET Nombre = $nombre, Costo = $costo
                WHERE Id = $id
                """);
            AgregarParametros(comando, peaje);
            comando.Parameters.AddWithValue("$id", peaje.Id);

            return comando.ExecuteNonQuery() > 0 ? Clonar(peaje) : null;
        }

        public bool Eliminar(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, "DELETE FROM Peajes WHERE Id = $id");
            comando.Parameters.AddWithValue("$id", id);
            return comando.ExecuteNonQuery() > 0;
        }

        private static int ObtenerUltimoId(SqliteConnection conexion)
        {
            using var comando = SqliteContext.CrearComando(conexion, "SELECT last_insert_rowid()");
            return Convert.ToInt32(comando.ExecuteScalar());
        }

        private static void AgregarParametros(SqliteCommand comando, Peaje peaje)
        {
            comando.Parameters.AddWithValue("$nombre", peaje.Nombre);
            comando.Parameters.AddWithValue("$costo", peaje.Costo);
        }

        private static Peaje Mapear(SqliteDataReader lector)
        {
            return new Peaje
            {
                Id = lector.GetInt32(0),
                Nombre = lector.GetString(1),
                Costo = lector.GetDecimal(2)
            };
        }

        private static Peaje Clonar(Peaje peaje)
        {
            return new Peaje
            {
                Id = peaje.Id,
                Nombre = peaje.Nombre,
                Costo = peaje.Costo
            };
        }
    }
}
