namespace TravelDeskWebApi.ViewModel
{
    public class StatusAndReasonView
    {
        public int RequestId { get; set; }
        public int StatusId { get; set; }
        public string? StatusReason { get; set; }

        public int UpdatedBy { get; set; }  

    }
}
