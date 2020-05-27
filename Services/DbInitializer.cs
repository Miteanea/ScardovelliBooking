using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScardovelliBooking.Services
{
    public class DbInitializer
    {
        public static void Initialize(ScardovelliBookingsContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
