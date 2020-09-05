using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Hotel.Models
{
    public class Bill
    {
        public int BillId { get; set;}
        public Room Room { get; set; }
        public IdentityUser User {get; set;}
        public DateTime BillCreated { get; set;}
        public long Amount { get; set; }
    }
}