using AutoMapper;
using crudapi.Model;
using crudapi.Model.DTO;
using crudapi.Repositories;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using System.Web.Mvc;

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
            IEnumerable<Model.RegionTable> regions = await _regionRepo.GetRegions();
            List<Model.DTO.RegionTable> DTORegions = _mapper.Map<List<Model.DTO.RegionTable>>(regions);
            return Ok(DTORegions);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRegion(Guid id)
        {
            if (GetRegionValidation(id))
            {
                Model.RegionTable region = await _regionRepo.GetRegion(id);
                if (region != null)
                {
                    Model.DTO.RegionTable DTORegion = _mapper.Map<Model.DTO.RegionTable>(region);
                    return Ok(DTORegion);
                }
            }
            return StatusCode(400, "This id does not have an account with us");
        }

        [HttpPost]
        [Route("new_region")]
        [ActionName("AddRegion")]
        public async Task<IActionResult> AddRegion(AddRegionRequest newRegion)
        {
            if (AddRegionValidation(newRegion))
            {
                //Request DTO to domain model
                Model.RegionTable NewRegion = new Model.RegionTable()
                {
                    Code = newRegion.Code,
                    Name = newRegion.Name,
                    Area = newRegion.Area,
                    Latitude = newRegion.Latitude,
                    Longitude = newRegion.Longitude,
                    Population = newRegion.Population,
                };

                //Pass details to repository

                IEnumerable<Model.RegionTable> region = await _regionRepo.AddRegion(NewRegion);

                //Convert back to DTO

                Model.DTO.RegionTable DTORegion = new Model.DTO.RegionTable()
                {
                    Id = NewRegion.Id,
                    Code = NewRegion.Code,
                    Name = NewRegion.Name,
                    Area = NewRegion.Area,
                    Latitude = NewRegion.Latitude,
                    Longitude = NewRegion.Longitude,
                    Population = NewRegion.Population,
                };
                return CreatedAtAction(nameof(AddRegion), new {id=DTORegion.Id}, region);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            //Get region from database
            Model.RegionTable region = await _regionRepo.DeleteRegion(id);

            //If null return NotFound()
            if (region == null)
            {
                return NotFound();
            }

            //Convert back to DTO Model
            Model.DTO.RegionTable DTORegion = _mapper.Map<Model.DTO.RegionTable>(region);
            return Ok(DTORegion); 
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute]Guid id, [FromBody]UpdateRegionRequest existingRegion)
        {

            Model.RegionTable region = _mapper.Map<Model.RegionTable>(existingRegion);

            Model.RegionTable Updateregion = await _regionRepo.UpdateRegion(id, region);

            if (region == null)
            {
                return NotFound();
            }

            Model.DTO.UpdateRegionRequest DTORegion = _mapper.Map<Model.DTO.UpdateRegionRequest>(Updateregion);

            return Ok(DTORegion);
        }
    

        #region Private methods

        private bool GetRegionValidation (Guid id)
        {
            if (id.ToString().Length != 32 && string.IsNullOrWhiteSpace(id.ToString()))
            {
                ModelState.AddModelError(nameof(Model.RegionTable.Id),
                    $"{nameof(Model.RegionTable.Id)} cannot accept the provided Id data");
                return false;
            }
            return true;
        }

        private bool AddRegionValidation (AddRegionRequest newRegion)
        {
            if (string.IsNullOrWhiteSpace(newRegion.Code) 
                || newRegion.Code.Contains(" "))
            {
                ModelState.AddModelError(nameof(newRegion.Code), $"{nameof(newRegion.Code)} is invalid");
                return false;
            }

            else if (string.IsNullOrWhiteSpace(newRegion.Name)
                || newRegion.Name.Contains(" "))
            {
                ModelState.AddModelError(nameof(newRegion.Name), $"{nameof(newRegion.Name)} is invalid");
                return false;
            }
            else if (newRegion.Area<=0)
            {
                ModelState.AddModelError(nameof(newRegion.Area),
                    $"{nameof(newRegion.Area)} cannot be less than or equal to 0");
                return false;
            }
            else if (newRegion.Latitude <= 0)
            {
                ModelState.AddModelError(nameof(newRegion.Latitude),
                    $"{nameof(newRegion.Latitude)} cannot be less than or equal to 0");
                return false;
            }
            else if (newRegion.Longitude <= 0)
            {
                ModelState.AddModelError(nameof(newRegion.Longitude),
                    $"{nameof(newRegion.Longitude)} cannot be less than or equal to 0");
                return false;
            }
            else if (newRegion.Population <= 0)
            {
                ModelState.AddModelError(nameof(newRegion.Population),
                    $"{nameof(newRegion.Population)} cannot be less than or equal to 0");
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

    }

}
