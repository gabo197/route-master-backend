﻿namespace RouteMaster.API.Domain.Models
{
    public class Bus : Vehicle
    {
        public BusDriver? BusDriver { get; set; }
        public BusLine BusLine { get; set; } = null!;
    }
}