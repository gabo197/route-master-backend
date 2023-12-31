﻿namespace RouteMaster.API.Domain.Models
{
    public abstract class Vehicle
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public string PlateNumber { get; set; } = null!;
        public VehicleType VehicleType { get; set; } = null!;
        public int LineId { get; set; }
    }
}
