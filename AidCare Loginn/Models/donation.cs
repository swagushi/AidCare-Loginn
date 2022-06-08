using System.ComponentModel.DataAnnotations;

namespace AidCare_Loginn.Models
{
    public class donation
    {
        public int donationID { get; set; }
        [StringLength(250, MinimumLength = 1)]

        [Display(Name = "Donation Description"), Required, MaxLength(50)]
        public string DonationDescription { get; set; }
        [Display(Name = "Donation Amount"),]
        [Range(5, 10000, ErrorMessage = "Please use values between $5 to $10,000")]
        public int donationAmount { get; set; }


        public member member { get; set; }
    }
}
