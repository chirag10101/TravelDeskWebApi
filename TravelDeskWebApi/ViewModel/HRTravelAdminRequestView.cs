namespace TravelDeskWebApi.ViewModel
{
    public class HRTravelAdminRequestView
    {
        public int RequestId { get; set; }
        public string EmployeeName { get; set; }
        public int UserId { get; set; }
        public string ManagerName { get; set; }
        public string ReasonForTravelling { get; set; }
        public string BookingTypeName { get; set; }
        public string DepartmentName { get; set; }
    }
}
