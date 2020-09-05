using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hotel.Data;
using Hotel.Models;
namespace HotelProject.Pages
{
    public class BillsModel : PageModel
    {
        private readonly DatabaseContext db;
        public BillsModel(DatabaseContext db) => this.db = db;
        public List<Bill> Bills { get; set; }
        public void OnGet()
        {
            var userName = User.Identity.Name; // userName is email
            var user = db.Users.Where(u => u.UserName == userName).FirstOrDefault(); // find user record
            Bills = db.Bills.Where(r => (r.User == user)).ToList();
        }
    }
}
