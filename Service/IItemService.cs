using DotNetHW2;

namespace Service;

public interface IItemService
{
    public void AddItem(Item item);
    public void DeleteItem(Item item);
    public string BuyItem(Item item);
}