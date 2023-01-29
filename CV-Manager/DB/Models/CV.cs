using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV_Manager.DB.Models
{
    public class CV : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Column("Personal_Information_Id")]
        public int PersonalInformationId { get; set; }
        public virtual PersonalInformation PersonalInformation { get; set; }
        public virtual ICollection<ExperienceInformation> ExperienceInfoList { get; set; }
    }
}
