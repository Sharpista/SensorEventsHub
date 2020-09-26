using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SensorEventsHub.Domain.Enitidades;

namespace SensorEventsHub.Infrastructure.Mapping
{
    public class SensorMapping : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Tag)
                .IsRequired();

            builder
                .Property(x => x.Timestamp)
                .IsRequired();

            builder.Property(x => x.Valor);


        }
    }
}
