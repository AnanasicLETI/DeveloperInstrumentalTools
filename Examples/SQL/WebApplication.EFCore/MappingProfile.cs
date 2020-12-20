using AutoMapper;
using Database.EFCore.Entities;

namespace WebApplication.EFCore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<AdvertEntity, Advert>()
                .ForMember(
                    dst => dst.Type,
                    opt => opt.MapFrom(src => src.Type.Type));
        }
    }
}