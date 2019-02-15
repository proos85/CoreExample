using AutoMapper;
using CoreExample.Models;
using CoreExample.Website.Models;

namespace CoreExample.Website.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<SuperHero, SuperHeroViewModel>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.HeroAge))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.HeroName))
                ;
        }
    }
}