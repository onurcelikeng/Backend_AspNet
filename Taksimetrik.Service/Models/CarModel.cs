namespace Taksimetrik.Service.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        public int DriverId { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string PlateNumber { get; set; }
    }
}