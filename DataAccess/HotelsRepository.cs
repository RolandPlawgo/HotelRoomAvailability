using HotelRoomAvailability.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelRoomAvailability.DataAccess
{
    internal class HotelsRepository
    {
        private readonly string _filePath;
        public HotelsRepository(string filePath)
        {
            _filePath = filePath;
        }
        public IEnumerable<Hotel> GetAllHotels()
        {
            string hotelsFileText = File.ReadAllText(_filePath);
            var hotels = JsonSerializer.Deserialize<IEnumerable<Hotel>>(hotelsFileText);
            if (hotels is null)
            {
                throw new Exception("Error deserializing hotels file");
            }
            return hotels;
        }

        public Hotel? GetHotelById(string hotelId)
        {
            return GetAllHotels()?.Where(x => x.id == hotelId).FirstOrDefault();
        }

        public IEnumerable<Room> GetHotelRooms(string hotelId, string roomType)
        {
            var hotel = GetHotelById(hotelId);
            if (hotel is null)
            {
                throw new Exception("Hotel not found");
            }
            return hotel.rooms.Where(x => x.roomType == roomType);
        }
    }
}
