using RZAProject2.Models;
using Microsoft.EntityFrameworkCore;

namespace RZAProject2.Services
{
    public class TicketService
    {
        private readonly TlS2302452RzaContext _context;
        public TicketService(TlS2302452RzaContext context)
        {
            _context = context;
        }
        public async Task AddTicketAsync(Ticket newTicket)
        {
            await _context.Tickets.AddAsync(newTicket);
            await _context.SaveChangesAsync();
        }
    }
}
