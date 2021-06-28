using SharedTrip.DTOModels.TripModels;
using System.Collections.Generic;

namespace SharedTrip.Services.Contracts
{
    public interface ITripsService
    {
        public List<TripsListViewModel> GetAllTrips();
        public void CreateTrip(TripCreateViewModel model, string userId);
        public TripDetailsViewModel GetTrip(string id);
        public bool AddUserToTrip(string tripId, string userId);
    }
}
