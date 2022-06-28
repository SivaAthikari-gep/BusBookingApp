using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingApp.Model
{
    public class BookingDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        [Required]
        public int BusId { get; set; }
        [Required]
        public string PassengerName { get; set; }
        [Required]
        public int NoOfTickets { get; set; }
        [Required]
        public int TotalPrice { get; set; }
    }
}
