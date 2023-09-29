﻿namespace RouteMaster.API.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Token { get; set; }
        public bool IsActive { get; set; }
        public Account Account { get; set; } = null!;
        public Wallet Wallet { get; set; } = null!;
    }
}