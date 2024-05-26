using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanie5.Models.DbModels;

namespace zadanie5.Configurations
{
	public class Client_TripEFConfigurations : IEntityTypeConfiguration<Client_Trip>
	{
		public void Configure(EntityTypeBuilder<Client_Trip> builder)
		{
			builder.HasKey(ct => new {ct.IdClient, ct.IdTrip});
			builder.Property(ct => ct.RegisteredAt);
			builder.Property(ct => ct.PaymentDate).IsRequired(false);
			builder.HasOne(ct => ct.NavigationClient)
				.WithMany(c => c.NavigationClientTrips)
				.HasForeignKey(ct => ct.IdClient);
			builder.HasOne(ct => ct.NavigationTrip)
				.WithMany(t => t.NavigationClient_Trips)
				.HasForeignKey(ct => ct.IdTrip);
		}
	}
}
