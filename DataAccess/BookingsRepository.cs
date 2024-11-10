using HotelRoomAvailability.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelRoomAvailability.DataAccess
{
    internal class BookingsRepository
    {
        private readonly string _filePath;
        public BookingsRepository(string filePath)
        {
            _filePath = filePath;
        }
        public IEnumerable<Booking> GetAllBookings()
        {
            string hotelsFileText = File.ReadAllText(_filePath);
            var bookings =  JsonSerializer.Deserialize<IEnumerable<Booking>>(hotelsFileText);
            if (bookings is null)
            {
                throw new Exception("Error deserializing bookings file");
            }
            return bookings;
        }

        //public IEnumerable<Booking>? GetBookingsByDate(string filePath, DateTime arrival, DateTime departure)
        //{
        //    var bookings = GetAllBookings(filePath);
        //    return bookings?.Where(x => DateTime.ParseExact(x.arrival, "yyyyMMdd", null) >= arrival && DateTime.ParseExact(x.departure, "yyyyMMdd", null) <= departure);
        //}
        public IEnumerable<Booking> GetBookingsByDate(DateTime date)
        {
            var bookings = GetAllBookings();
            return bookings.Where(x => DateTime.ParseExact(x.arrival, "yyyyMMdd", null).Date <= date.Date && DateTime.ParseExact(x.departure, "yyyyMMdd", null).Date > date.Date);
        }
    }
}
