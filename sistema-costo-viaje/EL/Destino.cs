namespace SistemaCostoViaje.EL;
public class Destino
{
    public int Id { get; set; }
    public int PeajeId { get; set; }
    public required string Nombre { get; set; }
    public decimal KmIdaVuelta { get; set; }
}
