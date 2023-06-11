namespace WebApiProject1.Models
{
    public class BookingDetails
    {
          public int pnr { get; set; }
          public string wayType { get; set; }
          public string fromCity { get; set; }
          public string toCity { get; set; }
          public DateTime departureDate { get; set; }

          public string addReturnTrip { get; set; }
          public string SeatCount { get; set; }
          public string CurrencyType { get; set; }

          public string UserType { get; set; }
          public string MobileNo { get; set; }
          public string Email { get; set; }
    }
}
