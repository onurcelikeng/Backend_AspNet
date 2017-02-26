using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taksimetrik.Service.Entities.Tables
{
    [Table("DriverEntity")]
    public class Driver
    {
        public Driver()
        {
            Cars = new List<Car>();
        }


        [Key]
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(10)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(10)]
        public string LastName { get; set; }

        [Required, StringLength(11)]
        public string Phone { get; set; }

        [Required, StringLength(11)]
        public string TCnumber { get; set; }


        public virtual ICollection<Car> Cars { get; set; }
    }
}