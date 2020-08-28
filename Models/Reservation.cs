using System;

namespace hotel.Models
{
    public class Reservation
    {
        public int ReservationId {get; set;}
        public int RoomId {get; set;}
        public string UserId {get; set;}
        public DateTime CheckIn {get; set;}
        public DateTime CheckOut {get; set;}

    }
}