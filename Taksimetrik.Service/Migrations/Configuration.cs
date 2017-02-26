namespace Taksimetrik.Service.Migrations
{
    using Entities.Tables;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Taksimetrik.Service.Entities.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(Entities.DataContext context)
        {
            var driver = new Driver()
            {
                FirstName = "Elif Seray",
                LastName = "Donmez",
                Phone = "05074437251",
                TCnumber = "52849471213"
            };

            context.Drivers.Add(driver);
        }
    }
}