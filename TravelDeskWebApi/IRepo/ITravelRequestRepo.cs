using TravelDeskWebApi.Model;
using TravelDeskWebApi.ViewModel;

namespace TravelDeskWebApi.IRepo
{
    public interface ITravelRequestRepo
    {
        //public bool AddTravelRequest(TravelRequest travelRequest);

        //public bool AddAirTicketBooking(AirTicketBooking airTicketBooking);

        //public bool AddHotelBooking(HotelBooking hotelBooking);

        public Task<IEnumerable<Location>> GetAllLocations();

        public Task<IEnumerable<Project>> GetAllProjects();

        public Task<IEnumerable<FlightType>> GetAllFlightType();

        public Task<IEnumerable<BookingType>> GetAllBookingTypes();

        public Task<IEnumerable<MealType>> GetAllMealTypes();

        public Task<IEnumerable<MealPreference>> GetAllMealPreferences();
        public Task<TravelRequest> AddTravelRequest(TravelRequest travelRequest);

        public Task<IEnumerable<TravelRequest>> GetRequestsByUserId(int userId);

        public List<RequestHistoryView> GetViewRequestsByUserId(int userId);

        public Task<TravelRequest> GetTravelRequestByRequestId(int requestId);

        //public Task<HotelBooking> AddHotelBooking(HotelBooking hotelBooking);
        //public Task<AirTicketBooking> AddAirTicketBooking(AirTicketBooking airTicketBooking);
    }
}
