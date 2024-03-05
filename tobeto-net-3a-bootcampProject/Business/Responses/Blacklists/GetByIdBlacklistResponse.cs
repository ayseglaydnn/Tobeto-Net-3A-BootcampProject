namespace Business.Responses.Blacklists
{
    public class GetByIdBlacklistResponse
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public int ApplicantId { get; set; }

    }
}
