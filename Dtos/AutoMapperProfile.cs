using AutoMapper;
using FApi.Models;

namespace FApi.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FModelDto, FModel>();
        }
    }
}