using Microsoft.EntityFrameworkCore;
using TravelDeskWebApi.Context;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Model;
using TravelDeskWebApi.ViewModel;

namespace TravelDeskWebApi.Repo
{
    public class TravelRequestRepo : ITravelRequestRepo
    {
        TravelDbContext _context;
        public TravelRequestRepo( TravelDbContext context )
        {
            _context = context;
        }
        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<IEnumerable<FlightType>> GetAllFlightType()
        {
            return await _context.FlightTypes.ToListAsync();
        }

        public async Task<IEnumerable<BookingType>> GetAllBookingTypes()
        {
            return await _context.BookingTypes.ToListAsync();
        }

        public async Task<IEnumerable<MealType>> GetAllMealTypes()
        {
            return await _context.MealTypes.ToListAsync();
        }

        public async Task<IEnumerable<MealPreference>> GetAllMealPreferences()
        {
            return await _context.MealPreferences.ToListAsync();
        }

        public async Task<TravelRequest> AddTravelRequest(TravelRequest travelRequest)
        {
            if (travelRequest == null)
            {
                return null;
            }
            else
            {
                travelRequest.CreatedOn = DateTime.Now;
                travelRequest.IsActive = true;
                travelRequest.StatusId = 1;
                _context.TravelRequests.Add(travelRequest);
                await _context.SaveChangesAsync();
                return travelRequest;
            }
            
        }

        public async Task<IEnumerable<TravelRequest>> GetRequestsByUserId(int userId)
        {
            return _context.TravelRequests.Where(u=>u.UserId==userId).ToList();
        }

        public List<RequestHistoryView> GetViewRequestsByUserId(int userId)
        {
            var query =
            (from request in _context.TravelRequests
             join manager in _context.Users on request.ManagerId equals manager.UserId
             join bookingType in _context.BookingTypes on request.BookingTypeId equals bookingType.BookingTypeId
             join status in _context.Status on request.StatusId equals status.StatusId
             where request.UserId == userId && request.IsActive == true
             select new RequestHistoryView
             {
                 RequestId = request.RequestId,
                 ReasonForTravelling = request.ReasonForTravelling,
                 ManagerName = manager.FirstName + " " + manager.LastName,
                 StatusName = status.StatusName,
                 BookingTypeName = bookingType.BookingTypeName,
             }).ToList();
            return query;
        }

        public async Task<TravelRequest> GetTravelRequestByRequestId(int requestId)
        {
            return _context.TravelRequests.FirstOrDefault(r => r.RequestId == requestId);
        }

        //public async Task<HotelBooking> AddHotelBooking(HotelBooking hotelBooking)
        //{
        //    if (hotelBooking == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        hotelBooking.CreatedOn = DateTime.Now;
        //        hotelBooking.IsActive = true;

        //        _context.HotelBookings.Add(hotelBooking);
        //        await _context.SaveChangesAsync();
        //        return hotelBooking;
        //    }
        //}

        //public async Task<AirTicketBooking> AddAirTicketBooking(AirTicketBooking airTicketBooking)
        //{
        //    if (airTicketBooking == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        airTicketBooking.CreatedOn = DateTime.Now;
        //        airTicketBooking.IsActive = true;
        //        _context.AirTicketBookings.Add(airTicketBooking);
        //        await _context.SaveChangesAsync();
        //        return airTicketBooking;
        //    }   
        //}
    }
}
