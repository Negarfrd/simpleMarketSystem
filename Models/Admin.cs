namespace DotNetHW2;

public class Admin : User
{
    private static Admin? admin;

    private Admin(string username, string password) : base(username, password)
    {
    }

    public static Admin GetAdmin()
    {
        if (admin == null) {
            admin = new Admin("admin", "adminPassword");
            DataBase.GetDatabase().GetUsers().Add(admin);
        }
        return admin;
    }
}