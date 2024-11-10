# HotelRoomAvailability

## Requirements
- .NET SDK: Version 8.0 or later
- Input Data Files: Two JSON files, one for hotel data (hotels.json) and one for booking data (bookings.json), containing structured data on hotels and reservations, respectively

## Installation and Building
1. Clone the Repository:
`git clone https://github.com/your-repo/HotelRoomAvailability.git`
2. Navigate to the Project Directory:
`cd HotelRoomAvailability`
3. Build the Application: Run the following command to build the application:
`dotnet build`
4. Run the Application: Run the application with the required data files:
`dotnet run -- --hotels hotels.json --bookings bookings.json`



## Usage
Run the program from the command line using:

HotelRoomAvailability --hotels hotels.json --bookings bookings.json
The program will then load hotel and booking data from the specified files and display a prompt for user input.

To check availability for a particular hotel, room type, and date range, use the following command format in the console:

`Availability(HOTEL_ID, DATE, ROOM_TYPE)`
or
`Availability(HOTEL_ID, START_DATE-END_DATE, ROOM_TYPE)`
Parameters
- HOTEL_ID: Identifier for the hotel (e.g., H1).
- DATE: Date in YYYYMMDD format for single-day queries.
- START_DATE-END_DATE: Date range in YYYYMMDD-YYYYMMDD format for multi-day queries.
- ROOM_TYPE: Room type code (e.g., SGL for single, DBL for double).

Examples:
```
Availability(H1, 20240901, SGL)
Availability(H1, 20240901-20240903, DBL)
```

Output: The program will display the availability count for the specified room type and date range. A negative count indicates overbookings.

Exit: To end the program, simply enter a blank line.


## File Formats

### hotels.json
```
[ 
    {        
        "id": "H1", 
        "name": "Hotel California",
        "roomTypes":
        [ 
            { 
                "code": "SGL",  
                "description": "Single Room",
                "amenities": ["WiFi",
                "TV"],
                "features": ["Non-smoking"]
            },
            { 
                "code": "DBL", 
                "description": "Double Room",
                "amenities": ["WiFi",
                "TV", "Minibar"],
                "features": ["Non-smoking", "Sea View"]
            }
        ],
        "rooms": 
        [           
            {    
                "roomType":
                "SGL",    
                "roomId":
                "101"  
            },  
            {      
                "roomType":
                "SGL",    
                "roomId":
                "102" 
            },
            {     
                "roomType":
                "DBL",      
                "roomId":
                "201"   
            },    
            {         
                "roomType":
                "DBL",        
                "roomId":
                "202"  
            }
        ]
    } 
] 
```

### bookings.json
```
[
    {
        "hotelId": "H1",
        "arrival": "20240901",
        "departure": "20240903",
        "roomType": "DBL",
        "roomRate": "Prepaid"
    },
    {
        "hotelId": "H1",
        "arrival": "20240902",
        "departure": "20240905",
        "roomType": "SGL",
        "roomRate": "Standard"
    }
] 
```
