using AutoMapper;
using CV_Manager.DB.Models;

namespace CV_Manager.DB.Repos
{
    public interface ICVRepository : IRepository<CV>
    {

    }
    public class CVRepository : Repository<CV>, ICVRepository
    {
        public CVRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
