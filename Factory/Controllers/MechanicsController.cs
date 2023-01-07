using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Factory.Models;
using System.Linq;

namespace Factory.Controllers
{
  public class MechanicsController : Controller
  {
    private readonly FactoryContext _db;

    public MechanicsController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Mechanics.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Mechanic mechanic)
    {
      if (!ModelState.IsValid)
      {
        return View(mechanic);
      }
      _db.Mechanics.Add(mechanic);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      ViewBag.Machines = _db.Machines.ToList();
      Mechanic thisMechanic = _db.Mechanics
                                  .Include(mechanic => mechanic.JoinEntities)
                                .ThenInclude(join => join.Machine)
                                .FirstOrDefault(mechanic => mechanic.MechanicId == id);
      return View(thisMechanic);
    }

    public ActionResult Edit(int id)
    {
      Mechanic thisMechanic = _db.Mechanics.FirstOrDefault(mechanic => mechanic.MechanicId == id);
      return View(thisMechanic);
    }

    [HttpPost]
    public ActionResult Edit(Mechanic mechanic)
    {
      if (!ModelState.IsValid)
      {
        return View(mechanic);
      }
      else
      {
        _db.Mechanics.Update(mechanic);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Delete(int id)
    {
      Mechanic thisMechanic = _db.Mechanics.FirstOrDefault(mechanic => mechanic.MechanicId == id);
      return View(thisMechanic);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Mechanic thisMechanic = _db.Mechanics.FirstOrDefault(mechanic => mechanic.MechanicId == id);
      _db.Mechanics.Remove(thisMechanic);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
      Mechanic thisMechanic = _db.Mechanics.FirstOrDefault(mechanics => mechanics.MechanicId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisMechanic);
    }

    [HttpPost]
    public ActionResult AddMachine(Mechanic mechanic, int machineId)
    {
#nullable enable
      MechanicMachine? joinEntity = _db.MechanicMachines.FirstOrDefault(join => (join.MachineId == machineId && join.MechanicId == mechanic.MechanicId));
#nullable disable
      if (joinEntity == null && machineId != 0)
      {
        _db.MechanicMachines.Add(new MechanicMachine() { MachineId = machineId, MechanicId = mechanic.MechanicId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = mechanic.MechanicId });
    }

    [HttpPost]
    public ActionResult DeleteMachine(int joinId)
    {
      MechanicMachine joinEntry = _db.MechanicMachines.FirstOrDefault(entry => entry.MechanicMachineId == joinId);
      _db.MechanicMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}