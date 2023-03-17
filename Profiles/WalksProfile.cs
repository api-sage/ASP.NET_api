using AutoMapper;

namespace crudapi.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Model.WalksTable, Model.DTO.WalksTable>()
                .ReverseMap();

            CreateMap<Model.WalksTable, Model.DTO.AddWalkRequest>()
                .ReverseMap();

            CreateMap<Model.WalksTable, Model.DTO.UpdateWalkRequest>()
                .ReverseMap();

            //CreateMap<Model.WalksDifficultyTable, Model.DTO.WalksDifficulty>()
            //    .ReverseMap();

            //CreateMap<Model.RegionTable, Model.DTO.RegionTable>()
            //    .ReverseMap();
        }
    }
}
