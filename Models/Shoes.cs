namespace DotNetHW2;

public class Shoes : Item
{
    private int _size { get; }

    public Shoes(string name, double price, int size) : base(name, price)
    {
        _size = size;
    }
}