ALTER VIEW EmployeesDetailsView AS
SELECT 
    e.Id AS EmployeeId,
    e.FirstName AS EmployeeFirstName,
    e.LastName AS EmployeeLastName,
    e.Position,
    r.RestaurantId,
    r.Name AS RestaurantName,
    r.Address AS RestaurantAddress,
    r.PhoneNumber AS RestaurantPhoneNumber,
    r.OpeningHours AS RestaurantOpeningHours
FROM Employees e
INNER JOIN Restaurants r ON e.RestaurantId = r.RestaurantId;