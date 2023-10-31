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
            CreateMap<SavePassengerResource, Passenger>();
            CreateMap<SaveWalletResource, Wallet>();
            CreateMap<SaveTicketResource, Ticket>();
            CreateMap<SaveAccountResource, Account>();
            CreateMap<SaveCompanyResource, Company>();
            CreateMap<SaveLineResource, Line>();
            CreateMap<SaveBusLineResource, BusLine>();
            CreateMap<SaveRailwayLineResource, RailwayLine>();
            CreateMap<SaveSubwayLineResource, SubwayLine>();
            CreateMap<SaveTripResource, Trip>();
            CreateMap<SaveTripDetailResource, TripDetail>();
        }
    }
}
