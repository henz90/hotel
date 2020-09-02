using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public class Reservation
    {
        public int ReservationId { get; set;}
        public Room Room { get; set; }
        public string UserId { get; set;}
        public DateTime CheckIn { get; set;}
        public DateTime CheckOut { get; set;}

        public static implicit operator List<object>(Reservation v)
        {
            throw new NotImplementedException();
        }
    }
}