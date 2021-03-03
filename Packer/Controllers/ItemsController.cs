using Microsoft.AspNetCore.Mvc;
using Packer.Models;
using System.Collections.Generic;

namespace Packer.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet("/items")]
    public ActionResult Index()
    {
      List<Item> allItems = Item.GetAll();
      return View(allItems);
    }
    [HttpGet("/items/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpPost("/items")]
    public ActionResult Create(string name, bool packed, bool purchased)
    {
      Item userItem = new Item(name, packed, purchased);
      return RedirectToAction("Index");
    }
    [HttpGet("/items/{id}")]
    public ActionResult Show(int id)
    {
      Item findItem = Item.Find(id);
      return View(findItem);
    }
  }
}


