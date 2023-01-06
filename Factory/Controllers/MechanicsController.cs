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
  }
}