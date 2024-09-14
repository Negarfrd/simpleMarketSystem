using System.Collections;

namespace DotNetHW2;

public class User
{
    private string username { get; set; }
    private string password { get; set; }
    private ArrayList shoppingList { get; }

    public User(string username, string password)
    {
        this.username = username;
        this.password = password;
        this.shoppingList = new ArrayList();
    }
    
    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }

    public ArrayList GetShoppingList()
    {
        return shoppingList;
    }
}