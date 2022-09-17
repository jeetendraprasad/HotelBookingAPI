using Microsoft.EntityFrameworkCore;
using PmsApi.Models;

namespace PmsApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<HotelBooking> Bookings { get; set; }
        public DbSet<MedicineInfo> Medicines { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
    }
}
