using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using hotel.Data;
using hotel.Models;

namespace Hotel.Pages
{
    public class ReservationModel : PageModel
    {
        public DateTime GetCheckin(string Checkin){
            return Convert.ToDateTime(Checkin);
        }
        public DateTime GetCheckout(string Checkout){
            return Convert.ToDateTime(Checkout);
        }
        private readonly DatabaseContext db;  
        public ReservationModel(DatabaseContext db) => this.db = db;
        public List<Room> Rooms { get; set; } = new List<Room>();  
        public List<Reservation> Reservations {get; set;} = new List<Reservation>();
        public void OnGet()
        {
            Reservations = db.Reservations.ToList();
            Rooms = db.Rooms.ToList();
        }
    }
}
