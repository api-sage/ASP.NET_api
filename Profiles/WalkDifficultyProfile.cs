using AutoMapper;

namespace crudapi.Profiles
{
    public class WalkDifficultyProfile : Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<Model.WalksDifficultyTable, Model.DTO.WalksDifficulty>()
                .ReverseMap();
            CreateMap<Model.WalksDifficultyTable, Model.DTO.UpdateWalkDifficulty>()
                .ReverseMap();
            CreateMap<Model.WalksDifficultyTable, Model.DTO.AddWalkDifficultyRequest>()
                .ReverseMap();
            
        }
    }
}
