using System.Collections;

namespace DotNetHW2;

public class DataBase
{
    private static DataBase? _dataBase;
    private ArrayList itemsList { get; }
    private ArrayList usersList { get; }

    private DataBase()
    {
        this.itemsList = new ArrayList();
        this.usersList = new ArrayList();
    }

    public static DataBase GetDatabase()
    {
        if (_dataBase == null)
        {
            _dataBase = new DataBase();
        }

        return _dataBase;
    }

    public ArrayList GetItems()
    {
        return this.itemsList;
    }

    public ArrayList GetUsers()
    {
        return this.usersList;
    }
}