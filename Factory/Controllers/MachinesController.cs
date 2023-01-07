
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Machines.ToList());
    }

    public ActionResult Details(int id)
    {
      ViewBag.Mechanics = _db.Mechanics.ToList();
      Machine thisMachine = _db.Machines
                                .Include(machine => machine.JoinEntities)
                                .ThenInclude(join => join.Mechanic)
                                .FirstOrDefault(machine => machine.MachineId == id); 
      return View(thisMachine);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      if (!ModelState.IsValid)
      {
        return View(machine);
      }
      else
      {
        _db.Machines.Add(machine);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult AddMechanic(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      ViewBag.MechanicId = new SelectList(_db.Mechanics, "MechanicId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddMechanic(int mechanicId, Machine machine)
    {
      #nullable enable
      MechanicMachine? joinEntity = _db.MechanicMachines.FirstOrDefault(join => (join.MechanicId == mechanicId && join.MachineId == machine.MachineId));
      #nullable disable
      if (joinEntity == null && mechanicId != 0)
      {
        _db.MechanicMachines.Add(new MechanicMachine() { MechanicId = mechanicId, MachineId = machine.MachineId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = machine.MachineId });
    }

     public ActionResult Edit(int id)
      {
        Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
        return View(thisMachine);
      }

      [HttpPost]
      public ActionResult Edit(Machine machine)
      {
        if(!ModelState.IsValid){
          return View(machine);
         }
        else
        {
        _db.Machines.Update(machine);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
      }

      public ActionResult Delete(int id)
      {
        Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
        return View(thisMachine);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfirmed(int id)
      {
        Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
        _db.Machines.Remove(thisMachine);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

    [HttpPost]
    public ActionResult DeleteMechanic(int joinId)
    {
      MechanicMachine joinEntry = _db.MechanicMachines.FirstOrDefault(entry => entry.MechanicMachineId == joinId);
      _db.MechanicMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}