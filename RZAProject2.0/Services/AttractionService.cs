using RZAProject2.Models;
using Microsoft.EntityFrameworkCore;

namespace RZAProject2.Services
{
    public class AttractionService
    {

        private readonly TlS2302452RzaContext _context;

    public AttractionService(TlS2302452RzaContext context)
    {
        _context = context;
    }


        public async Task<List<Attraction>> GetAttractionsAsync()
        {
            return await _context.Attractions.ToListAsync();
        }
    }
}
