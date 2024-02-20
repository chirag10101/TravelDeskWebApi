using TravelDeskWebApi.Model;
using TravelDeskWebApi.ViewModel;

namespace TravelDeskWebApi.IRepo
{
    public interface ITravelRequestRepo
    {
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
        public AirTicketOnlyView GetAirTicketOnlyView(int requestId);
        public HotelOnlyRequestView GetHotelOnlyView(int requestId);
        public AirTicketHotelBothRequestView GetAirTicketHotelBothView(int requestId);
        public Task<IEnumerable<ManagerRequestListView>> GetTravelRequestsByManagerId(int managerId);
        public Task<bool> UpdateStatusAndReason(StatusAndReasonView statusAndReason);
        public Task<bool> DeleteRequest(int requestId);
        public List<HRTravelAdminRequestView> GetViewRequestsForHrTravelAdmin();
        public Task<bool> GenerateBookingId(int requestId);
    }
}
