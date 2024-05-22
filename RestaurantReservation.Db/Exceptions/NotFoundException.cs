using System;

namespace RestaurantReservation.Db.Exceptions
{
    public class NotFoundException<T> : Exception where T : class
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
