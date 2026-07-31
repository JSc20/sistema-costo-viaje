using System;

namespace SistemaCostoViaje.API.Contracts
{
    /// <summary>
    /// Representa la información de un ítem de costo asociado a un viaje.
    /// </summary>
    public class CostItemContract
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public CostItemCategory Category { get; set; }
    }

    /// <summary>
    /// Enum que describe las categorías de costos que pueden existir.
    /// </summary>
    public enum CostItemCategory
    {
        Fuel,
        Maintenance,
        Toll,
        Accommodation,
        Meals,
        Other
    }
}
