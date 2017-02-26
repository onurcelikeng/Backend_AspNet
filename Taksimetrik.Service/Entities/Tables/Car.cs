using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taksimetrik.Service.Entities.Tables
{
    [Table("CarEntity")]
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(10)]
        public string Brand { get; set; }

        [Required, MinLength(3), MaxLength(10)]
        public string Model { get; set; }

        [Required, MinLength(6), MaxLength(10)]
        public string PlateNumber { get; set; }

        [Required]
        public int DriverId { get; set; }
        

        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }
    }
}