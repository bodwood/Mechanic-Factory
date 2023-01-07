namespace Factory.Models{
  public class MechanicMachine
  {
    public int MechanicMachineId { get; set; }
    public int MachineId { get; set; }
    public Machine Machine { get; set; } //reference to machine table
    public int MechanicId { get; set; }
    public Mechanic Mechanic { get; set; } //reference to mechanic table
  }
}