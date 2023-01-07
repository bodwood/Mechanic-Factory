
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
      List<Machine> model = _db.Machines
                                .Include(machine => machine.Mechanic)
                                .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.MechanicId = new SelectList(_db.Mechanics, "MechanicId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      if (machine.MechanicId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Details(int id)
    {
      Machine thisMachine = _db.Machines
                                .Include(machine => machine.Mechanic)
                                .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

   public ActionResult Edit(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.MechanicId = new SelectList(_db.Mechanics, "MechanicId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Machines.Update(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
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
  }
}