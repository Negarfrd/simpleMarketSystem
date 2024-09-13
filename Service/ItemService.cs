using DotNetHW2;

namespace Service;

public class ItemService : IItemService
{
    public string AddItem(Item item)
    {
        foreach (var _item in DataBase.GetDatabase().GetItems())
        {
            if (_item.Equals(item))
            {
                return "item has already been added.";
            }
        }
        DataBase.GetDatabase().GetItems().Add(item);
        return "item added successfully.";
    }

    public string DeleteItem(Item item)
    {
        foreach (var _item in DataBase.GetDatabase().GetItems())
        {
            if (_item.Equals(item))
            {
                DataBase.GetDatabase().GetItems().Remove(item);
                return "item deleted.";
            }
        }
        return "item not found.";
    }

    public string BuyItem(Item item)
    {
        //TODO : implement method later for specific user
        return "product purchase was successful";
    }
}