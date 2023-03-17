using AutoMapper;
using crudapi.Model;
using crudapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace crudapi.Controllers
{
    [ApiController]
    [Route("/Walks")]
    public class WalksController : Controller
    {
        private readonly IWalk _walk;
        private readonly IMapper _mapper;

        public WalksController(IWalk walk, IMapper mapper)
        {
            _walk = walk;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> AllWalks()
        {
            IEnumerable<Model.WalksTable> Walks = await _walk.AllWalksAsync();
            List<Model.DTO.WalksTable> DTOWalks = _mapper.Map<List<Model.DTO.WalksTable>>(Walks);
            return Ok(DTOWalks);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalk")]
        public async Task<IActionResult> GetWalk(Guid id)
        {
            Model.WalksTable Walk = await _walk.GetWalkAsync(id);
            Model.DTO.WalksTable DTOWalk = _mapper.Map<Model.DTO.WalksTable>(Walk);

            return Ok(DTOWalk);
        }

        [HttpPost]
        [Route("{id:guid}")]
        public async Task<IActionResult> AddWalk([FromBody] Model.DTO.AddWalkRequest walk)
        {
            Model.WalksTable newwalk = _mapper.Map<Model.WalksTable>(walk);
            Model.WalksTable Walk = await _walk.AddWalk(newwalk);
            if (Walk == null)
            {
                return NotFound();
            }

            Model.DTO.AddWalkRequest DTOWalk = _mapper.Map<Model.DTO.AddWalkRequest>(Walk);
            return CreatedAtAction(nameof(GetWalk), new { id = DTOWalk.Length }, DTOWalk);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync(Guid id, Model.DTO.UpdateWalkRequest existingWalk)
        {
            Model.WalksTable ExistingWalk = _mapper.Map<Model.DTO.UpdateWalkRequest, Model.WalksTable>(existingWalk);
            await _walk.UpdateWorkAsync(id, ExistingWalk);
            Model.DTO.UpdateWalkRequest Response = _mapper.Map<Model.DTO.UpdateWalkRequest>(ExistingWalk);
            return Ok(Response);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid id)
        {
            Model.WalksTable walk = await _walk.DeleteWalkAsync(id);
            return Ok(walk);

        }
    }
}
