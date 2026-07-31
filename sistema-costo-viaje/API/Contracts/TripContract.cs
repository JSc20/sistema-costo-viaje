using System;
using System.Collections.Generic;

namespace SistemaCostoViaje.API.Contracts
{
    /// <summary>
    /// Representa la información que se envía y recibe al trabajar con viajes.
    /// </summary>
    public class TripContract
    {
        public int Id { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TripStatus Status { get; set; }
        public decimal TotalCost { get; set; }
        public List<CostItemContract> CostItems { get; set; } = new List<CostItemContract>();
    }

    /// <summary>
    /// Enum que describe los posibles estados de un viaje.
    /// </summary>
    public enum TripStatus
    {
        Planned,
        InProgress,
        Completed,
        Cancelled
    }
}
