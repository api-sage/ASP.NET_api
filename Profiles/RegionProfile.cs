using AutoMapper;
using crudapi.Model;

namespace crudapi.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Model.RegionTable, Model.DTO.RegionTable>()
                .ReverseMap();
        }
    }
}
