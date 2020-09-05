using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HotelProject.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty, Required]
        public DateTime Checkin {get; set;}

        [BindProperty, Required]
        public DateTime Checkout {get; set;}

        public IActionResult OnPost()
        {
            var today = DateTime.Now;
            if (Checkin >= Checkout || Checkin >= today){   //    FIXME: Needs Work
            //errormessage = "Checkin and Checkout dates must be different and after today's date. Checkout must be after Checkin."; //  FIXME: How do I pass this?
                return Page();
            }
            return RedirectToPage("Reservation", new {Checkin = Checkin.Date.ToString("MM-dd-yyyy"), Checkout = Checkout.Date.ToString("MM-dd-yyyy")});
        }
    }
}
