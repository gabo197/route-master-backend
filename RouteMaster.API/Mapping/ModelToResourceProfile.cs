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
            CreateMap<User, UserResource>();
            CreateMap<Passenger, PassengerResource>();
            CreateMap<Address, AddressResource>();
            CreateMap<AuditLog, AuditLogResource>();
            CreateMap<AccountType, AccountTypeResource>();
            CreateMap<PaymentMethod, PaymentMethodResource>();
            CreateMap<Wallet, WalletResource>();
            CreateMap<Ticket, TicketResource>();
            CreateMap<Line, LineResource>();
            CreateMap<SubwayLine, SubwayLineResource>();
            CreateMap<BusLine, BusLineResource>();
            CreateMap<RailwayLine, RailwayLineResource>();
            CreateMap<Company, CompanyResource>();
            CreateMap<VehicleType, VehicleTypeResource>();
            CreateMap<Bus, BusResource>();
            CreateMap<Subway, SubwayResource>();
            CreateMap<Railway, RailwayResource>();
            CreateMap<BusDriver, BusDriverResource>();
            CreateMap<SubwayDriver, SubwayDriverResource>();
            CreateMap<RailwayDriver, RailwayDriverResource>();
            CreateMap<DocumentType, DocumentTypeResource>();
            CreateMap<BusStop, BusStopResource>();
            CreateMap<SubwayStop, SubwayStopResource>();
            CreateMap<RailwayStop, RailwayStopResource>();
            CreateMap<Trip, TripResource>();
            CreateMap<BusTripDetail, BusTripDetailResource>();
            CreateMap<SubwayTripDetail, SubwayTripDetailResource>();
            CreateMap<RailwayTripDetail, RailwayTripDetailResource>();
            CreateMap<BusLineStop, BusLineStopResource>();
            CreateMap<SubwayLineStop, SubwayLineStopResource>();
            CreateMap<RailwayLineStop, RailwayLineStopResource>();
            CreateMap<PassengerFavoriteBusLine, PassengerFavoriteBusLineResource>();
            CreateMap<Rating, RatingResource>();
            CreateMap<Transaction, TransactionResource>();
        }
    }
}
