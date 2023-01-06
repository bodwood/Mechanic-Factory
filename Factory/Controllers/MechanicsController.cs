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
      List<Mechanic> model = _db.Mechanics.ToList();
      return View(model);
    }

  public ActionResult Create()
    {
      return View();
    }

   [HttpPost]
    public ActionResult Create(Mechanic mechanic)
    {
      _db.Mechanics.Add(mechanic);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Mechanic thisMechanic = _db.Mechanics
                                  .Include(mechanic => mechanic.Machines)
                                  .FirstOrDefault(mechanic => mechanic.MechanicId == id);
      return View(thisMechanic);
    }

     public ActionResult Edit(int id)
    {
      Mechanic thisMechanic = _db.Mechanics.FirstOrDefault(mechanic => mechanic.MechanicId == id);
      return View(thisMechanic);
    }
  }
}