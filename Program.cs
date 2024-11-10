using HotelRoomAvailability.DataAccess;
using HotelRoomAvailability.Models;
using HotelRoomAvailability.Services;
using System.Globalization;
using System.IO;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelRoomAvailability
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hotelsFile = "";
            string bookingsFile = "";
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--hotels" && i + 1 < args.Length)
                {
                    hotelsFile = args[i + 1];
                    i++;
                }
                else if (args[i] == "--bookings" && i + 1 < args.Length)
                {
                    bookingsFile = args[i + 1];
                    i++;
                }
            }

            if (hotelsFile == "")
            {
                Console.WriteLine("No hotels file path provided. Use the --hotels parameter to specify the path to a json file containing information about hotels.");
                return;
            }

            if (bookingsFile == "")
            {
                Console.WriteLine("No bookings file path provided. Use the --bookings parameter to specify the path to a json file containing information about bookings.");
                return;
            }


            while (true)
            {
                try
                {
                    string? input = Console.ReadLine();
                    if (input is null)
                    {
                        Console.WriteLine("Invalid input");
                    }
                    if (input == "")
                    {
                        return;
                    }
                    int? availableRoomsCount = CheckForRoomAvailabilityRequest(input, hotelsFile, bookingsFile);
                    if (availableRoomsCount is not null)
                    {
                        Console.WriteLine(availableRoomsCount.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private static int? CheckForRoomAvailabilityRequest(string input, string hotelsFile, string bookingsFile)
        {
            if (input.StartsWith("Availability(") && input.EndsWith(")"))
            {
                // Remove "Availability(" at the beginning and ")" at the end
                string parameters = input.Substring(13, input.Length - 14);

                string[] parts = parameters.Split(',');

                if (parts.Length == 3)
                {
                    string hotelId = parts[0].Trim();
                    string dateString = parts[1].Trim();
                    string roomType = parts[2].Trim();

                    if (dateString.Contains('-'))
                    {
                        string arrivalString = dateString.Split('-')[0];
                        string departureString = dateString.Split('-')[1];
                        DateTime arrival;
                        DateTime departure;
                        if (DateTime.TryParseExact(arrivalString, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out arrival) && 
                            DateTime.TryParseExact(departureString, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out departure))
                        {
                            return HotelsService.Availability(hotelsFile, bookingsFile, hotelId, arrival, departure, roomType);
                        }
                        else
                        {
                            throw new Exception("Invalid date format. Please use the format 'yyyyMMdd'.");
                        }
                    }
                    else
                    {
                        DateTime date;
                        if (DateTime.TryParseExact(dateString, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                        {
                            return HotelsService.Availability(hotelsFile, bookingsFile, hotelId, date, roomType);
                        }
                        else
                        {
                            throw new Exception("Invalid date format. Please use the format 'yyyyMMdd'.");
                        }

                    }
                }
                else
                {
                    throw new Exception("Invalid number of parameters. The Avaliability method takes three arguments: hotel id, date, room type");
                }
            }
            else
            {
                return null;
            }
        }
    }
}
