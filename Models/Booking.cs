using System;
using System.ComponentModel.DataAnnotations;

namespace HMS_MVC.Models
{
    public class Booking
    {
        [Key]
        public int Bookingid { get; set; }

       
        public int? RoomNumber { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public string Bookingstatus { get; set; }
        public int? Custid { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual RoomDetail RoomNumberNavigation { get; set; }
    }
}
