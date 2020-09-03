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
    public class ReservationChangeModel : PageModel
    {
        private readonly DatabaseContext db;  
        public ReservationChangeModel(DatabaseContext db) => this.db = db;
        public List<Reservation> Reservations {get; set; } = new List<Reservation>();
        public List<Room> Rooms { get; set; } = new List<Room>();
        public void OnGet()
        {
            Reservations = db.Reservations.Where(r => r.UserId == User.Identity.Name).ToList();
            Rooms = db.Rooms.ToList();
        }
    }
}
