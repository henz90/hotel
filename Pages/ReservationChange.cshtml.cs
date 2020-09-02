using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hotel.Data;
using Hotel.Models;

namespace Hotel.Pages
{
    public class ReservationChangeModel : PageModel
    {
        private DatabaseContext db;
        public ReservationChangeModel(DatabaseContext db) => this.db = db;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public void OnGet()
        {
        }
    }
}
