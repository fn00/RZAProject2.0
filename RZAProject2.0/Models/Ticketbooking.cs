using System;
using System.Collections.Generic;

namespace RZAProject2.Models;

public partial class Ticketbooking
{
    public int CustomerId { get; set; }

    public int TicketId { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;
}
