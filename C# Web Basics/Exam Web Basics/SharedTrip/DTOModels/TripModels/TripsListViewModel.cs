using System;

namespace SharedTrip.DTOModels.TripModels
{
    public class TripsListViewModel
    {
        public string Id { get; init; }
        public string StartPoint { get; init; }
        public string EndPoint { get; init; }
        public DateTime DepartureTime { get; init; }
        public int Seats { get; init; }
    }
}
