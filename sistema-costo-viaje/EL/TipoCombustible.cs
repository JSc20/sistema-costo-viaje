namespace SistemaCostoViaje.EL;
public class TipoCombustible
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public decimal CostoPorLitro { get; set; }
}
