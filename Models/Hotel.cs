using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomAvailability.Models
{
    internal class Hotel
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Roomtype> roomTypes { get; set; }
        public List<Room> rooms { get; set; }
    }
}
