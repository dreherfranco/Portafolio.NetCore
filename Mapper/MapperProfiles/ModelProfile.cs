using AutoMapper;
using DTOs.User;
using Model.Entities;

namespace Mapper.MapperProfiles
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<User, UserDTO>()
                    .ReverseMap()
                    .ForMember(s => s.Id, opt => opt.Ignore());
        }
    }
}
