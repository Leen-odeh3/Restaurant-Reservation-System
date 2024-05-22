using RestaurantReservation.Db.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Column(TypeName = "nvarchar")]
    public EmployeePosition Position { get; set; }
    public int? RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public ICollection<Order>? Orders { get; set; } = new List<Order>();
}
