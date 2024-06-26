﻿
using System;
using System.Collections.Generic;

namespace RestaurantReservation.Db.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public int TableId { get; set; }
        public Customer Customer { get; set; }
        public Restaurant Restaurant { get; set; }
        public Table Table { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
