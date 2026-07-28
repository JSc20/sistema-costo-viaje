using System;
namespace SistemaCostoViaje.EL;
public class Vehiculo
{
    public int Id { get; set; }
    public required string Marca { get; set; }
    public required string Modelo { get; set; }
    public int Año { get; set; }
    public decimal CostoPorKm { get; set; }
}