namespace MyApp.API.Models
{
    public class ShipmentFilterRequest
    {
        public int ShipmentId { get; set; }
        public DateTime FromDt { get; set; }
        public DateTime ToDt { get; set; }
        public string? ShipmentStatus { get; set; }
        public int UserId { get; set; }
    }
}