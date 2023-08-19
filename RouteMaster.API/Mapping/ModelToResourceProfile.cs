using AutoMapper;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Resources;

namespace RouteMaster.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Country, CountryResource>();
            CreateMap<Department, DepartmentResource>();
            CreateMap<Province, ProvinceResource>();
            CreateMap<District, DistrictResource>();
        }
    }
}
