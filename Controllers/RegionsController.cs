using AutoMapper;
using crudapi.Model;
using crudapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace crudapi.Controllers
{
    [ApiController]
    [Route("/regions")]
    public class RegionsController : Controller
    {
        private readonly IRegion _regionRepo;
        private readonly IMapper _mapper;

        public RegionsController(IRegion regionRepo, IMapper mapper)
        {
            _regionRepo = regionRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRegions()
        {
            IEnumerable<RegionTable> regions = await _regionRepo.GetRegions();
            List<Model.DTO.RegionTable> DTORegions = _mapper.Map<List<Model.DTO.RegionTable>>(regions);
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRegion(Guid id)
        {
            Model.RegionTable region = await _regionRepo.GetRegion(id);
            Model.DTO.RegionTable DTORegion = _mapper.Map<Model.DTO.RegionTable>(region);
            return Ok(DTORegion);
        } 
    }
}
