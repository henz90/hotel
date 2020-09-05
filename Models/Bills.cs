using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Hotel.Models
{
    public class Bills
    {
        public int BillsId { get; set;}
        public Room Room { get; set; }
        //public string UserId { get; set;}
        public IdentityUser User {get; set;}
        public DateTime BillCreated { get; set;}
        public long Amount { get; set; }
    }
}