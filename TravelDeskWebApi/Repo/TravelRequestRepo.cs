using Microsoft.EntityFrameworkCore;
using System.Web.Http;
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

        public List<HRTravelAdminRequestView> GetViewRequestsForHrTravelAdmin()
        {
            var query =
            (from request in _context.TravelRequests
             join manager in _context.Users on request.ManagerId equals manager.UserId
             join user in _context.Users on request.UserId equals user.UserId
             join bookingType in _context.BookingTypes on request.BookingTypeId equals bookingType.BookingTypeId
             join status in _context.Status on request.StatusId equals status.StatusId
             join deparment in _context.Departments on request.DepartmentId equals deparment.DepartmentId
             where request.StatusId == 2 && request.IsActive == true
             select new HRTravelAdminRequestView
             {
                 RequestId = request.RequestId,
                 ReasonForTravelling = request.ReasonForTravelling,
                 EmployeeName = user.FirstName + " " + user.LastName,   
                 ManagerName = manager.FirstName + " " + manager.LastName,
                 DepartmentName = deparment.DepartmentName,
                 UserId = request.UserId,
                 BookingTypeName = bookingType.BookingTypeName,
                 BookingId = request.BookingId,
             }).ToList();
            return query;
        }

        public AirTicketOnlyView GetAirTicketOnlyView(int requestId)
        {
            var query =
            (from request in _context.TravelRequests
             join manager in _context.Users on request.ManagerId equals manager.UserId
             join bookingType in _context.BookingTypes on request.BookingTypeId equals bookingType.BookingTypeId
             join status in _context.Status on request.StatusId equals status.StatusId
             join user in _context.Users on request.UserId equals user.UserId
             join flight in _context.FlightTypes on request.FlightTypeId equals flight.FlightTypeId
             join department in _context.Departments on request.DepartmentId equals department.DepartmentId 
             join toLocation in _context.Locations on request.To equals toLocation.LocationId
             join fromLocation in _context.Locations on request.From equals fromLocation.LocationId
             where request.RequestId == requestId && request.IsActive == true
             select new AirTicketOnlyView
             {
                 UserId = request.UserId,
                 EmployeeName = user.FirstName + " " + user.LastName,
                 RequestId = request.RequestId,
                 ReasonForTravelling = request.ReasonForTravelling,
                 ManagerName = manager.FirstName + " " + manager.LastName,
                 StatusName = status.StatusName,
                 DepartmentName = department.DepartmentName,
                 BookingTypeName = bookingType.BookingTypeName,
                 AadharNo = request.AadharNo,
                 FlightTypeName = flight.FlightTypeName,
                 To = toLocation.City + ", "+ toLocation.Country,
                 From = fromLocation.City + ", "+ fromLocation.Country,
                 PassportNo = request.PassportNo,
                 FlightDate = request.FlightDate,
                 CreatedOn = request.CreatedOn,
                 ReasonForRejection = request.StatusReason,
                 BookingId = request.BookingId,

             }).FirstOrDefault();
            return query;
        }

        public HotelOnlyRequestView GetHotelOnlyView(int requestId)
        {
            var query =
            (from request in _context.TravelRequests
             join manager in _context.Users on request.ManagerId equals manager.UserId
             join bookingType in _context.BookingTypes on request.BookingTypeId equals bookingType.BookingTypeId
             join status in _context.Status on request.StatusId equals status.StatusId
             join user in _context.Users on request.UserId equals user.UserId
             join department in _context.Departments on request.DepartmentId equals department.DepartmentId
             join mealPreference in _context.MealPreferences on request.MealPreferenceId equals mealPreference.MealPreferenceId
             join mealType in _context.MealTypes on request.MealTypeId equals mealType.MealTypeId
             join hotelLocation in _context.Locations on request.HotelLocationId equals hotelLocation.LocationId
             where request.RequestId == requestId && request.IsActive == true
             select new HotelOnlyRequestView
             {
                 UserId = request.UserId,
                 EmployeeName = user.FirstName + " " + user.LastName,
                 RequestId = request.RequestId,
                 ReasonForTravelling = request.ReasonForTravelling,
                 ManagerName = manager.FirstName + " " + manager.LastName,
                 StatusName = status.StatusName,
                 DepartmentName = department.DepartmentName,
                 BookingTypeName = bookingType.BookingTypeName,
                 AadharNo = request.AadharNo,
                 NumberOfDays = request.NumberOfDays,
                 HotelDate = request.StayDate,
                 MealPreferenceName = mealPreference.MealPreferenceName,
                 MealTypeName = mealType.MealName,
                 HotelLocationName = hotelLocation.City+", "+ hotelLocation.Country,
                 CreatedOn = request.CreatedOn,
                 ReasonForRejection = request.StatusReason,
                 BookingId = request.BookingId,
             }).FirstOrDefault();
            return query;
        }

        public AirTicketHotelBothRequestView GetAirTicketHotelBothView(int requestId)
        {
            var result =
            (from request in _context.TravelRequests
             join manager in _context.Users on request.ManagerId equals manager.UserId
             join bookingType in _context.BookingTypes on request.BookingTypeId equals bookingType.BookingTypeId
             join status in _context.Status on request.StatusId equals status.StatusId
             join user in _context.Users on request.UserId equals user.UserId
             join flight in _context.FlightTypes on request.FlightTypeId equals flight.FlightTypeId
             join department in _context.Departments on request.DepartmentId equals department.DepartmentId
             join mealPreference in _context.MealPreferences on request.MealPreferenceId equals mealPreference.MealPreferenceId
             join mealType in _context.MealTypes on request.MealTypeId equals mealType.MealTypeId
             join hotelLocation in _context.Locations on request.HotelLocationId equals hotelLocation.LocationId
             join toLocation in _context.Locations on request.To equals toLocation.LocationId
             join fromLocation in _context.Locations on request.From equals fromLocation.LocationId
             where request.RequestId == requestId && request.IsActive == true
             select new AirTicketHotelBothRequestView
             {
                 UserId = request.UserId,
                 EmployeeName = user.FirstName + " " + user.LastName,
                 RequestId = request.RequestId,
                 ReasonForTravelling = request.ReasonForTravelling,
                 ManagerName = manager.FirstName + " " + manager.LastName,
                 StatusName = status.StatusName,
                 DepartmentName = department.DepartmentName,
                 BookingTypeName = bookingType.BookingTypeName,
                 AadharNo = request.AadharNo,
                 NumberOfDays = request.NumberOfDays,
                 HotelDate = request.StayDate,
                 MealPreferenceName = mealPreference.MealPreferenceName,
                 MealTypeName = mealType.MealName,
                 HotelLocationName = hotelLocation.City + ", " + hotelLocation.Country,
                 FlightTypeName = flight.FlightTypeName,
                 To = toLocation.City + ", " + toLocation.Country,
                 From = fromLocation.City + ", " + fromLocation.Country,
                 PassportNo = request.PassportNo,
                 FlightDate = request.FlightDate,
                 CreatedOn = request.CreatedOn,
                 ReasonForRejection = request.StatusReason,
                 BookingId = request.BookingId,
             }).FirstOrDefault();
            return result;
        }

        public async Task<TravelRequest> GetTravelRequestByRequestId(int requestId)
        {
            return _context.TravelRequests.FirstOrDefault(r => r.RequestId == requestId);
        }

        public async Task<IEnumerable<ManagerRequestListView>> GetTravelRequestsByManagerId(int managerId)
        {
            var query =
            (from request in _context.TravelRequests
             join manager in _context.Users on request.ManagerId equals manager.UserId
             join bookingType in _context.BookingTypes on request.BookingTypeId equals bookingType.BookingTypeId
             join status in _context.Status on request.StatusId equals status.StatusId
             join user in _context.Users on request.UserId equals user.UserId
             join department in _context.Departments on request.DepartmentId equals department.DepartmentId
             where request.ManagerId == managerId && request.IsActive == true
             select new ManagerRequestListView
             {
                 RequestId = request.RequestId,
                 ReasonForTravelling = request.ReasonForTravelling,
                 EmployeeName = user.FirstName +" "+ user.LastName,
                 UserId = request.UserId,
                 DepartmentName = department.DepartmentName,
                 StatusName = status.StatusName,
                 BookingTypeName = bookingType.BookingTypeName,
             }).ToList();
            return query;
        }


        public async Task<bool> UpdateStatusAndReason(StatusAndReasonView statusAndReason)
        {
           var request = _context.TravelRequests.FirstOrDefault(r => r.RequestId == statusAndReason.RequestId);
            if(request == null)
            {
                return false;
            }
            else
            {
                request.StatusId= statusAndReason.StatusId;
                request.StatusReason = statusAndReason.StatusReason;
                request.UpdatedOn = DateTime.Now;
                request.UpdatedBy = statusAndReason.UpdatedBy;

                _context.TravelRequests.Update(request);
                _context.SaveChanges();
                return true;
            }
        }

        
        public async Task<bool> DeleteRequest(int requestId)
        {
            var request = _context.TravelRequests.FirstOrDefault(r => r.RequestId == requestId);

            if(request == null)
            {
                return false;
            }
            else
            {
                request.IsActive = false;
                _context.TravelRequests.Update(request);
                _context.SaveChanges();
                return true;
            }
            
        }

        public async Task<bool> GenerateBookingId(int requestId)
        {
            var request = _context.TravelRequests.FirstOrDefault(r => r.RequestId == requestId);
            if( request == null)
            {
                return false;
            }
            else
            {
                Random rnd = new Random();
                request.BookingId = rnd.Next();
                _context.TravelRequests.Update(request);
                _context.SaveChanges();
                return true;
            } 
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
