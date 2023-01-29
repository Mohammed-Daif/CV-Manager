using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV_Manager.DB.Models
{
    public class ExperienceInformation : BaseModel
    {
        [Required]
        [MaxLength(20)]
        public string CompanyName { get; set; }
        [Column("City")]
        public string CityName { get; set; }
        [Column("CompanyField")]
        public string CompanyWorkField { get; set; }

        public virtual CV CandidateCV { get; set; }
    }
}
