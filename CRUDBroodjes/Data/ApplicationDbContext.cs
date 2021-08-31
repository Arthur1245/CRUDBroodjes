using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CRUDBroodjes.Models;

namespace CRUDBroodjes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CRUDBroodjes.Models.Bestelling> Bestelling { get; set; }
        public DbSet<CRUDBroodjes.Models.Broodje> Broodje { get; set; }
        public DbSet<CRUDBroodjes.Models.Persoon> Persoon { get; set; }
    }
}
