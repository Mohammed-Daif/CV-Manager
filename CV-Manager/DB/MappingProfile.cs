using AutoMapper;
using CV_Manager.DB.Models;


namespace CV_Manager.DB
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CvDto, CV>().ForMember(dest =>
            dest.PersonalInformation,
            opt => opt.MapFrom(src => new PersonalInformation { CityName = src.CityName, Email = src.Email, MobileNumber = src.MobileNumber, FullName = src.FullName })
            ).ForMember(dest =>
            dest.ExperienceInfoList,
            opt => opt.MapFrom(src => src.ExperienceInfoList)
            );

            CreateMap<CV, CvDto>().ForMember(dest =>
            dest.Email,
            opt => opt.MapFrom(src => src.PersonalInformation.Email)
            ).ForMember(dest =>
            dest.MobileNumber,
            opt => opt.MapFrom(src => src.PersonalInformation.MobileNumber)
            ).ForMember(dest =>
            dest.CityName,
            opt => opt.MapFrom(src => src.PersonalInformation.CityName)
            ).ForMember(dest =>
            dest.FullName,
            opt => opt.MapFrom(src => src.PersonalInformation.FullName)
            ).ForMember(dest =>
            dest.ExperienceInfoList,
            opt => opt.MapFrom(src => src.ExperienceInfoList)
            );

            CreateMap<CV, CvPaginationDto>().ForMember(dest =>
           dest.Email,
           opt => opt.MapFrom(src => src.PersonalInformation.Email)
           ).ForMember(dest =>
           dest.MobileNumber,
           opt => opt.MapFrom(src => src.PersonalInformation.MobileNumber)
           ).ForMember(dest =>
           dest.CityName,
           opt => opt.MapFrom(src => src.PersonalInformation.CityName)
           ).ForMember(dest =>
           dest.FullName,
           opt => opt.MapFrom(src => src.PersonalInformation.FullName)
           ).ForMember(dest =>
           dest.companies,
           opt => opt.MapFrom(src => src.ExperienceInfoList.Count)
           );
            CreateMap<ExperienceInformation, ExperienceInfoDto>().ForMember(dest =>
            dest.CompanyWorkField,
            opt => opt.MapFrom(src => src.CompanyWorkField)
            ).ReverseMap();
        }
    }
}
