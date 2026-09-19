using AutoMapper;
using WebAppi.Entities;
using WebAppi.Models;
using WebAppi.Sevices;

namespace Console.Services;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<ZolaOfCocksick, ZolaOfCocsickDB>()
            .ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<FluxAdditions, FluxAdditionsDB>()
            .ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<Cocksick, CocksickDB>()
            .ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<StartEnter, StartEnterDB>()
            .ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<MmkCoef, MmkCoefDB>()
            .ForMember(x => x.ID, opt => opt.Ignore());
        CreateMap<ZolaOfCocksick, ZolaOfCocsickDB>()
            .ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<ShihtaComponent, ShihtaComponentsDB>()
            .ForMember(x => x.ID, opt => opt.Ignore())
            .ForMember(x => x.PresetId, opt => opt.Ignore());

        CreateMap<AddUserDTO, UserDB>();
    }
}
