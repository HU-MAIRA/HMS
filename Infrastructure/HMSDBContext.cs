using System;
using HMS_MVC.Models;
using Microsoft.EntityFrameworkCore;
namespace HMS_MVC.Infrastructure
{
    public class HMSDBContext:DbContext
    {
        public HMSDBContext(DbContextOptions options) : base(options)
        {
           
        }

        public DbSet<BookingService> Booking { get; set; }

       public DbSet<RoomService> RoomDetail { get; set; }

        public DbSet<Customer> Customer { get; set; }
    }
}