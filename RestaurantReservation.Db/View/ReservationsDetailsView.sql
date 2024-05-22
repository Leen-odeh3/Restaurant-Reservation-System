ALTER VIEW ReservationsDetailsView AS
SELECT 
    r.ReservationId,
    r.TableId,
    r.ReservationDate,
    r.PartySize,
    c.CustomerId,
    c.FirstName,
    c.LastName,
    c.Email,
    c.CustomerPhoneNumber,
    rest.RestaurantId,
    rest.Name,
    rest.Address,
    rest.PhoneNumber,
    rest.OpeningHours
FROM Reservations r
JOIN Customers c ON r.CustomerId = c.CustomerId
JOIN Restaurants rest ON r.RestaurantId = rest.RestaurantId;

