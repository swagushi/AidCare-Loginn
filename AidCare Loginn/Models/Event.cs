using System.ComponentModel.DataAnnotations;

namespace AidCare_Loginn.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [Display(Name = "Event Name"), Required, MaxLength(50)]
        [StringLength(30, MinimumLength = 10)]
        public string EventName { get; set; }
        [Display(Name = "Event Location"), Required, MaxLength(50)]
        [StringLength(30, MinimumLength = 10)]
        public string EventLocation { get; set; }
        [Display(Name = "Event Date and Time"),]

        public DateTime EventDateTime { get; set; }
        public ICollection<memberevent> memberevent { get; set; }

    }
}
