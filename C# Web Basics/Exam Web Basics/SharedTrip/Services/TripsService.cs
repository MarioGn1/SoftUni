using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.DTOModels.TripModels;
using SharedTrip.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext context;

        public TripsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CreateTrip(TripCreateViewModel model, string userId)
        {
            var trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.Parse(model.DepartureTime),
                Seats = model.Seats,
                ImagePath = model.ImagePath,
                Description = model.Description,
                
            };

            trip.UserTrips.Add(new UserTrip() { UserId = userId });

            this.context.Trips.Add(trip);
            this.context.SaveChanges();
        }

        public List<TripsListViewModel> GetAllTrips()
        {
            var trips = this.context.Trips
                .Select(t => new TripsListViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime,
                    Seats = t.Seats
                })
                .ToList();

            return trips;
        }

        public TripDetailsViewModel GetTrip(string id)
        {
            var trip = this.context.Trips.FirstOrDefault(t => t.Id == id);
            return new TripDetailsViewModel()
            {
                Id = trip.Id,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime.ToString(),
                Seats = trip.Seats,
                ImagePath = trip.ImagePath,
                Description = trip.Description
            };
        }

        public bool AddUserToTrip(string tripId, string userId)
        {
            var isAlreadyJoinTrip = this.context.UserTrips.Any(t => t.TripId == tripId && t.UserId == userId);
            if (isAlreadyJoinTrip)
            {
                return false;
            }
            else
            {
                var trip = this.context.Trips.FirstOrDefault(t => t.Id == tripId);

                trip.Seats = trip.Seats - 1;

                context.UserTrips.Add(new UserTrip() { UserId = userId, TripId = tripId });

                context.SaveChanges();

                return true;
            }
        }
    }
}
