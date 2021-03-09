using MySql.Data.MySqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Packer.Models;
using System;

namespace Packer.Tests
{
  [TestClass]
  public class ItemTests : IDisposable
  {
    public void Dispose()
    {
      Item.ClearAll();
    }
    public void ItemTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=packer_test;";
    }
    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      //Arrange
      string name1 = "trousers";
      string name2 = "socks";
      bool packed1 = false;
      bool purchased1 = true;
      Item newItem1 = new Item(name1,packed1,purchased1);
      newItem1.Save();
      Item newItem2 = new Item(name2, packed1,purchased1);
      newItem2.Save();
      List<Item> newList = new List<Item> { newItem1, newItem2 };

      //Act
      List<Item> result = Item.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}