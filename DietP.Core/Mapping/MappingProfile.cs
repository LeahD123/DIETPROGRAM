using AutoMapper;
using DietP.Core.Entities;
using DietP.Core.Resources;

namespace Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FoodsItem, FoodItemResources>().ReverseMap();
            CreateMap<Sport, SportResources>().ReverseMap();
            CreateMap<User, UserResources>().ReverseMap();
            CreateMap<Calendar, CalendarResources>().ReverseMap();
        }

    }
}
