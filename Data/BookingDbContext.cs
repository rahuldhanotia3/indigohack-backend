namespace WebApiProject1.Data
{
    public class BookingDbContext:DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options):base(options)
        {
                            
        }
        public DbSet<BookingDetails> Bookings { get; set; }
    }
}
