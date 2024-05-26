using zadanie5.Models.DTO;

namespace zadanie5.Services.Interfaces
{
	public interface ITripService
	{
		public Task <List<TripSelectDTO>> GetTrips();
		public Task <bool> AddClientToTrip(Client_TripInsertDTO client_TripInsertDTO, int idTrip);
	}
}
