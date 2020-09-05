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
using System.Collections;
namespace HotelProject.Pages
{
    public class PaymentModel : PageModel
    {
        private readonly DatabaseContext db;
        //public PaymentModel(DatabaseContext db) => 
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<Room> Rooms { get; set; } = new List<Room>();
        
        [BindProperty(SupportsGet = true)]
        public List<int> ids { get; set; } //= new List<int>();
        public void OnGet()
        {
            ViewData["Checkin"] = ids;
            var userName = User.Identity.Name; // userName is email
            var user = db.Users.Where(u => u.UserName == userName).FirstOrDefault(); // find user record
            Reservations = db.Reservations.Where(r => (r.User == user)).ToList();
            Rooms = db.Rooms.ToList();
        }
        public PaymentModel(DatabaseContext db)
        {
            this.db = db;
            //PublicKey = config["Stripe:PublicKey"].ToString();   
            PublicKey = "pk_test_51HA2pUIjlJ1JmMzP0SL1QgxQLc3N4ME0X3D3ZiPZvN4VbT9xOWBJdrrjbpw1Zv36Xx7KNJ7LCtxLEQKLwHDrZQOw00bJLdtrxF";
        }
        public string PublicKey {get;}
     
        public IActionResult OnPost(string stripeEmail, string stripeToken,string stripePrice,string ids)
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
        
            string[] idsStr = ids.Split(',');//List<string> idsStr = ids.Split(',').ToList();
            int[] idsInt = Array.ConvertAll(idsStr, s => int.Parse(s));
            db.Reservations.Where(c => idsInt.Contains(c.Room.RoomId)).ToList().ForEach(cc => cc.PayThebill = true);
            var userName = User.Identity.Name; // userName is email
            var user = db.Users.Where(u => u.UserName == userName).FirstOrDefault();
            Bill bill = new Bill();
            bill.RoomIds = ids;
            bill.User = user;
            bill.BillCreated = DateTime.Now;
            bill.Amount = (long)Convert.ToDouble(stripePrice);
            db.Add(bill);
            db.SaveChanges();
            return Redirect("/Index");
        }
    }
}
