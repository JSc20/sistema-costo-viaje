using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace SistemaCostoViaje.DAL
{
    /// <summary>
    /// Contexto de base de datos SQLite. Al primer uso crea el archivo de base de datos,
    /// el esquema y los datos semilla necesarios para el funcionamiento del sistema.
    /// </summary>
    public static class SqliteContext
    {
        private const string NombreArchivo = "sistema_costo_viaje.db";

        /// <summary>
        /// Ruta completa del archivo de base de datos.
        /// </summary>
        public static string RutaBaseDatos { get; }

        /// <summary>
        /// Cadena de conexión hacia la base de datos SQLite local.
        /// </summary>
        public static string ConnectionString { get; }

        static SqliteContext()
        {
            RutaBaseDatos = Path.Combine(AppContext.BaseDirectory, NombreArchivo);
            ConnectionString = new SqliteConnectionStringBuilder
            {
                DataSource = RutaBaseDatos,
                Mode = SqliteOpenMode.ReadWriteCreate,
                Cache = SqliteCacheMode.Shared
            }.ToString();

            Inicializar();
        }

        /// <summary>
        /// Abre una conexión a la base de datos con journaling WAL y timeout de escritura.
        /// </summary>
        public static SqliteConnection AbrirConexion()
        {
            var conexion = new SqliteConnection(ConnectionString);
            conexion.Open();

            using (var comando = conexion.CreateCommand())
            {
                comando.CommandText = "PRAGMA journal_mode = WAL; PRAGMA busy_timeout = 30000;";
                comando.ExecuteNonQuery();
            }

            return conexion;
        }

        /// <summary>
        /// Crea un comando asociado a una conexión abierta.
        /// </summary>
        public static SqliteCommand CrearComando(SqliteConnection conexion, string sql)
        {
            var comando = conexion.CreateCommand();
            comando.CommandText = sql;
            return comando;
        }

        /// <summary>
        /// Ejecuta la creación del esquema y los datos semilla cuando la base de datos aún no existe.
        /// </summary>
        private static void Inicializar()
        {
            // Los datos semilla solo se insertan cuando el archivo de base de datos se crea por primera vez.
            // Así, si el usuario elimina todos los vehículos, ese cambio se conserva al reiniciar la aplicación
            // y los vehículos "por defecto" no vuelven a aparecer (issue #64).
            bool baseRecienCreada = !File.Exists(RutaBaseDatos);

            using var conexion = AbrirConexion();

            using (var comando = CrearComando(conexion, Esquema))
            {
                comando.ExecuteNonQuery();
            }

            if (baseRecienCreada)
                SembrarVehiculos(conexion);
        }

        private static void SembrarVehiculos(SqliteConnection conexion)
        {
            const string sql = """
                INSERT INTO Vehiculos (Id, Marca, Modelo, "Año", CostoPorKm, ValorActual, ValorFuturo, KmRestantesUso, KmAnuales, CostosFijosAnuales)
                VALUES (1, 'Toyota', 'Corolla', 2020, 0.80, 8000000, 3000000, 100000, 15000, 400000),
                       (2, 'Ford', 'Ranger', 2019, 1.10, 12000000, 5000000, 120000, 20000, 500000),
                       (3, 'Chevrolet', 'Spark', 2022, 0.70, 6000000, 2000000, 90000, 12000, 350000);
                """;

            using var comando = CrearComando(conexion, sql);
            comando.ExecuteNonQuery();
        }

        private const string Esquema = """
            CREATE TABLE IF NOT EXISTS Viajes (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Origen TEXT NOT NULL,
                Destino TEXT NOT NULL,
                DistanciaKm REAL NOT NULL,
                CostoBase REAL NOT NULL,
                FechaViaje TEXT NOT NULL,
                IdConductor INTEGER NOT NULL,
                Estado INTEGER NOT NULL,
                VehiculoId INTEGER NOT NULL,
                TecnicoId INTEGER NOT NULL,
                HorasOrdinarias REAL NOT NULL,
                HorasExtra REAL NOT NULL,
                CostoFerry REAL NOT NULL,
                CostoHospedaje REAL NOT NULL,
                CostoInsumos REAL NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Vehiculos (
                Id INTEGER PRIMARY KEY,
                Marca TEXT NOT NULL,
                Modelo TEXT NOT NULL,
                "Año" INTEGER NOT NULL,
                CostoPorKm REAL NOT NULL,
                ValorActual REAL NOT NULL,
                ValorFuturo REAL NOT NULL,
                KmRestantesUso INTEGER NOT NULL,
                KmAnuales INTEGER NOT NULL,
                CostosFijosAnuales REAL NOT NULL
            );

            CREATE TABLE IF NOT EXISTS TiposCombustible (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL,
                CostoPorLitro REAL NOT NULL
            );

            CREATE TABLE IF NOT EXISTS RendimientoVehiculos (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                vehiculo_id INTEGER NOT NULL,
                tipo_combustible_id INTEGER NOT NULL,
                tipo_entorno TEXT NULL,
                km_por_litro REAL NOT NULL,
                costo_por_km REAL NOT NULL
            );

            CREATE TABLE IF NOT EXISTS MantenimientoVehiculos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                VehiculoId INTEGER NOT NULL,
                Descripcion TEXT NOT NULL,
                CostoTotal REAL NOT NULL,
                KmIntervalo INTEGER NOT NULL,
                CostoPorKm REAL NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Tecnicos (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                nombre TEXT NOT NULL,
                salario_mensual REAL NOT NULL,
                horas_semanales INTEGER NOT NULL,
                costo_hora_ordinaria REAL NOT NULL,
                costo_hora_extra REAL NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Destinos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                PeajeId INTEGER NOT NULL,
                Nombre TEXT NOT NULL,
                KmIdaVuelta REAL NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Peajes (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL,
                Costo REAL NOT NULL
            );

            CREATE TABLE IF NOT EXISTS ViaticoViajes (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                ViajeId INTEGER NOT NULL,
                Tipo TEXT NOT NULL,
                Monto REAL NOT NULL
            );
            """;
    }
}
