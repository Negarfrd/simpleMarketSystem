using DotNetHW2;
using Service;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome!");
        ShowMenu();
    }

    public static void ShowMenu()
    {
        Console.WriteLine("Sign up or Login to enter");
        string[] command = Console.ReadLine()!.Split(' ').ToArray();
        var userService = UserService.GetUserService();
        var itemService = new ItemService();
        var admin = Admin.GetAdmin();
        var item1 = new Clothes("jeans", 100, "black");
        var item2 = new Clothes("shirt", 150, "red");
        var item3 = new Shoes("sneakers", 240, 38);
        var dataBase = DataBase.GetDatabase();
        dataBase.GetItems().Add(item1);
        dataBase.GetItems().Add(item2);
        dataBase.GetItems().Add(item3);
        if (command[0].ToLower().Equals("sign") || command[0].ToLower().Equals("signup"))
        {
            Console.WriteLine("enter your username and password");
            string[] info = Console.ReadLine()!.Split(' ').ToArray();
            string result = userService.Signup(info[0], info[1]);
            Console.WriteLine(result);
            if (result.Equals("signing up was successful"))
            {
                UserActions(userService, itemService, dataBase);
            }
            else
                ShowMenu();
        }
        else if (command[0].ToLower().Equals("login") || command[0].ToLower().Equals("log"))
        {
            Console.WriteLine("enter your username and password");
            string[] info = Console.ReadLine()!.Split(' ').ToArray();
            string result = userService.Login(info[0], info[1]);
            Console.WriteLine(result);
            if (result.Equals("logging in was successful"))
            {
                if (info[0].Equals("admin"))
                {
                    AdminAction(userService, itemService, dataBase);
                }
                else
                {
                    UserActions(userService, itemService, dataBase);
                }
            }
            else
                ShowMenu();
        }
        else
        {
            Console.WriteLine("Invalid command!");
            ShowMenu();
        }
    }

    public static void UserActions(UserService userService, ItemService itemService, DataBase dataBase)
    {
        Console.WriteLine("Add items to your list or change your username/password if you want!");
        foreach (var item in dataBase.GetItems())
        {
            Console.WriteLine(item);
        }

        string? userInput = Console.ReadLine();
        if (userInput.ToLower().Equals("jeans"))
        {
            Console.WriteLine(itemService.BuyItem(new Clothes("jeans", 100, "black")));
            UserActions(userService, itemService, dataBase);
        }
        else if (userInput.ToLower().Equals("shirt"))
        {
            Console.WriteLine(itemService.BuyItem(new Clothes("shirt", 150, "red")));
            UserActions(userService, itemService, dataBase);
        }
        else if (userInput.ToLower().Equals("sneakers"))
        {
            Console.WriteLine(itemService.BuyItem(new Shoes("sneakers", 240, 38)));
            UserActions(userService, itemService, dataBase);
        }
        else if (userInput.ToLower().Equals("logout"))
        {
            userService.SetUser(null);
            ShowMenu();
        }
        else if (userInput.Split(' ').ToArray()[0].ToLower().Equals("change") &&
                 userInput.Split(' ').ToArray()[1].ToLower().Equals("password"))
        {
            Console.WriteLine(userService.ChangePassword(userService.GetUser().Password,
                userInput.Split(' ').ToArray()[2]));
            UserActions(userService, itemService, dataBase);
        }
        else if (userInput.Split(' ').ToArray()[0].ToLower().Equals("change") &&
                 userInput.Split(' ').ToArray()[1].ToLower().Equals("username"))
        {
            Console.WriteLine(userService.ChangeUsername(userService.GetUser().Username,
                userInput.Split(' ').ToArray()[2]));
            UserActions(userService, itemService, dataBase);
        }
        else
        {
            Console.WriteLine("Invalid command!");
            UserActions(userService, itemService, dataBase);
        }
    }

    public static void AdminAction(UserService userService, ItemService itemService, DataBase dataBase)
    {
        Console.WriteLine("Admin Actions : Add or delete items if you want!");
        Console.WriteLine("correct format: add/delete name price");
        string? adminInput = Console.ReadLine();
        if (adminInput != null && adminInput.Split(' ').ToArray()[0].ToLower().Equals("add"))
        {
            Console.WriteLine(itemService.AddItem(new Item(adminInput.Split(' ').ToArray()[1],
                adminInput.Split(' ').Select(double.Parse).ToArray()[2])));
            AdminAction(userService, itemService, dataBase);
        }
        else if (adminInput != null && adminInput.Split(' ').ToArray()[0].ToLower().Equals("delete"))
        {
            Console.WriteLine(itemService.DeleteItem(new Item(adminInput.Split(' ').ToArray()[1],
                adminInput.Split(' ').Select(double.Parse).ToArray()[2])));
            AdminAction(userService, itemService, dataBase);
        }
        else
        {
            Console.WriteLine("Invalid command!");
            AdminAction(userService, itemService, dataBase);
        }
    }
}