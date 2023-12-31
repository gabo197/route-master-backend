﻿namespace RouteMaster.API.Domain.Models
{
    public class Passenger : Account
    {
        public int PaymentMethodId { get; set; }
        public Address Address { get; set; } = null!;
        public AuditLog AuditLog { get; set; } = null!;
        public PaymentMethod PaymentMethod { get; set; } = null!;
        public Wallet Wallet { get; set; } = null!;
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
        public ICollection<BusLine> BusLines { get; set; } = new List<BusLine>();
        public ICollection<PassengerFavoriteBusLine> PassengerFavoriteBusLines { get; set; } = new List<PassengerFavoriteBusLine>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
