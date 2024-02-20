namespace TravelDeskWebApi.ViewModel
{
    public class AirTicketOnlyView
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public string EmployeeName {  get; set; }
        public string ReasonForTravelling { get; set; }
        public string BookingTypeName { get; set; }
        public string ManagerName { get; set; }
        public string DepartmentName { get; set; }
        public string AadharNo { get; set; }
        public string FlightTypeName { get; set; }
        public string To {  get; set; }
        public string From { get; set; }
        public string PassportNo { get; set; }
        public DateTime? FlightDate { get; set; }

        public string StatusName { get; set; }
        public DateTime CreatedOn { get; set; }

        public string ReasonForRejection { get; set; }

    }
}
