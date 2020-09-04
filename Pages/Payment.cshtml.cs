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
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<Room> Rooms { get; set; } = new List<Room>();
        public void OnGet()
        {
            var userName = User.Identity.Name; // userName is email
            var user = db.Users.Where(u => u.UserName == userName).FirstOrDefault(); // find user record
            Reservations = db.Reservations.Where(r => (r.User == user) && (r.PayThebill != true)).ToList();
            Rooms = db.Rooms.ToList();
        }
        public PaymentModel(DatabaseContext db)
        {
            this.db = db;
            //PublicKey = config["Stripe:PublicKey"].ToString();   
            PublicKey = "pk_test_51HA2pUIjlJ1JmMzP0SL1QgxQLc3N4ME0X3D3ZiPZvN4VbT9xOWBJdrrjbpw1Zv36Xx7KNJ7LCtxLEQKLwHDrZQOw00bJLdtrxF";
        }
        public string PublicKey {get;}
        // public void OnGet()
        // {

        //    // var reservedRoomIds = db.Reservations.Where(r => r.UserId == User.Identity.Name).Select(r => r.Room.RoomId).ToHashSet();
        //    // Rooms = db.Rooms.Where(r => reservedRoomIds.Contains(r.RoomId)).ToList();
        //    // var customers = new CustomerService();
        // //Rooms = db.Rooms.Where(r => !reservedRoomIds.Contains(r.RoomId)).ToList();
        // }

        public IActionResult OnPost(string stripeEmail, string stripeToken,string stripePrice)
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
                Amount = (long)Convert.ToDouble(stripePrice),
                Description = "Sample Charge",
                Currency = "cad",
                Customer = customer.Id
            });
            db.Reservations.Where(c => c.User.Email == stripeEmail).ToList().ForEach(cc => cc.PayThebill = true);
            db.SaveChanges();
            //Reservations = db.Reservations.Where(r => (r.User == user) && (r.PayThebill != true)).ToList();
            return Redirect("/Index");
           //return Page();
        }
    }
}
