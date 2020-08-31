using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using hotel.Data;
using hotel.Models;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Pages
{
    public class ReservationModel : PageModel
    {
        [BindProperty(SupportsGet = true), Required]
        public DateTime Checkin {get; set;}
        
        [BindProperty(SupportsGet = true), Required]
        public DateTime Checkout {get; set;}

        [BindProperty, Required]
        public int Room {get; set;}

        private readonly DatabaseContext db;  
        public ReservationModel(DatabaseContext db) => this.db = db;
        public List<Room> Rooms { get; set; } = new List<Room>();  
        public List<Reservation> Reservations {get; set;} = new List<Reservation>();
        public void OnGet()
        {
            ViewData["Checkin"] = Checkin;
            ViewData["Checkout"] = Checkout;
            //ViewData["Checkout"] = (Checkout - Checkin) * ;
            Reservations = db.Reservations.ToList();
            Rooms = db.Rooms.ToList();
        }

        public IActionResult OnPost(){
            //return RedirectToPage("ReservationSuccess");
            Reservation reservation = new Reservation();
            reservation.CheckIn = Checkin;
            reservation.CheckOut = Checkout;
            reservation.RoomId = Room;
            reservation.UserId = "id";  // FIXME:   ???? How do I put user ID in here?
            return Page();
        }
    }
}
