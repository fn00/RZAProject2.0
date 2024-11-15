﻿using System;
using System.Collections.Generic;

namespace RZAProject2.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int AttractionId { get; set; }

    public DateOnly? Date { get; set; }

    public virtual Attraction Attraction { get; set; } = null!;

    public virtual ICollection<Ticketbooking> Ticketbookings { get; set; } = new List<Ticketbooking>();
}
