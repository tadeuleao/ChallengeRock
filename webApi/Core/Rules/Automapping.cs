using AutoMapper;
using Core.Model;
using Core.DB.Entity;

namespace Core.Rules
{
    public class Automapping : Profile
    {
        public Automapping()
        {
            CreateMap<Users, UserDTO>();
            CreateMap<Posts, PostDTO>();
        }
    }
}
