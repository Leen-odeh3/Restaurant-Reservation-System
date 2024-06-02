using System;

namespace RestaurantReservation.Db.Exceptions;

public class NegativeTotalAmountException : Exception
{
    public NegativeTotalAmountException()
    {
    }

    public NegativeTotalAmountException(string message)
        : base(message)
    {
    }

}
