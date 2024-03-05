

namespace Business.Responses.Blacklists
{
    public class CreateBlacklistResponse
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public int ApplicantId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
