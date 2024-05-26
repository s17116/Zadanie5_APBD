using zadanie5.Models.DbModels;

namespace zadanie5.Models.DTO
{
	public class TripSelectDTO
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }
		public int MaxPeople { get; set; }
		public List<CountrySelectDTO> Countries { get; set; }
		public List<ClientSelectDTO> Clients { get; set; }

	}
}
