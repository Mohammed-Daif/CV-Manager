using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CV_Manager.DB
{

    public class CvPaginationDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FullName { get; set; }
        public string CityName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string MobileNumber { get; set; }
        public int companies { get; set; }
    };
    public class CvDto
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FullName { get; set; }
        public string CityName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string MobileNumber { get; set; }
        public List<ExperienceInfoDto> ExperienceInfoList { get; set; }
    };
    public class ExperienceInfoDto { public int? id { get; set; } [Required][MaxLength(20)] public string CompanyName { get; set; } public string CityName { get; set; } public string CompanyWorkField { get; set; } };

}
