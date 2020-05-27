using ScardovelliBooking.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScardovelliBooking.Services.Contracts
{
    public interface IDataRepository
    {
        void SaveBooking(BookingVM booking);
        List<Booking> GetBookings(DateTime date);
    }
}
