using AutoMapper;
using CV_Manager.DB;
using CV_Manager.DB.Models;
using CV_Manager.DB.Repos;
using System.Linq;
using System.Threading.Tasks;

namespace CV_Manager.Services
{
    public class CVService
    {
        private readonly CVRepository _CVRepository;
        protected readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public CVService(CVRepository cVRepository, IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _CVRepository = cVRepository;
            _mapper = mapper;
        }
        public PaginationResult<CvPaginationDto> GetPagination(int index, int size)
        {
            return _CVRepository.GetAllPagination<CvPaginationDto>(cv => cv.Id, index, size);
        }
        public async Task<CvDto> GetById(int Id)
        {
            return await _CVRepository.Get<CvDto>(Id);
        }
        public async Task<CvDto> Add(CvDto cvDto)
        {
            CV cV = _mapper.Map<CV>(cvDto);
            var res = await _CVRepository.Add(cV);

            return _mapper.Map<CvDto>(res.Entity);
        }
        public async Task Update(int Id, CvDto cvDto)
        {
            var entity = await _CVRepository.Get(Id, x => x.ExperienceInfoList, x => x.PersonalInformation);

            entity.Name = cvDto.Name;
            entity.PersonalInformation.Email = cvDto.Email;
            entity.PersonalInformation.FullName = cvDto.FullName;
            entity.PersonalInformation.CityName = cvDto.CityName;
            entity.PersonalInformation.MobileNumber = cvDto.MobileNumber;

            var newInnerIds = cvDto.ExperienceInfoList.Select(x => x.id).ToList();
            var added = cvDto.ExperienceInfoList.Where(x => x.id == null);
            var removed = entity.ExperienceInfoList.Where(x => !newInnerIds.Contains(x.Id));
            var updated = entity.ExperienceInfoList.Where(x => !removed.Contains(x));
            foreach (var item in updated)
            {
                var entityItem = entity.ExperienceInfoList.Where(x => x.Id == item.Id).First();
                var newItem = cvDto.ExperienceInfoList.Where(x => x.id == item.Id).First();
                entityItem.CityName = newItem.CityName;
                entityItem.CompanyName = newItem.CompanyName;
                entityItem.CompanyWorkField = newItem.CompanyWorkField;
            }
            foreach (var item in removed)
            {
                entity.ExperienceInfoList.Remove(item);
            }
            foreach (var item in added)
            {
                entity.ExperienceInfoList.Add(_mapper.Map<ExperienceInformation>(item));
            }
            await _CVRepository.Update(entity);

        }
        public async Task<CvDto> Remove(int id)
        {

            var res = await _CVRepository.Remove(id);

            return _mapper.Map<CvDto>(res.Entity);
        }
    }
}
