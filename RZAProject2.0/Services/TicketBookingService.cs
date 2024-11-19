using RZAProject2.Models;
using Microsoft.EntityFrameworkCore;

namespace RZAProject2.Services
{
    public class TicketbookingService
    {
        private readonly TlS2302452RzaContext _context;
        public TicketbookingService(TlS2302452RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Ticketbooking>> GetTicketbookingsAsync()
        {
            return await _context.Ticketbookings.ToListAsync();
        }
        public async Task AddTicketbookingAsync(Ticketbooking newTicketbooking)
        {
            await _context.Ticketbookings.AddAsync(newTicketbooking);
            await _context.SaveChangesAsync();
        }
    }
}
