using AutoMapper;
using CV_Manager.DB.Models;

namespace CV_Manager.DB.Repos
{
    public interface IExperienceInformationRepository : IRepository<ExperienceInformation>
    {

    }
    public class ExperienceInformationRepository : Repository<ExperienceInformation>, IExperienceInformationRepository
    {
        public ExperienceInformationRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
