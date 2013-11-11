using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using LazyLoading.Models;

namespace LazyLoading.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Clinics.AddOrUpdate(c => c.ClinicId,
                new Clinic
                {
                    Name = "The Clinic",
                    TelephoneNumbers =
                        new Collection<ClinicTelephoneNumber>
                        {
                            new ClinicTelephoneNumber
                            {
                                TelephoneNumber =
                                    new TelephoneNumber
                                    {
                                        PhoneNumber = "5553334444",
                                        PhoneType = PhoneType.Work,
                                        CreatedOnUtc = DateTime.UtcNow
                                    }
                            },
                            new ClinicTelephoneNumber
                            {
                                TelephoneNumber =
                                    new TelephoneNumber
                                    {
                                        PhoneNumber = "8883334444",
                                        PhoneType = PhoneType.Fax,
                                        CreatedOnUtc = DateTime.UtcNow
                                    }
                            }
                        }
                });


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}