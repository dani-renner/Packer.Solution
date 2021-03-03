using Microsoft.AspNetCore.Mvc;
using Packer.Models;
using System.Collections.Generic;
using System;
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
    [HttpGet("/items/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Console.WriteLine("id Edit: " + id.ToString());
      return View(id);
    }
    [HttpPost("/items/{id}")]
    public ActionResult Update(int id, string name, bool packed, bool purchased)
    {
      // Item itembyId = Item.Find(id);
      Console.WriteLine("id Update: " + id.ToString());
      Item.Edit(id, name, packed, purchased);
      return RedirectToAction("Index");
    }
  }
}


