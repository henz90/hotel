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
            if (Checkin == null){   //  FIXME:  Correct so that unselected dates don't show as "01-01-0001"
                return Page();    
            }
            return RedirectToPage("Reservation", new {Checkin = Checkin.Date.ToString("MM-dd-yyyy"), Checkout = Checkout.Date.ToString("MM-dd-yyyy")});
        }
    }
}
