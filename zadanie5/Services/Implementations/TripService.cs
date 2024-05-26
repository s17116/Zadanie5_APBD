using Microsoft.EntityFrameworkCore;
using zadanie5.Models.DbModels;
using zadanie5.Models.DTO;
using zadanie5.Services.Interfaces;

namespace zadanie5.Services.Implementations
{
	public class TripService : ITripService
	{
		private readonly Context _context;
        public TripService(Context context)
        {
            this._context = context;
        }

		public async Task<bool> AddClientToTrip(Client_TripInsertDTO client_TripInsertDTO, int idTrip)
		{
			if(!await _context.Client.AnyAsync(cl => cl.Pesel == client_TripInsertDTO.Pesel))
			{
				Client client = new Client();
				client.IdClient = await _context.Client.CountAsync()+1;
				client.FirstName = client_TripInsertDTO.FirstName;
				client.LastName = client_TripInsertDTO.LastName;
				client.Email = client_TripInsertDTO.Email;
				client.Telephone = client_TripInsertDTO.Telephone;
				client.Pesel = client_TripInsertDTO.Pesel;
				await _context.Client.AddAsync(client);
				await _context.SaveChangesAsync();
			}
			var c = await _context.Client.FirstOrDefaultAsync(cl => cl.Pesel == client_TripInsertDTO.Pesel);

			if(await _context.Client_Trip.AnyAsync(ct => ct.IdTrip == idTrip && ct.IdClient == c.IdClient)) 
			{
				return false;
			}
			if(!await _context.Trip.AnyAsync(t => t.IdTrip == idTrip)) 
			{
				return false;
			}

			Client_Trip client_Trip = new Client_Trip();
			client_Trip.IdClient = c.IdClient;
			client_Trip.IdTrip = idTrip;
			client_Trip.RegisteredAt = DateTime.Now;
			client_Trip.PaymentDate = client_TripInsertDTO.PaymentDate;
			await _context.Client_Trip.AddAsync(client_Trip);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<List<TripSelectDTO>> GetTrips()
		{
			List<TripSelectDTO> trips = new List<TripSelectDTO>();
			var tripsDBContext = await _context.Trip.ToListAsync();
			foreach(var trip in tripsDBContext)
			{
				List<ClientSelectDTO> clients = new List<ClientSelectDTO>();
				List<CountrySelectDTO> countries = new List<CountrySelectDTO>();

				foreach (var client in trip.NavigationClient_Trips)
				{
					var c = await _context.Client.FirstOrDefaultAsync(cl => cl.IdClient == client.IdClient);
					ClientSelectDTO clientSelectDTO = new ClientSelectDTO();
					clientSelectDTO.FirstName = c.FirstName;
					clientSelectDTO.LastName = c.LastName;
					clients.Add(clientSelectDTO);
				}

				foreach (var  country in trip.NavigationCountry_Trips) 
				{
					var co = await _context.Country.FirstOrDefaultAsync(co => co.IdCountry == country.IdCountry);
					CountrySelectDTO countrySelectDTO = new CountrySelectDTO();
					countrySelectDTO.Name = co.Name;
					countries.Add(countrySelectDTO);
				}

				TripSelectDTO tripSelectDTO = new TripSelectDTO();
				tripSelectDTO.Name = trip.Name;
				tripSelectDTO.Description = trip.Description;
				tripSelectDTO.DateFrom = trip.DateFrom;
				tripSelectDTO.DateTo = trip.DateTo;
				tripSelectDTO.MaxPeople = trip.MaxPeople;
				tripSelectDTO.Clients = clients;
				tripSelectDTO.Countries = countries;

				trips.Add(tripSelectDTO);
			}
			return trips;
		}
	}
}
