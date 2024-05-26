using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanie5.Models.DbModels;

namespace zadanie5.Configurations
{
	public class CountryEFConfiguration : IEntityTypeConfiguration<Country>
	{
		public void Configure(EntityTypeBuilder<Country> builder)
		{
			builder.HasKey(c => c.IdCountry);
			builder.Property(c => c.Name);
		}
	}
}
