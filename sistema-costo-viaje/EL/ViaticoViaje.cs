namespace SistemaCostoViaje.EL;
public class ViaticoViaje
{
    public int Id { get; set; }
    public int ViajeId { get; set; }
    public required string Tipo { get; set; }
    public decimal Monto { get; set; }
}
