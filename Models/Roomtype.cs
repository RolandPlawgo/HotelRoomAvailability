namespace HotelRoomAvailability.Models
{
    public class Roomtype
    {
        public string code { get; set; }
        public string description { get; set; }
        public List<string> amenities { get; set; }
        public List<string> features { get; set; }
    }
}
