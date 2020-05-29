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
        private readonly ScardovelliBookingsContext _context;

        public HomeController(ILogger<HomeController> logger,
            ScardovelliBookingsContext context)
        {
            _logger = logger;
            _context = context;
            _bookingFor = DateTime.Today.AddDays(1);
        }

        public DateTime _bookingFor { get; set; }


        public IActionResult Index()
        {
            ViewData["Date"] = _bookingFor.ToString("dd/MM/yyyy");
            List<BookingVM> bookings = _context.Bookings
                .Where(b=> b.Date == _bookingFor)
                .Select(b => 
                    new BookingVM {
                        Session = b.Session,
                        UserName = b.UserName
                }).ToList();
                
            return View(bookings);
        }

        public void Book(BookingVM booking)
        {

            Booking bookingDb = new Booking
            {
                Date = _bookingFor,
                Session = booking.Session,
                UserName = booking.UserName
            };

            _context.Bookings.Add(bookingDb);
            _context.SaveChanges();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
