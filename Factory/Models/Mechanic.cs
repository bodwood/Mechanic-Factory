using System.Collections.Generic;
namespace Factory.Models
{
  public class Mechanic
  {
    public int MechanicId { get; set; }
    public string Name { get; set; }
    public List<Machine> Machines { get; set; }
  }
}