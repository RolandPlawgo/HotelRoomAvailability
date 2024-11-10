using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomAvailability.Models
{
    internal class Booking
    {
        public string hotelId { get; set; }
        public string arrival { get; set; }
        public string departure { get; set; }
        public string roomType { get; set; }
        public string roomRate { get; set; }
    }
}
