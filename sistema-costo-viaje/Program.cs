using SistemaCostoViaje.DAL;
using sistema_costo_viaje.View;

namespace sistema_costo_viaje;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        try
        {
            // Asegura que la base de datos SQLite se cree junto al ejecutable al iniciar.
            _ = SqliteContext.ConnectionString;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"No se pudo inicializar la base de datos:\n{ex.Message}",
                "Sistema Costo Viaje",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        Application.Run(new View.MainMenu());
    }
}