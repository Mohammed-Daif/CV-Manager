using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV_Manager.DB.Models
{

    [Index(nameof(MobileNumber))]
    public class PersonalInformation : BaseModel
    {
        [Required]
        public string FullName { get; set; }
        public string CityName { get; set; }
        [EmailAddress]

        public string Email { get; set; }
        [Required]
        [Phone]
        public string MobileNumber { get; set; }
        public virtual CV CandidateCV { get; set; }

    }
}
