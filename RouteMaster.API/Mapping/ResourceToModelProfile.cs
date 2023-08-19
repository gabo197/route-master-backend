using AutoMapper;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Resources;

namespace RouteMaster.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
        }
    }
}
