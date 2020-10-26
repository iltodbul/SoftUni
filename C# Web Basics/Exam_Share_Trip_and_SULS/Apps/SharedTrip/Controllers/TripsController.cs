using System;
using System.Globalization;
using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITipsServices tipsServices;

        public TripsController(ITipsServices tipsServices)
        {
            this.tipsServices = tipsServices;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trips = tipsServices.GetAll();
            return this.View(trips);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trip = this.tipsServices.GetDetails(tripId);
            return this.View(trip);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            if (!tipsServices.HasAvailableSeats(tripId))
            {
                return Error("No seats available");
            }

            var userId = GetUserId();
            if (!this.tipsServices.AddUserToTrip(userId, tripId))
            {
                return Redirect("/Trips/Details?tripId=" + tripId);
            }
            return Redirect("/Trips/All");
        }

        [HttpPost]
        public HttpResponse Add(AddTripInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(model.StartPoint))
            {
                return this.Error("Invalid start point");
            }

            if (string.IsNullOrEmpty(model.EndPoint))
            {
                return this.Error("Invalid end point");
            }

            if (model.Seats < 2 && model.Seats > 6)
            {
                return this.Error("Seats should be between 2 and 6");
            }

            if (string.IsNullOrEmpty(model.Description) ||model.Description.Length > 80)
            {
                return this.Error("Description is required and must by max 80 characters length");
            }

            if (!DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                return this.Error("Departure time must be in dd.MM.yyyy HH:mm format");
            }

            this.tipsServices.Create(model);

            return this.Redirect("/Trips/All");
        }
    }
}
