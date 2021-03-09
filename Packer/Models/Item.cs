using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Packer.Models
{
  public class Item
  {
    public string Name { get; set; }
    public bool Packed { get; set; }
    public bool Purchased { get; set; }
    public int Id { get; set;}

    public Item(string name, bool packed, bool purchased)
    {
      Name = name;
      Packed = packed;
      Purchased = purchased;
    }
    public Item(string name, bool packed, bool purchased, int id)
    {
      Name = name;
      Packed = packed;
      Purchased = purchased;
      Id = id;
    }

    public static List<Item> GetAll()
    {
      List<Item> allItems = new List<Item> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
          int itemId = rdr.GetInt32(0);
          string itemName = rdr.GetString(1);
          bool itemPacked = rdr.GetBoolean(2);
          bool itemPurchased = rdr.GetBoolean(3);
          Item newItem = new Item(itemName, itemPacked, itemPurchased, itemId);
          allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allItems;
    }
    public static void ClearAll()
    {
    
    }

    public static Item Find(int searchId)
    {
      Item itemName = new Item("socks", true, true);
      return itemName;
    }

    public static void Edit(int id, string name, bool packed, bool purchased)
    {      
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"INSERT INTO items (name) VALUES (@ItemName);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@ItemName";
      name.Value = this.Name;
      cmd.Parameters.Add(name);    
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}