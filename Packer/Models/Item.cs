using System.Collections.Generic;

namespace Packer.Models
{
  public class Item
  {
    public string Name { get; set; }
    public bool Packed { get; set; }
    public bool Purchased { get; set; }
    public int Id { get; }

    private static List<Item> _instances = new List<Item>{};

    public Item(string name, bool packed, bool purchased)
    {
      Name = name;
      Packed = packed;
      Purchased = purchased;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Item> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Item Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }

}