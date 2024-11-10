using HotelRoomAvailability.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomAvailability.Models;

namespace HotelRoomAvailability.Services
{
    public static class HotelsService
    {
        public static int Availability(string hotelsFile, string bookingsFile, string hotelId, DateTime date, string roomtype)
        {
            return Availability(hotelsFile, bookingsFile, hotelId, date, date.AddDays(1), roomtype);
        }
        public static int Availability(string hotelsFile, string bookingsFile, string hotelId, DateTime arrival, DateTime departure, string roomtype)
        {
            HotelsRepository hotelsRepo = new HotelsRepository(hotelsFile);
            IEnumerable<Room> hotelRooms = hotelsRepo.GetHotelRooms(hotelId, roomtype);
            int result = hotelRooms.Count();
            BookingsRepository bookingsRepo = new BookingsRepository(bookingsFile);

            int days = (departure - arrival).Days;
            if (days < 1)
                throw new Exception("Departure time must be later than the arrival time.");

            int maxBookingsCount = 0;
            for (int i = 0; i < days; i++)
            {
                DateTime date = arrival.AddDays(i);
                int bookingsCount = bookingsRepo.GetBookingsByDate(date).Where(x => x.hotelId == hotelId && x.roomType == roomtype).Count();
                if (bookingsCount > maxBookingsCount)
                    maxBookingsCount = bookingsCount;
            }
            result -= maxBookingsCount;

            return result;
        }
    }
}
