using System;

namespace SistemaCostoViaje.EL
{
/// <summary>
/// Entidad: Viaje
/// Representa un viaje con información de origen, destino y costo
/// </summary>
public class Viaje
{
    public int Id { get; set; }
    public required string Origen { get; set; }
    public required string Destino { get; set; }
    public decimal DistanciaKm { get; set; }
    public decimal CostoBase { get; set; }
    public DateTime FechaViaje { get; set; }
    public int IdConductor { get; set; }
    public ViajeEstado Estado { get; set; }
    public int VehiculoId { get; set; }
    public int TecnicoId { get; set; }
    public decimal HorasOrdinarias { get; set; }
    public decimal HorasExtra { get; set; }
    public decimal CostoFerry { get; set; }
    public decimal CostoHospedaje { get; set; }
    public decimal CostoInsumos { get; set; }
}

    public enum ViajeEstado
    {
        Pendiente = 1,
        EnCurso = 2,
        Completado = 3,
        Cancelado = 4
    }
}