﻿namespace RouteMaster.API.Models
{
    public class Department
    {
        public int CountryId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; } = null!;
        public Country Country { get; set; } = null!;
    }
}