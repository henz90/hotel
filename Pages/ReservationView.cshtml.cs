using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel.Pages
{
    public class ReservationViewModel : PageModel
    {
        private DatabaseContext db;
        public ReservationViewModel(DatabaseContext db) => this.db = db;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Reservation Reservation {get; set; }

        public List<Room> Rooms { get; set; }

        public void OnGet(){
            Reservation = db.Reservations.Find(Id);
            Rooms = db.Rooms.ToList();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
