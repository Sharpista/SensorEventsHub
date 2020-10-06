using Microsoft.EntityFrameworkCore;
using SensorEventsHub.Domain.Enitidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorEventsHub.Infrastructure.Context
{
    public class SensorContext : DbContext
    {
        public DbSet<Sensor> Sensores { get; set; }
        public SensorContext(DbContextOptions<SensorContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SensorContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
