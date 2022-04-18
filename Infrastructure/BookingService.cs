using HMS_MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace HMS_MVC.Infrastructure
{
    public class BookingService : IBookingService
    {
        public HMSDBContext context;
        public BookingService(HMSDBContext context)
        {
            this.context = context;
        }

        public async Task<IList<Booking>> BookingHistory()
        {
            IList<Booking> bookings;

            try
            {
                await Task.Delay(1000);
                bookings = context.Set<Booking>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bookings;
        }

        //Add Booking 
        public bool AddBooking(Booking bobj)
        {
            context.Add<Booking>(bobj);
            context.SaveChanges();
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateRoomStatus()
        {
            throw new NotImplementedException();
        }

        public void CancelBooking(int bookingid)
        {
            throw new NotImplementedException();
        }
    }
}

