namespace TravelDeskWebApi.ViewModel
{
    public class HotelOnlyRequestView
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public string EmployeeName { get; set; }
        public string ReasonForTravelling { get; set; }
        public string BookingTypeName { get; set; }
        public string ManagerName { get; set; }
        public string DepartmentName { get; set; }
        public string AadharNo { get; set; }
        public int? NumberOfDays { get; set; }
        public DateTime? HotelDate { get; set; }
        public string HotelLocationName { get; set; }
        public string MealTypeName { get; set; }
        public string MealPreferenceName { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ReasonForRejection { get; set; }

        public int? BookingId { get; set; }
    }
}
