using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel.Pages
{
    public class ReservationSuccessModel : PageModel
    {
        [BindProperty(SupportsGet = true), Required]
        public DateTime Checkin {get; set;}
        
        [BindProperty(SupportsGet = true), Required]
        public DateTime Checkout {get; set;}

        [BindProperty(SupportsGet = true), Required]
        public int Room {get; set;}

        [BindProperty(SupportsGet = true), Required]
        public int Id {get; set;}
        public void OnGet()
            {
                ViewData["Checkin"] = Checkin;
                ViewData["Checkout"] = Checkout;
                ViewData["Room"] = Room;
                ViewData["Id"] = Id;
        }
    }
}
