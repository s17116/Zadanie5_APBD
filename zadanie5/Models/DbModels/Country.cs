namespace zadanie5.Models.DbModels
{
	public class Country
	{
		public int IdCountry { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Country_Trip> NavigationCountryTrips { get; set; }
	}
}
