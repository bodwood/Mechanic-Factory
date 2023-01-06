using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Factory.Models;
using System.Linq;

namespace MechanicsController.Controllers
{
  public class MechanicsController
  {
    private readonly FactoryContext _db;

    public MechanicsController(FactoryContext db)
    {
      _db = db;
    }
  }
}