namespace DotNetHW2;

public class Item
{
    private string name { get; set; }
    private double price { get; set; }

    public Item(string name, double price)
    {
        this.name = name;
        this.price = price;
    }

    public override string ToString()
    {
        return name + " : " + price;
    }
}