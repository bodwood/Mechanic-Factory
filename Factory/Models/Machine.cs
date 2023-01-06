using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    public string Name { get; set; }
    public int MechanicId { get; set; }
    public Mechanic Mechanic { get; set; }
  }
}