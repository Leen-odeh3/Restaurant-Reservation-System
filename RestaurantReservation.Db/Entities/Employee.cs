using RestaurantReservation.Db.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Column(TypeName = "int")]
    public EmployeePosition Position { get; set; }
    public int? RestaurantId { get; set; }
    public virtual Restaurant Restaurant { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
  
}
