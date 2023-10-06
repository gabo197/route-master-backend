﻿using AutoMapper;
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
        }
    }
}
