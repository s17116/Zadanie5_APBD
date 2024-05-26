namespace zadanie5.Models.DbModels
{
	public class Country_Trip
	{
		public int IdCountry { get; set; }	
		public int IdTrip { get; set; }
		public virtual Country NavigationCountry { get; set; }
		public virtual Trip NavigationTrip { get; set; }
	}
}
