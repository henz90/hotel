using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Stripe;
using Hotel.Data;
using Hotel.Models;
using System.ComponentModel.DataAnnotations;
namespace HotelProject.Pages
{
    public class PaymentModel : PageModel
    {
        private readonly DatabaseContext db;
        //public PaymentModel(DatabaseContext db) => 
        public PaymentModel(DatabaseContext db)
        {
            this.db = db;
            //PublicKey = config["Stripe:PublicKey"].ToString();   
            PublicKey = "pk_test_51HA2pUIjlJ1JmMzP0SL1QgxQLc3N4ME0X3D3ZiPZvN4VbT9xOWBJdrrjbpw1Zv36Xx7KNJ7LCtxLEQKLwHDrZQOw00bJLdtrxF";
        }
        public string PublicKey {get;}
        public List<Reservation> Reservations { get; set; }
        public List<Room> Rooms { get; set; }
        public void OnGet()
        {

            var reservedRoomIds = db.Reservations.Where(r => r.UserId == User.Identity.Name).Select(r => r.Room.RoomId).ToHashSet();
            Rooms = db.Rooms.Where(r => reservedRoomIds.Contains(r.RoomId)).ToList();
            var customers = new CustomerService();
        //Rooms = db.Rooms.Where(r => !reservedRoomIds.Contains(r.RoomId)).ToList();
        }

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
