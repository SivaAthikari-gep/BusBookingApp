using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBookingApp.Model;

namespace BusBookingApp.Model
{
    public class JourneyContext : DbContext
    {
        public JourneyContext(DbContextOptions<JourneyContext> options): base(options)
        {

        }

        public DbSet<BusDetails> CityDetails { get; set; }
        public DbSet<BusDetails> BusDetails { get; set; }
        public DbSet<BusDetails> BookingDetails { get; set; }
        public DbSet<BusBookingApp.Model.CityDetails> CityDetails_1 { get; set; }
        public DbSet<BusBookingApp.Model.BookingDetails> BookingDetails_1 { get; set; }
       
    }
}
