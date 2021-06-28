using System;

namespace SharedTrip.DTOModels.TripModels
{
    public class TripDetailsViewModel
    {
        public string Id { get; set; }
        public string StartPoint { get; init; }
        public string EndPoint { get; init; }
        public string DepartureTime { get; init; }
        public int Seats { get; init; }
        public string ImagePath { get; init; }
        public string Description { get; init; }
    }
}
