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

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var emp = await _context.Bookings.FindAsync(id);
            return emp == null ? NotFound() : Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookingDetails e)
        {
            await _context.Bookings.AddAsync(e);
            await _context.SaveChangesAsync();

            return CreatedAtAction (nameof(GetById), new { id = e.id},e);
        }
    }
}
 