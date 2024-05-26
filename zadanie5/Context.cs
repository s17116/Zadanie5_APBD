using Microsoft.EntityFrameworkCore;
using zadanie5.Configurations;
using zadanie5.Models.DbModels;

namespace zadanie5
{
	public class Context : DbContext
	{
		public DbSet<Client> Client { get; set; }
		public DbSet<Client_Trip> Client_Trip { get; set; }
		public DbSet<Trip> Trip { get; set; }
		public DbSet<Country_Trip> Country_Trip { get; set; }
		public DbSet<Country> Country { get; set;}
        public Context(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("trip");
			modelBuilder.ApplyConfiguration(new ClientEFConfiguration());
			modelBuilder.ApplyConfiguration(new Client_TripEFConfigurations());
			modelBuilder.ApplyConfiguration(new TripEFConfiguration());
			modelBuilder.ApplyConfiguration(new Country_TripEFConfiguration());
			modelBuilder.ApplyConfiguration(new CountryEFConfiguration());
		}
	}
}
