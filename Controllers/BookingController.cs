using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi1.Data;
using WebApi1.Models;
namespace WebApiProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public BookingController(BookingDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<BookingDetails>> Get()
        {
            return await _context.Bookings.ToListAsync();
        }

        [HttpGet("pnr")]
        public async Task<IActionResult> GetByPnr(int pnr)
        {
            var emp = await _context.Bookings.FindAsync(pnr);
            return emp == null ? NotFound() : Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookingDetails e)
        {
            await _context.Bookings.AddAsync(e);
            await _context.SaveChangesAsync();

            return CreatedAtAction (nameof(GetByPnr), new { pnr = e.pnr},e);
        }
    }
}
 