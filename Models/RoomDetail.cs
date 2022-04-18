using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HMS_MVC.Models
{
    public partial class RoomDetail
    {
        public RoomDetail()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        public int Roomnumber { get; set; }

        [Required]
        public string Roomtype { get; set; }
        public string Roomstatus { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
