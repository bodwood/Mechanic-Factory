using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    [Required(ErrorMessage = "Machine name must be entered")]
    public string Name { get; set; }
    public List<MechanicMachine> JoinEntities { get; }
  }
}