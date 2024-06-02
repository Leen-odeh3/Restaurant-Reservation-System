
using System.Collections.Generic;

namespace RestaurantReservation.Db.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string CustomerPhoneNumber { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
