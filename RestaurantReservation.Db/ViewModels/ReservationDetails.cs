using System;

namespace RestaurantReservation.Db.ViewModels
{
    public class ReservationDetails
    {
        public int ReservationId { get; set; }
        public int TableId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string OpeningHours { get; set; }
    }
}
