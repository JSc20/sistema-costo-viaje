using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaCostoViaje.EL;
public class RendimientoVehiculo
{
    public int id { get; set; }
    [ForeignKey("Vehiculo")]
    public int vehiculo_id { get; set; }
    [ForeignKey("TipoCombustible")]
    public int tipo_combustible_id { get; set; }
    public string? tipo_entorno { get; set; }
    public decimal km_por_litro { get; set; }
    public decimal costo_por_km { get; set; }
}
