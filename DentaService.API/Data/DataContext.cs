using DentaService.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentaService.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Especialization> Especializations { get; set; }

        public DbSet<Shedule> Shedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Especialization>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Shedule>().HasIndex(x => x.Date).IsUnique();
        }
    }
}
