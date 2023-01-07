namespace Factory.Models{
  public class MechanicMachine
  {
    public int MechanicMachineId { get; set; }
    public int MachineId { get; set; }
    public Machine Machine { get; set; }
    public Mechanic Mechanic { get; set; }
  }
}