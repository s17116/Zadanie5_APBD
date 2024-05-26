namespace zadanie5.Models.DbModels
{
	public class Client_Trip
	{
		public int IdClient { get; set; }
		public int IdTrip {  get; set; }
		public DateTime RegisteredAt { get; set; }
		public DateTime? PaymentDate {  get; set; }
		public virtual Client NavigationClient { get; set; }
		public virtual Trip NavigationTrip { get; set; }
	}
}
