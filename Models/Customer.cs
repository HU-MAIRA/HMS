using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HMS_MVC.Models
{
    public class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        public int Custid { get; set; }
        public string Custname { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
