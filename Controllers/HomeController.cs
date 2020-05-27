using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScardovelliBooking.Models;
using ScardovelliBooking.Models.VMs;
using ScardovelliBooking.Services;
using ScardovelliBooking.Services.Contracts;

namespace ScardovelliBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataRepository _dataRepository;
        private readonly ScardovelliBookingsContext _context;
        
        public HomeController(ILogger<HomeController> logger,
            IDataRepository dataRepository,
            ScardovelliBookingsContext context)
        {
            _logger = logger;
            _dataRepository = dataRepository;
            _context = context;
        }


        public IActionResult Index()
        {
            List<BookingVM> bookings = _context.Bookings
                .Where(b=> b.Date == DateTime.Today)
                .Select(b => new BookingVM {
                Session = b.Session,
                UserName = b.UserName
            }).ToList();
                
            return View(bookings);
        }

        public void Book(BookingVM booking)
        {
            _dataRepository.SaveBooking(booking);

            Booking bookingDb = new Booking
            {
                Date = DateTime.Today,
                Session = booking.Session,
                UserName = booking.UserName
            };

            _context.Bookings.Add(bookingDb);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
