using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System;

namespace zadanie5.Models.DbModels
{
	public class Trip
	{
		public int IdTrip { get; set; }
		public string Name {  get; set; }
		public string Description { get; set; }
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }
		public int MaxPeople { get; set; }
		public virtual ICollection<Country_Trip> NavigationCountry_Trips { get; set; }
		public virtual ICollection<Client_Trip> NavigationClient_Trips { get; set; }
	}
}
