using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SensorEventsHub.Domain.Enitidades;
using System;

namespace SensorEventsHub.Infrastructure.Mapping
{
    public class SensorMapping : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder
                .HasKey( x => x.Id);

            builder
                .Property(x => x.Tag).HasMaxLength(100).IsRequired();

            builder
                .Property(x => x.Timestamp).HasMaxLength(100).IsRequired();
               

            builder.Property(x => x.Valor).IsRequired();


        }
    }
}
