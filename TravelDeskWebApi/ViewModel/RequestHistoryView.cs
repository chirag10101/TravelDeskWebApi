namespace TravelDeskWebApi.ViewModel
{
    public class RequestHistoryView
    {
        public int RequestId { get; set; }  
        public string ReasonForTravelling { get; set; }
        public string ManagerName { get; set; }
        public string StatusName { get; set; }
        public string BookingTypeName { get; set; } 
    }
}
