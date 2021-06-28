using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.DTOModels.TripModels;
using SharedTrip.Services;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly Validator validator;
        private readonly TripsService tripsService;

        public TripsController(Validator validator, TripsService tripsService)
        {
            this.validator = validator;
            this.tripsService = tripsService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var trips = this.tripsService.GetAllTrips();

            return View(trips);
        }

        [Authorize]
        public HttpResponse Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(TripCreateViewModel model)
        {
            var validationResult = this.validator.ValidateTrip(model);

            if (validationResult.Any())
            {
                return Redirect("/Trips/Add");
            }

            this.tripsService.CreateTrip(model, this.User.Id);

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var trip = this.tripsService.GetTrip(tripId);

            return View(trip);
        }

        
        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var isAdded = this.tripsService.AddUserToTrip(tripId, this.User.Id);

            if (!isAdded)
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            return Redirect("/Trips/All");
        }
    }
}
