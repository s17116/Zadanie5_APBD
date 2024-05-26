using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanie5.Models.DbModels;

namespace zadanie5.Configurations
{
	public class TripEFConfiguration : IEntityTypeConfiguration<Trip>

	{
		public void Configure(EntityTypeBuilder<Trip> builder)
		{
			builder.HasKey(t => t.IdTrip);
			builder.Property(t => t.Name);
			builder.Property(t => t.Description);
			builder.Property(t => t.DateFrom);
			builder.Property(t => t.DateTo);
			builder.Property(t => t.MaxPeople);
		}
	}
}
