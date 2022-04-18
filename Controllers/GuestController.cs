//For Guest
using Microsoft.AspNetCore.Http;
using HMS_MVC.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;


namespace HMS_MVC.Controllers
{
    public class GuestController : Controller
    {

        private readonly IBookingService _bookingService;
        private readonly ILogger<GuestController> _logger;

        #region "Constructor init"
        public GuestController(IBookingService booking, ILogger<GuestController> logger)
        {
            _logger = logger;
            _logger.LogInformation("Booking  called");
            _bookingService = booking;
        }
        #endregion


        public IActionResult GuestMain()
        {
            return View();
        }

        public IActionResult AddBooking()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBooking(HMS_MVC.Models.Booking bookobj)
        {
            try
            {
                _logger.LogInformation("-AddBooking endpoint start");
                _bookingService.AddBooking(bookobj);
                //{
                _logger.LogInformation("-AddBooking end point end");
                return Ok("Booking done");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occurred; Exception detail:" + ex.Message);
                _logger.LogError("Exception occurred; Exception detail:" + ex.InnerException);
                _logger.LogError("Exception occurred; Exception detail:" + ex);
                return BadRequest();
            }
        }

        public IActionResult CancelBooking()
        {
            return View();
        }

        [HttpPut]
        public IActionResult CancelBooking(HMS_MVC.Models.Booking bookobj)
        {
            try
            {
                _logger.LogInformation("Cancelbooking endpoint start");

                _bookingService.CancelBooking(bookobj.Bookingid);


                _logger.LogInformation("Cancelbooking endpoint end");
                return Ok("Booking Cancelled");

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occurred; Exception detail:" + ex.Message);
                _logger.LogError("Exception occurred; Exception detail:" + ex.InnerException);
                _logger.LogError("Exception occurred; Exception detail:" + ex);
                return BadRequest();
            }
        }


        public IActionResult GetAllBooking()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult BookingHistory)
        //{
            
            
    }
}
