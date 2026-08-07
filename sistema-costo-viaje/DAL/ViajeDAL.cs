using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class ViajeDAL
    {
        private const string Columnas =
            "Id, Origen, Destino, DistanciaKm, CostoBase, FechaViaje, IdConductor, Estado, " +
            "VehiculoId, TecnicoId, HorasOrdinarias, HorasExtra, CostoFerry, CostoHospedaje, CostoInsumos";

        public List<Viaje> ObtenerTodos()
        {
            var viajes = new List<Viaje>();
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM Viajes ORDER BY Id");
            using var lector = comando.ExecuteReader();
            while (lector.Read())
                viajes.Add(Mapear(lector));
            return viajes;
        }

        public Viaje? ObtenerPorId(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, $"SELECT {Columnas} FROM Viajes WHERE Id = $id");
            comando.Parameters.AddWithValue("$id", id);
            using var lector = comando.ExecuteReader();
            return lector.Read() ? Mapear(lector) : null;
        }

        public Viaje Crear(Viaje viaje)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                INSERT INTO Viajes (Origen, Destino, DistanciaKm, CostoBase, FechaViaje, IdConductor, Estado,
                                    VehiculoId, TecnicoId, HorasOrdinarias, HorasExtra, CostoFerry, CostoHospedaje, CostoInsumos)
                VALUES ($origen, $destino, $distanciaKm, $costoBase, $fechaViaje, $idConductor, $estado,
                        $vehiculoId, $tecnicoId, $horasOrdinarias, $horasExtra, $costoFerry, $costoHospedaje, $costoInsumos)
                """);
            AgregarParametros(comando, viaje);
            comando.ExecuteNonQuery();

            viaje.Id = ObtenerUltimoId(conexion);
            return Clonar(viaje);
        }

        public Viaje? Actualizar(Viaje viaje)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, """
                UPDATE Viajes
                SET Origen = $origen, Destino = $destino, DistanciaKm = $distanciaKm, CostoBase = $costoBase,
                    FechaViaje = $fechaViaje, IdConductor = $idConductor, Estado = $estado, VehiculoId = $vehiculoId,
                    TecnicoId = $tecnicoId, HorasOrdinarias = $horasOrdinarias, HorasExtra = $horasExtra,
                    CostoFerry = $costoFerry, CostoHospedaje = $costoHospedaje, CostoInsumos = $costoInsumos
                WHERE Id = $id
                """);
            AgregarParametros(comando, viaje);
            comando.Parameters.AddWithValue("$id", viaje.Id);

            return comando.ExecuteNonQuery() > 0 ? Clonar(viaje) : null;
        }

        public bool Eliminar(int id)
        {
            using var conexion = SqliteContext.AbrirConexion();
            using var comando = SqliteContext.CrearComando(conexion, "DELETE FROM Viajes WHERE Id = $id");
            comando.Parameters.AddWithValue("$id", id);
            return comando.ExecuteNonQuery() > 0;
        }

        private static int ObtenerUltimoId(SqliteConnection conexion)
        {
            using var comando = SqliteContext.CrearComando(conexion, "SELECT last_insert_rowid()");
            return Convert.ToInt32(comando.ExecuteScalar());
        }

        private static void AgregarParametros(SqliteCommand comando, Viaje viaje)
        {
            comando.Parameters.AddWithValue("$origen", viaje.Origen);
            comando.Parameters.AddWithValue("$destino", viaje.Destino);
            comando.Parameters.AddWithValue("$distanciaKm", viaje.DistanciaKm);
            comando.Parameters.AddWithValue("$costoBase", viaje.CostoBase);
            comando.Parameters.AddWithValue("$fechaViaje", viaje.FechaViaje);
            comando.Parameters.AddWithValue("$idConductor", viaje.IdConductor);
            comando.Parameters.AddWithValue("$estado", (int)viaje.Estado);
            comando.Parameters.AddWithValue("$vehiculoId", viaje.VehiculoId);
            comando.Parameters.AddWithValue("$tecnicoId", viaje.TecnicoId);
            comando.Parameters.AddWithValue("$horasOrdinarias", viaje.HorasOrdinarias);
            comando.Parameters.AddWithValue("$horasExtra", viaje.HorasExtra);
            comando.Parameters.AddWithValue("$costoFerry", viaje.CostoFerry);
            comando.Parameters.AddWithValue("$costoHospedaje", viaje.CostoHospedaje);
            comando.Parameters.AddWithValue("$costoInsumos", viaje.CostoInsumos);
        }

        private static Viaje Mapear(SqliteDataReader lector)
        {
            return new Viaje
            {
                Id = lector.GetInt32(0),
                Origen = lector.GetString(1),
                Destino = lector.GetString(2),
                DistanciaKm = lector.GetDecimal(3),
                CostoBase = lector.GetDecimal(4),
                FechaViaje = lector.GetDateTime(5),
                IdConductor = lector.GetInt32(6),
                Estado = (ViajeEstado)lector.GetInt32(7),
                VehiculoId = lector.GetInt32(8),
                TecnicoId = lector.GetInt32(9),
                HorasOrdinarias = lector.GetDecimal(10),
                HorasExtra = lector.GetDecimal(11),
                CostoFerry = lector.GetDecimal(12),
                CostoHospedaje = lector.GetDecimal(13),
                CostoInsumos = lector.GetDecimal(14)
            };
        }

        private static Viaje Clonar(Viaje viaje)
        {
            return new Viaje
            {
                Id = viaje.Id,
                Origen = viaje.Origen,
                Destino = viaje.Destino,
                DistanciaKm = viaje.DistanciaKm,
                CostoBase = viaje.CostoBase,
                FechaViaje = viaje.FechaViaje,
                IdConductor = viaje.IdConductor,
                Estado = viaje.Estado,
                VehiculoId = viaje.VehiculoId,
                TecnicoId = viaje.TecnicoId,
                HorasOrdinarias = viaje.HorasOrdinarias,
                HorasExtra = viaje.HorasExtra,
                CostoFerry = viaje.CostoFerry,
                CostoHospedaje = viaje.CostoHospedaje,
                CostoInsumos = viaje.CostoInsumos
            };
        }
    }
}
