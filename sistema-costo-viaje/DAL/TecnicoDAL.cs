using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class TecnicoDAL
    {
        private const string Columnas =
            "id, nombre, salario_mensual, horas_semanales, costo_hora_ordinaria, costo_hora_extra";

        public List<Tecnico> ObtenerTodos()
        {
            var tecnicos = new List<Tecnico>();
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM Tecnicos ORDER BY id");
            using var lector = comando.ExecuteReader();
            while (lector.Read())
                tecnicos.Add(Mapear(lector));
            return tecnicos;
        }

        public Tecnico? ObtenerPorId(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM Tecnicos WHERE id = $id");
            comando.Parameters.AddWithValue("$id", id);
            using var lector = comando.ExecuteReader();
            return lector.Read() ? Mapear(lector) : null;
        }

        public Tecnico Crear(Tecnico tecnico)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                INSERT INTO Tecnicos (nombre, salario_mensual, horas_semanales, costo_hora_ordinaria, costo_hora_extra)
                VALUES ($nombre, $salarioMensual, $horasSemanales, $costoHoraOrdinaria, $costoHoraExtra)
                """);
            AgregarParametros(comando, tecnico);
            comando.ExecuteNonQuery();

            tecnico.id = ObtenerUltimoId(conexion);
            return Clonar(tecnico);
        }

        public Tecnico? Actualizar(Tecnico tecnico)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                UPDATE Tecnicos
                SET nombre = $nombre, salario_mensual = $salarioMensual, horas_semanales = $horasSemanales,
                    costo_hora_ordinaria = $costoHoraOrdinaria, costo_hora_extra = $costoHoraExtra
                WHERE id = $id
                """);
            AgregarParametros(comando, tecnico);
            comando.Parameters.AddWithValue("$id", tecnico.id);

            return comando.ExecuteNonQuery() > 0 ? Clonar(tecnico) : null;
        }

        public bool Eliminar(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, "DELETE FROM Tecnicos WHERE id = $id");
            comando.Parameters.AddWithValue("$id", id);
            return comando.ExecuteNonQuery() > 0;
        }

        private static int ObtenerUltimoId(SqliteConnection conexion)
        {
            using var comando = SqliteContext.CrearComando(conexion, "SELECT last_insert_rowid()");
            return Convert.ToInt32(comando.ExecuteScalar());
        }

        private static void AgregarParametros(SqliteCommand comando, Tecnico tecnico)
        {
            comando.Parameters.AddWithValue("$nombre", tecnico.nombre);
            comando.Parameters.AddWithValue("$salarioMensual", tecnico.salario_mensual);
            comando.Parameters.AddWithValue("$horasSemanales", tecnico.horas_semanales);
            comando.Parameters.AddWithValue("$costoHoraOrdinaria", tecnico.costo_hora_ordinaria);
            comando.Parameters.AddWithValue("$costoHoraExtra", tecnico.costo_hora_extra);
        }

        private static Tecnico Mapear(SqliteDataReader lector)
        {
            return new Tecnico
            {
                id = lector.GetInt32(0),
                nombre = lector.GetString(1),
                salario_mensual = lector.GetDecimal(2),
                horas_semanales = lector.GetInt32(3),
                costo_hora_ordinaria = lector.GetDecimal(4),
                costo_hora_extra = lector.GetDecimal(5)
            };
        }

        private static Tecnico Clonar(Tecnico tecnico)
        {
            return new Tecnico
            {
                id = tecnico.id,
                nombre = tecnico.nombre,
                salario_mensual = tecnico.salario_mensual,
                horas_semanales = tecnico.horas_semanales,
                costo_hora_ordinaria = tecnico.costo_hora_ordinaria,
                costo_hora_extra = tecnico.costo_hora_extra
            };
        }
    }
}
