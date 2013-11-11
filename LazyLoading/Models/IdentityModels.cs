﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LazyLoading.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<TelephoneNumber> TelephoneNumbers { get; set; }

        public System.Data.Entity.DbSet<LazyLoading.Models.ClinicTelephoneNumber> ClinicTelephoneNumbers { get; set; }

    }
}