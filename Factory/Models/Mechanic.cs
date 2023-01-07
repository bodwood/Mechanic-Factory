using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Mechanic
  {
    public int MechanicId { get; set; }
    [Required(ErrorMessage = "Employee name must be entered")]
    public string Name { get; set; }
     public List<MechanicMachine> JoinEntities { get; }
  }
}