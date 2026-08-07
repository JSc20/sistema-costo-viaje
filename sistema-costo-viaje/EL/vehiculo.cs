using System;
namespace SistemaCostoViaje.EL;
public class Vehiculo
{
    public int Id { get; set; }
    public required string Marca { get; set; }
    public required string Modelo { get; set; }
    public int Año { get; set; }
    public decimal CostoPorKm { get; set; }
    public decimal ValorActual { get; set; }
    public decimal ValorFuturo { get; set; }
    public int KmRestantesUso { get; set; }
    public int KmAnuales { get; set; }
    public decimal CostosFijosAnuales { get; set; }
    public decimal DepreciacionPorKm => KmRestantesUso > 0 ? (ValorActual - ValorFuturo) / KmRestantesUso : 0m;
    public decimal CostoFijoPorKm => KmAnuales > 0 ? CostosFijosAnuales / KmAnuales : 0m;
}