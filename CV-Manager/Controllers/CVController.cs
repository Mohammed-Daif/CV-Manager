using CV_Manager.DB;
using CV_Manager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace CV_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : ControllerBase
    {
        private readonly CVService _cVService;
        public CVController(CVService cVService)
        {
            _cVService = cVService;
        }
        [HttpGet("{index}/{size}")]
        public PaginationResult<CvPaginationDto> Get(int index, int size)
        {
            return _cVService.GetPagination(index, size);
        }

        [HttpGet("{id}")]
        public async Task<CvDto> GetById(int id)
        {
            return await _cVService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<CvDto>> Post([FromBody] CvDto value)
        {
            try
            {
                var res = await _cVService.Add(value);
                return CreatedAtAction(nameof(GetById), new { Id = res.Id }, res);
            }
            catch (System.Exception exception)
            {

                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CvDto dto)
        {
            await _cVService.Update(id, dto);

        }

        [HttpDelete("{id}")]
        public async Task<CvDto> Delete(int id)
        {
            return await _cVService.Remove(id);
        }
    }
}
