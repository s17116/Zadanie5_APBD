using Microsoft.AspNetCore.Mvc;
using zadanie5.Models.DTO;
using zadanie5.Services.Implementations;
using zadanie5.Services.Interfaces;

namespace zadanie5.Controllers
{
	[ApiController]
	[Route("api/trips")]
	public class TripController : ControllerBase
	{
        private readonly Context _context;
        private readonly ITripService _ItripService;
        
        public TripController(Context context, ITripService tripService)
        {
            this._context = context;
            this._ItripService = tripService;
        }

        [HttpGet]
        public async Task <IActionResult> GetTrip()
        {
            var trips = await _ItripService.GetTrips();
            return Ok(trips);
        }

        [HttpPost("{idTrip}/clients")]
        public async Task <IActionResult> AddClientToTrip(Client_TripInsertDTO client_TripInsertDTO, int idTrip) 
        {
            var isOK = await _ItripService.AddClientToTrip(client_TripInsertDTO, idTrip);
            if (isOK) 
            {
                return Ok("client to trip added");
            }
            return  BadRequest("Error"); 
        }
    }
}
