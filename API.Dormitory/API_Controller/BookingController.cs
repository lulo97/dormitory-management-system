using API.Dormitory.API_Service;
using Data.Dormitory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Dormitory.API_Controller
{
    public class BookingController : ApiController
    {
        BookingService bookingService = new BookingService();

        [HttpPost]
        [Route("api/booking/sentBookingForm")]
        public string sentBookingForm(int RoomID)
        {
            return bookingService.sentBookingForm(RoomID);
        }

        [HttpPost]
        [Route("api/booking/isBooked")]
        public bool isBooked(int RoomID)
        {
            return bookingService.isBooked(RoomID);
        }

        [HttpGet]
        [Route("api/booking/getAll")]
        public List<Booking> getAll()
        {
            return bookingService.getAll();
        }

        [HttpPost]
        [Route("api/booking/setApproveBookingForm")]
        public string setApproveBookingForm(int BookingID)
        {
            return bookingService.setApproveBookingForm(BookingID);
        }

        [HttpPost]
        [Route("api/booking/setDenyBookingForm")]
        public string setDenyBookingForm(int BookingID)
        {
            return bookingService.setDenyBookingForm(BookingID);
        }
    }
}
