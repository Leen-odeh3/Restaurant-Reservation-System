﻿
namespace RestaurantReservation.Db.ViewModels
{
    public class EmployeeDetails
    {
        public int EmployeeId { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }

        public string Position { get; set; }

        public int RestaurantId { get; set; }

        public string RestaurantName { get; set; }

        public string RestaurantAddress { get; set; }

        public string RestaurantPhoneNumber { get; set; }

        public string RestaurantOpeningHours { get; set; }
    }
}
