using DentaService.API.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentaService.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<DetailService> DetailServices { get; set; }

        public DbSet<Diagnostic> Diagnostics  { get; set; }

        public DbSet<Especialization> Especializations { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Shedule> Shedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DetailService>().HasIndex(x => x.PaymentMethod).IsUnique();
            modelBuilder.Entity<Diagnostic>().HasIndex(x => x.Remark).IsUnique();
            modelBuilder.Entity<Especialization>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Equipment>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Shedule>().HasIndex(x => x.Date).IsUnique();
        }
    }
}
