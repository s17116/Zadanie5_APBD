using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanie5.Models.DbModels;

namespace zadanie5.Configurations
{
	public class Country_TripEFConfiguration : IEntityTypeConfiguration<Country_Trip>
	{
		public void Configure(EntityTypeBuilder<Country_Trip> builder)
		{
			builder.HasKey(ct => new {ct.IdCountry, ct.IdTrip});
			builder.HasOne(ct => ct.NavigationTrip)
					.WithMany(t => t.NavigationCountry_Trips)
					.HasForeignKey(t => t.IdTrip);
			builder.HasOne(ct => ct.NavigationCountry)
					.WithMany(c => c.NavigationCountryTrips)
					.HasForeignKey(t => t.IdTrip);
		}
	}
}
