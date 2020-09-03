using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Stripe;
namespace HotelProject.Pages
{
    public class PaymentModel : PageModel
    {
        public PaymentModel()
        {
            //PublicKey = config["Stripe:PublicKey"].ToString();   
            PublicKey = "pk_test_51HA2pUIjlJ1JmMzP0SL1QgxQLc3N4ME0X3D3ZiPZvN4VbT9xOWBJdrrjbpw1Zv36Xx7KNJ7LCtxLEQKLwHDrZQOw00bJLdtrxF";
        }
        public string PublicKey {get;}
        public IActionResult OnPost(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                Customer = customer.Id
            });

            return Redirect("/Index");
           //return Page();
        }
    }
}
