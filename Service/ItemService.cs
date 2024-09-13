using DotNetHW2;

namespace Service;

public class ItemService : IItemService
{
    public void AddItem(Item item)
    {
        DataBase.GetDatabase().GetItems().Add(item);
    }

    public void DeleteItem(Item item)
    {
       DataBase.GetDatabase().GetItems().Remove(item); 
    }

    public string BuyItem(Item item)
    {
        //TODO : implement method later for specific user
        return "product purchase was successful";
    }
}