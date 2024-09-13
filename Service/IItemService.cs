using DotNetHW2;

namespace Service;

public interface IItemService
{
    public string AddItem(Item item);
    public string DeleteItem(Item item);
    public string BuyItem(Item item);
}