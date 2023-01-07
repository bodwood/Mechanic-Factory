using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class FactoryContext : DbContext
  {
    public DbSet<Machine> Machines { get; set; }
    public DbSet<Mechanic> Mechanics { get; set; }
    public DbSet<MechanicMachine> MechanicMachines { get; set; }

    public FactoryContext(DbContextOptions options) : base(options) { }
  }
}