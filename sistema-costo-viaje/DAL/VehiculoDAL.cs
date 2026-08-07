using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class VehiculoDAL
    {
        private const string Columnas =
            "Id, Marca, Modelo, \"Año\", CostoPorKm, ValorActual, ValorFuturo, KmRestantesUso, KmAnuales, CostosFijosAnuales";

        public List<Vehiculo> ObtenerTodos()
        {
            var vehiculos = new List<Vehiculo>();
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM Vehiculos ORDER BY Id");
            using var lector = comando.ExecuteReader();
            while (lector.Read())
                vehiculos.Add(Mapear(lector));
            return vehiculos;
        }

        public Vehiculo? ObtenerPorId(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM Vehiculos WHERE Id = $id");
            comando.Parameters.AddWithValue("$id", id);
            using var lector = comando.ExecuteReader();
            return lector.Read() ? Mapear(lector) : null;
        }

        public Vehiculo Crear(Vehiculo vehiculo)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                INSERT INTO Vehiculos (Marca, Modelo, "Año", CostoPorKm, ValorActual, ValorFuturo, KmRestantesUso, KmAnuales, CostosFijosAnuales)
                VALUES ($marca, $modelo, $anio, $costoPorKm, $valorActual, $valorFuturo, $kmRestantesUso, $kmAnuales, $costosFijosAnuales)
                """);
            AgregarParametros(comando, vehiculo);
            comando.ExecuteNonQuery();

            vehiculo.Id = ObtenerUltimoId(conexion);
            return Clonar(vehiculo);
        }

        public Vehiculo? Actualizar(Vehiculo vehiculo)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                UPDATE Vehiculos
                SET Marca = $marca, Modelo = $modelo, "Año" = $anio, CostoPorKm = $costoPorKm, ValorActual = $valorActual,
                    ValorFuturo = $valorFuturo, KmRestantesUso = $kmRestantesUso, KmAnuales = $kmAnuales, CostosFijosAnuales = $costosFijosAnuales
                WHERE Id = $id
                """);
            AgregarParametros(comando, vehiculo);
            comando.Parameters.AddWithValue("$id", vehiculo.Id);

            return comando.ExecuteNonQuery() > 0 ? Clonar(vehiculo) : null;
        }

        public bool Eliminar(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, "DELETE FROM Vehiculos WHERE Id = $id");
            comando.Parameters.AddWithValue("$id", id);
            return comando.ExecuteNonQuery() > 0;
        }

        private static int ObtenerUltimoId(SqliteConnection conexion)
        {
            using var comando = SqliteContext.CrearComando(conexion, "SELECT last_insert_rowid()");
            return Convert.ToInt32(comando.ExecuteScalar());
        }

        private static void AgregarParametros(SqliteCommand comando, Vehiculo vehiculo)
        {
            comando.Parameters.AddWithValue("$marca", vehiculo.Marca);
            comando.Parameters.AddWithValue("$modelo", vehiculo.Modelo);
            comando.Parameters.AddWithValue("$anio", vehiculo.Año);
            comando.Parameters.AddWithValue("$costoPorKm", vehiculo.CostoPorKm);
            comando.Parameters.AddWithValue("$valorActual", vehiculo.ValorActual);
            comando.Parameters.AddWithValue("$valorFuturo", vehiculo.ValorFuturo);
            comando.Parameters.AddWithValue("$kmRestantesUso", vehiculo.KmRestantesUso);
            comando.Parameters.AddWithValue("$kmAnuales", vehiculo.KmAnuales);
            comando.Parameters.AddWithValue("$costosFijosAnuales", vehiculo.CostosFijosAnuales);
        }

        private static Vehiculo Mapear(SqliteDataReader lector)
        {
            return new Vehiculo
            {
                Id = lector.GetInt32(0),
                Marca = lector.GetString(1),
                Modelo = lector.GetString(2),
                Año = lector.GetInt32(3),
                CostoPorKm = lector.GetDecimal(4),
                ValorActual = lector.GetDecimal(5),
                ValorFuturo = lector.GetDecimal(6),
                KmRestantesUso = lector.GetInt32(7),
                KmAnuales = lector.GetInt32(8),
                CostosFijosAnuales = lector.GetDecimal(9)
            };
        }

        private static Vehiculo Clonar(Vehiculo vehiculo)
        {
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
