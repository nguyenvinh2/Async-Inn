using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Controllers
{
  public class HomeController: Controller
  {
    [HttpGet]
    public ViewResult Index()
    {
      return View();
    }
  }
}
