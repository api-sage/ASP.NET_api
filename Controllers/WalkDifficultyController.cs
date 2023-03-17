using AutoMapper;
using crudapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace crudapi.Controllers
{
    [ApiController]
    [Route("/walkDifficulty")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficulty _walkDifficulty;
        private readonly IMapper _mapper;
        public WalkDifficultyController(IWalkDifficulty walkDifficulty, IMapper mapper)
        {
            _walkDifficulty = walkDifficulty;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Model.WalksDifficultyTable> Walks = await _walkDifficulty.GetAllAsync();
            List<Model.DTO.WalksDifficulty> Response = _mapper.Map<List<Model.DTO.WalksDifficulty>>(Walks);
            return Ok(Response);
        }
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficulty")]
        public async Task<IActionResult> GetWalkDifficulty(Guid id)
        {
            Model.WalksDifficultyTable walk = await _walkDifficulty.GetWalkDifficultyAsync(id);
            Model.DTO.WalksDifficulty Response = _mapper.Map<Model.DTO.WalksDifficulty>(walk);
            return Ok(Response);

        }

        [HttpPost]
        public async Task<IActionResult> AddWalkDifficulty(Model.DTO.AddWalkDifficultyRequest walk)
        {

            Model.WalksDifficultyTable newEntry = _mapper.Map<Model.WalksDifficultyTable>(walk);
            Model.WalksDifficultyTable NewEntey = await _walkDifficulty.AddWalkDifficultyAsync(newEntry);
            Model.DTO.AddWalkDifficultyRequest Response = _mapper.Map<Model.DTO.AddWalkDifficultyRequest>(NewEntey);
            return CreatedAtAction(nameof(GetWalkDifficulty), new { id = Response.Code }, Response);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, Model.DTO.UpdateWalkDifficulty existingEntry)
        {
            Model.WalksDifficultyTable ExistingEntry = _mapper.Map<Model.WalksDifficultyTable>(existingEntry);
            Model.WalksDifficultyTable UpdatedEntry  = await _walkDifficulty.UpdateWalkDifficultyAsync(id, ExistingEntry);
            Model.DTO.UpdateWalkDifficulty Response = _mapper.Map<Model.DTO.UpdateWalkDifficulty>(UpdatedEntry);
            return Ok(Response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            Model.WalksDifficultyTable Response = await _walkDifficulty.DeleteAsync(id);
            return Ok(Response);
        } 
    }
}
