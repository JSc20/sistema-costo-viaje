namespace sistema_costo_viaje.EL;
public class MantenimientoVehiculo
{
    int id { get; set; }
    int vehiculo_id { get; set; }
    string? descripcion {get; set; }
    decimal costo_total { get; set; }
    int km_intervalo { get; set; }
    decimal costo_por_km { get; set; }
}
