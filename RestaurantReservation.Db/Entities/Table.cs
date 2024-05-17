﻿using System.Collections.Generic;

namespace RestaurantReservation.Db.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<Reservation>? Reservations { get; set; } = new List<Reservation>();
    }
}
