using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingApp.Model
{
    public class BusDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BusId { get; set; }
        [Required]
        [StringLength(150)]
        public string BusNumber { get; set; }
        [Required]
        public int SourceKeyId { get; set; }
        [NotMapped]
        public string Source { get; set; }
        [Required]
        public int DestinationCityId { get; set; }
        [NotMapped]
        public string Destination { get; set; }
        [Required]
        public int SeatCount { get; set; }
        [Required]
        public int SeatPrice { get; set; }
    }
}
