using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaCostoViaje.EL;
public class RendimientoVehiculo
{
    int id { get; set; }
    [ForeignKey("Vehiculo")]
    int vehiculo_id { get; set; }
    [ForeignKey("TipoCombustible")]
    int tipo_combustible_id { get; set; }
    string? tipo_entorno { get; set; }
    decimal km_por_litro { get; set; }
    decimal costo_por_km { get; set; }
}
