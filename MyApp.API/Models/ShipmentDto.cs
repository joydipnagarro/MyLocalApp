namespace MyApp.API.Models
{
    public class ShipmentDto
    {
        public int ShipmentId { get; set; }
        public string? Reference { get; set; }
        public string? BillOfLading { get; set; }
        public string? Carrier { get; set; }
        public string? ShipmentStatus { get; set; }
        public DateTime? ETD { get; set; }
        public DateTime? ETA { get; set; }
        public decimal QuotedCharge { get; set; }
        public decimal BilledCharge { get; set; }
    }
}