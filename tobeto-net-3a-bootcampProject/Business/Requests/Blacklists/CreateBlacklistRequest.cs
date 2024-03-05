

namespace Business.Requests.Blacklists
{
    public class CreateBlacklistRequest
    {
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public int ApplicantId { get; set; }
    }
}
