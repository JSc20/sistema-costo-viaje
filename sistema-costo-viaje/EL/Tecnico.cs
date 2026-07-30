namespace SistemaCostoViaje.EL;
public class Tecnico
{
    public int id { get; set; }
    public required string nombre { get; set; }
    public decimal salario_mensual { get; set; }
    public int horas_semanales { get; set; }
    public decimal costo_hora_ordinaria { get; set; }
    public decimal costo_hora_extra { get; set; }
}
