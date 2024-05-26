using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanie5.Models.DbModels;

namespace zadanie5.Configurations
{
	public class ClientEFConfiguration : IEntityTypeConfiguration<Client>
	{
		public void Configure(EntityTypeBuilder<Client> builder)
		{
			builder.HasKey(c => c.IdClient);
			builder.Property(c => c.FirstName).HasColumnType("string");
			builder.Property(c => c.LastName).HasColumnType("string");
			builder.Property(c => c.Pesel).HasColumnType("string");
			builder.Property(c => c.Email).HasColumnType("string");
			builder.Property(c => c.Telephone).HasColumnType("string");
		}
	}
}
