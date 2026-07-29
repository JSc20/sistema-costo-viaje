using System;
namespace SistemaCostoViaje.EL;
public class TpoCombustible
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public decimal CostoPorLitro { get; set; }
}