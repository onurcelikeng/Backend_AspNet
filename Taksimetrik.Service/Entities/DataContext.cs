using System.Data.Entity;
using Taksimetrik.Service.Entities.Tables;

namespace Taksimetrik.Service.Entities
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Car> Cars { get; set; }


        public DataContext() : base("Name=DbConnectinStr")
        {

        }

    }
}