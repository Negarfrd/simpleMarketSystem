using System.Collections;

namespace Service;

public class DataBase
{
    private static DataBase _dataBase;
    private ArrayList itemsList;
    private ArrayList usersList;

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
}