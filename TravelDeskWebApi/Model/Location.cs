namespace TravelDeskWebApi.Model
{
    public class Location
    {
        public int LocationId { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

       //public ICollection<HotelBooking>? HotelBookings { get; set; }
       // public ICollection<TravelRequest> TravelRequest { get; set; }
    }
}
