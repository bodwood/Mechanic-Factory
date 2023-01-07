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
                                  .Include(mechanic => mechanic.JoinEntities) //grabs join list
                                .ThenInclude(join => join.Machine)  //grabs the related mechanic
                                .FirstOrDefault(mechanic => mechanic.MechanicId == id);  //grabs the machine related to the passed in parameter
      return View(thisMechanic);
    }

    // public ActionResult Edit(int id)
    // {
    //   Mechanic thisMechanic = _db.Mechanics.FirstOrDefault(mechanic => mechanic.MechanicId == id);
    //   return View(thisMechanic);
    // }

    // [HttpPost]
    // public ActionResult Edit(Mechanic mechanic)
    // {
    //   _db.Mechanics.Update(mechanic);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult Delete(int id)
    // {
    //   Mechanic thisMechanic = _db.Mechanics.FirstOrDefault(mechanic => mechanic.MechanicId == id);
    //   return View(thisMechanic);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   Mechanic thisMechanic = _db.Mechanics.FirstOrDefault(mechanic => mechanic.MechanicId == id);
    //   _db.Mechanics.Remove(thisMechanic);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}