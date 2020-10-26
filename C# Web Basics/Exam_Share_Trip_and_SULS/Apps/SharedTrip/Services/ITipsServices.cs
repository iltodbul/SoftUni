using System.Collections.Generic;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public interface ITipsServices
    {
        void Create(AddTripInputModel tripModel);

        IEnumerable<TripViewModel> GetAll();

        TripDetailsViewModel GetDetails(string id);

        bool AddUserToTrip(string userId, string tripId);

        bool HasAvailableSeats(string tripId);
    }
}
