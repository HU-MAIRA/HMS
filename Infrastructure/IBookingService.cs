using HMS_MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMS_MVC.Infrastructure
{
    public interface IBookingService
    {
        bool AddBooking(Booking bobj);
        void UpdateRoomStatus();

        void CancelBooking(int bookingid);

        Task<IList<Booking>> BookingHistory();
    }
}
