
﻿ALTER VIEW EmployeeDetailsView AS

﻿ALTER VIEW EmployeesDetailsView AS

SELECT 
    e.Id AS EmployeeId,
    e.FirstName AS EmployeeFirstName,
    e.LastName AS EmployeeLastName,

    CASE 
        WHEN e.Position = 'Waiter' THEN 1
        WHEN e.Position = 'Chef' THEN 2
        WHEN e.Position = 'Cashier' THEN 3
        WHEN e.Position = 'Manager' THEN 4
        ELSE NULL
    END AS Position,

    e.Position,

    r.RestaurantId,
    r.Name AS RestaurantName,
    r.Address AS RestaurantAddress,
    r.PhoneNumber AS RestaurantPhoneNumber,
    r.OpeningHours AS RestaurantOpeningHours
FROM Employees e

INNER JOIN Restaurants r ON e.RestaurantId = r.RestaurantId;

INNER JOIN Restaurants r ON e.RestaurantId = r.RestaurantId;

