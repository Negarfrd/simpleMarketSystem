using System.Collections;
using DotNetHW2;
using Service;
using Xunit.Sdk;

namespace ServiceTest;

public class ItemServiceTest
{
    private ItemService _sut;

    public ItemServiceTest()
    {
        _sut = new ItemService();
    }

    [Fact]
    public void AddItemTest()
    {
        //Arrange
        var admin = Admin.GetAdmin();
        var dataBase = DataBase.GetDatabase();
        dataBase.GetItems().Add(new Shoes("shoes", 100, 37));
        int expectedCount = 2;
        
        //Act
        _sut.AddItem(new Clothes("jeans", 120, "blue"));
        
        //Assert
        Assert.Equal(expectedCount, dataBase.GetItems().Count);
    }

    [Fact]
    public void DeleteItemTest()
    {
      //Arrange
      var admin = Admin.GetAdmin();
      var dataBase = DataBase.GetDatabase();
      var item1 = new Shoes("shoes", 100, 37);
      var item2 = new Clothes("jeans", 120, "blue");
      var item3 = new Clothes("shirt", 90, "black");
      dataBase.GetItems().Add(item1);
      dataBase.GetItems().Add(item2);
      dataBase.GetItems().Add(item3);
      int expectedCount = 1;
      
      //Act
      _sut.DeleteItem(item1);
      _sut.DeleteItem(item2);
      
      //Assert
      Assert.Equal(expectedCount, dataBase.GetItems().Count);
    }

    [Fact]
    public void BuyItemTest()
    {
        //Arrange
        var user = new User("testName", "testPassword");
        var userService = UserService.GetUserService();
        userService.SetUser(user);
        var testItem1 = new Shoes("shoes", 100, 37);
        user.GetShoppingList().Add(testItem1);
        var testItem2 = new Clothes("jeans", 120, "blue");
        var testShoppingList = new ArrayList
        {
            testItem1,
            testItem2
        };
        
        //Act
        _sut.BuyItem(testItem2);
        
        //Assert
        Assert.Equal(testShoppingList, user.GetShoppingList());
    }
}