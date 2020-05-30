using ScardovelliBooking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScardovelliBooking.Models.VMs
{
    
    public class BookingVM
    {
        public BookingVM(int maxCap)
        {
            MaxCapacity = maxCap;
        }
        public List<Booking> Bookings { get; set; }
        public int MaxCapacity { get; set; }

    }
}
