using System.ComponentModel.DataAnnotations;

namespace AidCare_Loginn.Models
{
    public class member
    {
        public int memberID { get; set; }
        [Display(Name = "First Name"), Required, MaxLength(50)]
        [StringLength(30, MinimumLength = 3)]
        public string Firstname { get; set; }
        [StringLength(30, MinimumLength = 3)]

        [Display(Name = "Last Name"), Required, MaxLength(50)]
        public string Lastname { get; set; }
        [Display(Name = "Date Registered"), MaxLength(50)]
        public DateTime DateRegistered { get; set; }
        public ICollection<memberevent> membersevent { get; set; }
        public ICollection<donation> donations { get; set; }

    }
}
