using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SharedTrip.ViewModels.Trips
{
    public class TripViewModel
    {
        public string Id { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public DateTime DepartureTime { get; set; }

        public string DepartureTimeAsString => DepartureTime.ToString(CultureInfo.CurrentCulture);
        //public int AvailableSeats => this.Seats - this.UsedSeats;
        public int AvailableSeats { get; set; }
        public int Seats { get; set; }
        public int UsedSeats { get; set; }
    }
}
