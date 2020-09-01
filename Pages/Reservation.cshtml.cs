using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hotel.Data;
using Hotel.Models;
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
        public List<Reservation> Reservations {get; set; } // = new List<Reservation>();
        public void OnGet()
        {
            ViewData["Checkin"] = Checkin;
            ViewData["Checkout"] = Checkout;
            // Reservations = db.Reservations.Where(r => r.CheckIn.CompareTo(Checkin) >= 0  ;
            // query 1: find all reservations that exist where start OR end date is with the date range, then distinct(Room.Id) => list of room Ids that are occupied
            Reservations = (List<Reservation>)db.Reservations.Where(r => r.CheckIn.CompareTo((DateTime)Checkin) <=0 && r.CheckOut.CompareTo((DateTime)Checkout) >=0); // FIXME: NEEDS WORK
            // query 2: find all rooms that do not have room.Id on the list created by query 1
            Rooms = db.Rooms.ToList();
        }

        public IActionResult OnPost(){
            if (ModelState.IsValid){
                /*
                Reservation reservation = new Reservation();
                reservation.CheckIn = Checkin;
                reservation.CheckOut = Checkout;
                reservation.RoomId = Room;
                reservation.UserId = User.Identity.Name;
                db.Add(reservation);
                db.SaveChanges();
                int id = reservation.ReservationId;
                return RedirectToPage("ReservationSuccess", new {Checkin = Checkin.Date.ToString("MM-dd-yyyy"), Checkout = Checkout.Date.ToString("MM-dd-yyyy"), Room = reservation.RoomId, Id = id});    */
            }
            return Page();
        }
    }
}
