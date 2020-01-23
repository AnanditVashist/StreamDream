using AutoMapper;
using StreamDream.Dtos;
using StreamDream.Models;

namespace StreamDream.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}