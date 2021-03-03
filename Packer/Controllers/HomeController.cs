using Microsoft.AspNetCore.Mvc;
using Packer.Models;
using System.Collections.Generic;

namespace Packer.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}