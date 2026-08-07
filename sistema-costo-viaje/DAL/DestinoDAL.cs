using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class DestinoDAL
    {
        private const string Columnas = "Id, PeajeId, Nombre, KmIdaVuelta";

        public List<Destino> ObtenerTodos()
        {
            var destinos = new List<Destino>();
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM Destinos ORDER BY Id");
            using var lector = comando.ExecuteReader();
            while (lector.Read())
                destinos.Add(Mapear(lector));
            return destinos;
        }

        public Destino? ObtenerPorId(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM Destinos WHERE Id = $id");
            comando.Parameters.AddWithValue("$id", id);
            using var lector = comando.ExecuteReader();
            return lector.Read() ? Mapear(lector) : null;
        }

        public Destino Crear(Destino destino)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                INSERT INTO Destinos (PeajeId, Nombre, KmIdaVuelta)
                VALUES ($peajeId, $nombre, $kmIdaVuelta)
                """);
            AgregarParametros(comando, destino);
            comando.ExecuteNonQuery();

            destino.Id = ObtenerUltimoId(conexion);
            return Clonar(destino);
        }

        public Destino? Actualizar(Destino destino)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                UPDATE Destinos
                SET PeajeId = $peajeId, Nombre = $nombre, KmIdaVuelta = $kmIdaVuelta
                WHERE Id = $id
                """);
            AgregarParametros(comando, destino);
            comando.Parameters.AddWithValue("$id", destino.Id);

            return comando.ExecuteNonQuery() > 0 ? Clonar(destino) : null;
        }

        public bool Eliminar(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, "DELETE FROM Destinos WHERE Id = $id");
            comando.Parameters.AddWithValue("$id", id);
            return comando.ExecuteNonQuery() > 0;
        }

        private static int ObtenerUltimoId(SqliteConnection conexion)
        {
            using var comando = SqliteContext.CrearComando(conexion, "SELECT last_insert_rowid()");
            return Convert.ToInt32(comando.ExecuteScalar());
        }

        private static void AgregarParametros(SqliteCommand comando, Destino destino)
        {
            comando.Parameters.AddWithValue("$peajeId", destino.PeajeId);
            comando.Parameters.AddWithValue("$nombre", destino.Nombre);
            comando.Parameters.AddWithValue("$kmIdaVuelta", destino.KmIdaVuelta);
        }

        private static Destino Mapear(SqliteDataReader lector)
        {
            return new Destino
            {
                Id = lector.GetInt32(0),
                PeajeId = lector.GetInt32(1),
                Nombre = lector.GetString(2),
                KmIdaVuelta = lector.GetDecimal(3)
            };
        }

        private static Destino Clonar(Destino destino)
        {
            return new Destino
            {
                Id = destino.Id,
                PeajeId = destino.PeajeId,
                Nombre = destino.Nombre,
                KmIdaVuelta = destino.KmIdaVuelta
            };
        }
    }
}
