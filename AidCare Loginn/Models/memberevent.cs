namespace AidCare_Loginn.Models
{
    public class memberevent
    {
        public int membereventId { get; set; }
        public string membereventName { get; set; }
        public string DateRegistered { get; set; }
        public int memberId { get; set; }
        public int eventId { get; set; }
        public member member { get; set; }
        public Event Event { get; set; }
    }
}
