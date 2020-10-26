using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public class TripsServices :ITipsServices
    {
        private readonly ApplicationDbContext dbContext;

        public TripsServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void Create(AddTripInputModel tripModel)
        {
            var trip = new Trip()
            {
                StartPoint = tripModel.StartPoint,
                EndPoint = tripModel.EndPoint,
                DepartureTime = DateTime.ParseExact(tripModel.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Description = tripModel.Description,
                ImagePath = tripModel.ImagePath,
                Seats = tripModel.Seats,
            };

            this.dbContext.Trips.Add(trip);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            var trips = dbContext.Trips
                .Select(x=> new TripViewModel()
                {
                    Id = x.Id,
                    DepartureTime = x.DepartureTime,
                    EndPoint = x.EndPoint,
                    StartPoint = x.StartPoint,
                    AvailableSeats = x.Seats - x.UserTrips.Count,
                })
                .ToList();

            return trips;
        }

        public TripDetailsViewModel GetDetails(string id)
        {
            var trip = this.dbContext.Trips
                .Where(x => x.Id == id)
                .Select(x => new TripDetailsViewModel()
                {
                    Id = x.Id,
                    DepartureTime = x.DepartureTime,
                    Description = x.Description,
                    EndPoint = x.EndPoint,
                    StartPoint = x.StartPoint,
                    ImagePath = x.ImagePath,
                    Seats = x.Seats,
                    UsedSeats = x.UserTrips.Count,

                })
                .FirstOrDefault();

            return trip;
        }

        public bool AddUserToTrip(string userId, string tripId)
        {
            var userInTrip = dbContext.UserTrips.Any(x => x.UserId == userId && x.TripId == tripId);
            if (userInTrip)
            {
                return false;
            }

            var userTrip = new UserTrip()
            {
                UserId = userId,
                TripId = tripId
            };

            dbContext.UserTrips.Add(userTrip);
            dbContext.SaveChanges();

            return true;
        }

        public bool HasAvailableSeats(string tripId)
        {
            var trip = dbContext.Trips
                .Where(x => x.Id == tripId)
                .Select(x => new {x.Seats, TakenSeats= x.UserTrips.Count })
                .FirstOrDefault();

            var availableSeats = trip.Seats - trip.TakenSeats;
            if (availableSeats <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
