using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScardovelliBooking.Services
{
    public class ScardovelliBookingsContext : DbContext
    {
        public ScardovelliBookingsContext(DbContextOptions<ScardovelliBookingsContext> options) : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }

    }

    public class Booking
    {
        public Booking()
        {
            
        }

        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Session { get; set; }
        public string UserName { get; set; }

    }
}
