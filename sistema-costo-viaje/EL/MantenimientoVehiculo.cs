namespace SistemaCostoViaje.EL;
public class MantenimientoVehiculo
{
    public int Id { get; set; }
    public int VehiculoId { get; set; }
    public required string Descripcion { get; set; }
    public decimal CostoTotal { get; set; }
    public int KmIntervalo { get; set; }
    public decimal CostoPorKm { get; set; }
}
