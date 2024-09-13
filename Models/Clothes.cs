namespace DotNetHW2;

public class Clothes : Item
{
    private string _color { get; }
    public Clothes(string name, double price, string color) : base(name, price)
    {
        this._color = color;
    }
}





















