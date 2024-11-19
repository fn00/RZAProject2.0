﻿using System;
using System.Collections.Generic;

namespace RZAProject2.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Postcode { get; set; }

    public string? PhoneNumber { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public int? LoyaltyPoints { get; set; }

    public virtual ICollection<Ticketbooking> Ticketbookings { get; set; } = new List<Ticketbooking>();
}
